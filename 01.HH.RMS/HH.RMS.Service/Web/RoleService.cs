using HH.RMS.Entity.Web;
using HH.RMS.IService.Web.Model;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.IService.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using Nelibur.ObjectMapper;
using System.Data.SqlClient;
using System.Transactions;

namespace HH.RMS.Service.Web
{
    public class RoleService :  IRoleService
    {
        private IRepository<AccountEntity> _accountRepository;
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<MenuEntity> _menuRepository;
        private IRepository<MenuRoleEntity> _menuRoleRepository;
        private IMenuService _menuService { get; set; }
        public RoleService(IMenuService menuService,IRepository<AccountEntity> accountRepository, IRepository<RoleEntity> roleRepository, IRepository<MenuRoleEntity> menuRoleRepository, IRepository<MenuEntity> menuRepository)
        {
            _menuService = menuService;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _menuRepository = menuRepository;
            _menuRoleRepository = menuRoleRepository;
        }
        public GridModel QueryRoleToGrid(PagerModel pager)
        {
            try
            {
                List<RoleModel> list = null;
                if (pager != null)
                {
                    list = RoleModel.CurrentCacheList.OrderByDescending(m => m.id).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1)).ToList();
                }
                GridModel gridModel = new GridModel()
                {
                    rows = list.ToList(),
                    total = RoleModel.CurrentCacheList.Count
                };
                return gridModel;
            }
            catch (Exception ex)
            {
                Config.log.Error("RoleService.QueryRoleToGrid", ex);
                return null;
            }
        }
        public List<RoleModel> QueryRoleList()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _roleRepository.Query(db).ToList();
                    return TinyMapper.Map<List<RoleModel>>(list);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("RoleService.QueryRoleList", ex);
                return null;
            }
        }
        public ResultType CreateRole(RoleModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    
                    _roleRepository.Insert(db, TinyMapper.Map<RoleEntity>(model));
                    CacheHelper.RemoveCache(Config.roleCache);
                    return ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.Inserrole", ex);
                return ResultType.SystemError;
            }

        }

        public ResultType UpdateRole(RoleModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    int result = _roleRepository.Update(db,
                    m => new RoleEntity() { roleName = model.roleName,roleOrder = model.roleOrder, updateBy = AccountModel.CurrentSession.id, updateTime = DateTime.Now },
                    m => m.id == model.id
                    );
                    CacheHelper.RemoveCache(Config.roleCache);
                    if (result > 0)
                    {
                        return ResultType.Success;
                    }
                    else
                    {
                        return ResultType.Fail;
                    }
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.Updaterole", ex);
                return ResultType.SystemError;
            }

        }
        public RoleModel QueryRoleById(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = _roleRepository.Query(db).Where(m=>m.id==id).FirstOrDefault();
                    return TinyMapper.Map<RoleModel>(entity);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.QueryRoleById", ex);
                return null;
            }
        }
        public ResultType DeleteRoleByIds(long[] idArray)
        {
            string idString = string.Join(",", idArray);
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    string sqlString = "declare @roleBitMap bigint=0;";
                    sqlString += " select @roleBitMap = sum(bitMap) from SystemRole where id in (" + idString + ");";
                    sqlString += " begin tran";
                    sqlString += " update SystemRole set isActive=0 where id in (" + idString + ");";
                    sqlString += " update SystemMenu set updateBitMap = updateBitMap - (updateBitMap & @roleBitMap) where (updateBitMap & @roleBitMap) <> 0;";
                    sqlString += " update SystemMenu set insertBitMap = insertBitMap - (insertBitMap & @roleBitMap) where (insertBitMap & @roleBitMap) <> 0;";
                    sqlString += " update SystemMenu set deleteBitMap = deleteBitMap - (deleteBitMap & @roleBitMap) where (deleteBitMap & @roleBitMap) <> 0;";
                    sqlString += " update SystemMenu set selectBitMap = selectBitMap - (selectBitMap & @roleBitMap) where (selectBitMap & @roleBitMap) <> 0;";
                    sqlString += " update account set roleBitMap = roleBitMap - (roleBitMap & @roleBitMap) where (roleBitMap & @roleBitMap) <> 0;";
                    sqlString += " commit tran";
                    _roleRepository.ExecuteSql(db, sqlString, null);
                }
                CacheHelper.RemoveCache(Config.roleCache);
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.DeleteRoleByIds", ex);
                return ResultType.SystemError;
            }
        }
        //public ResultType UpdateMenuRole(MenuModel model)
        //{
        //     try
        //     {
        //        // var entity = TinyMapper.Map<MenuRoleEntity>(model);
        //        // entity.updateTime = DateTime.Now;
        //        // entity.updateBy = AccountModel.CurrentSession.id;
        //        //using (var db = new ApplicationDbContext())
        //        //{
        //        //    _menuRoleRepository.Update(db, m => entity,
        //        //    m => m.id == model.id
        //        //    );
        //        //}
        //        return ResultType.Success;
        //    }
        //    catch (Exception ex)
        //    {
        //        Config.log.Error("roleService.UpdateMenuRoleById", ex);
        //        return ResultType.SystemError;
        //    }
        //}
        public ResultType UpdateMenuRole(RoleMenuModel model)
        {
            try
            {
                var result = ResultType.Success;
                var role = QueryRoleById(model.roleId);
                if (role == null)
                {
                    Config.log.Info("roleService.UpdateMenuRole:Role Is NULL");
                    return ResultType.Fail;
                }
                MenuModel menu = new MenuModel();
                List<MenuModel> menuList = _menuService.QueryMenuALL();
                bool isUpdate = false;
                foreach (var item in menuList)
                {
                    if (model.isInsert != null && model.isInsert.Contains(item.id))
                    {
                        item.insertBitMap = item.insertBitMap | role.bitMap;
                        isUpdate = true;
                    }
                    else if ((item.insertBitMap & role.bitMap) == role.bitMap)
                    {
                        item.insertBitMap = item.insertBitMap - role.bitMap;
                        isUpdate = true;
                    }
                    if (model.isUpdate != null && model.isUpdate.Contains(item.id))
                    {
                        item.updateBitMap = item.updateBitMap | role.bitMap;
                        isUpdate = true;
                    }
                    else if ((item.updateBitMap & role.bitMap) == role.bitMap)
                    {
                        item.updateBitMap = item.updateBitMap - role.bitMap;
                        isUpdate = true;
                    }
                    if (model.isDelete != null && model.isDelete.Contains(item.id))
                    {
                        item.deleteBitMap = item.deleteBitMap | role.bitMap;
                        isUpdate = true;
                    }
                    else if ((item.deleteBitMap & role.bitMap) == role.bitMap)
                    {
                        item.deleteBitMap = item.deleteBitMap - role.bitMap;
                        isUpdate = true;
                    }
                    if (model.isSelect != null && model.isSelect.Contains(item.id))
                    {
                        item.selectBitMap = item.selectBitMap | role.bitMap;
                        isUpdate = true;
                    }
                    else if ((item.selectBitMap & role.bitMap) == role.bitMap)
                    {
                        item.selectBitMap = item.selectBitMap - role.bitMap;
                        isUpdate = true;
                    }
                    if (isUpdate)
                    {
                        result = UpdateMenuRoleByMenuId(item);
                        if (result != ResultType.Success)
                        {
                            break;
                        }
                    }
                }
                CacheHelper.RemoveCache(Config.menuCache);
                return result;
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.UpdateMenuRole", ex);
                return ResultType.SystemError;
            }
        }
        public ResultType UpdateMenuRoleByMenuId(MenuModel model)
        {
            try
            {
                var entity = TinyMapper.Map<MenuRoleEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    _menuRepository.Update(db, m => new MenuEntity() {
                        selectBitMap = model.selectBitMap,
                        updateBitMap = model.updateBitMap,
                        deleteBitMap = model.deleteBitMap,
                        insertBitMap = model.insertBitMap
                    }, m=>m.id == model.id);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.InsertMenuRole", ex);
                return ResultType.SystemError;
            }
        }
        public List<MenuRoleModel> QueryMenuByRoleIdList(long roleId)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _menuRepository.Query(db)
                            join b in _roleRepository.Query(db) on roleId equals b.id
                            select new MenuRoleModel
                            {
                                menuId = a.id, 
                                code = a.code,
                                menuDescription = a.description, 
                                menuName = a.menuName, 
                                menuOrder = a.menuOrder, 
                                parentId = a.parentId,
                                treeLevel = a.treeLevel,
                                isSelect = (a.selectBitMap & b.bitMap) == b.bitMap ? true : false,
                                isInsert = (a.insertBitMap & b.bitMap) == b.bitMap ? true : false,
                                isUpdate = (a.updateBitMap & b.bitMap) == b.bitMap ? true : false,
                                isDelete = (a.deleteBitMap & b.bitMap) == b.bitMap ? true : false,
                            };
                    return q.OrderBy(m=>m.menuOrder).ToList();
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.QueryMenuByRoleIdList", ex);
                return null;
            }
        }

    }
}
