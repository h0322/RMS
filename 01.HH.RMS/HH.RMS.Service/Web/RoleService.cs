using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
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
        public RoleService(IRepository<AccountEntity> accountRepository, IRepository<RoleEntity> roleRepository, IRepository<MenuRoleEntity> menuRoleRepository, IRepository<MenuEntity> menuRepository)
        {
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
                //var entity = TinyMapper.Map<RoleEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    //_roleRepository.Update(db, entity);
                    //_roleRepository.Update(db, 
                    //    new RoleEntity() {roleName=model.roleName, updateBy = AccountModel.CurrentSession.id, updateTime = DateTime.Now},
                    //    m => m.id == model.id
                    //    );
                    _roleRepository.Update(db,
                    m => new RoleEntity() { roleName = model.roleName,roleOrder = model.roleOrder, updateBy = AccountModel.CurrentSession.id, updateTime = DateTime.Now },
                    m => m.id == model.id
                    );
                }
                CacheHelper.RemoveCache(Config.roleCache);
                return ResultType.Success;
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
                return RoleModel.CurrentCacheList.Where(m => m.id == id).FirstOrDefault();
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
        public ResultType UpdateMenuRoleById(MenuRoleModel model)
        {
             try
             {
                 var entity = TinyMapper.Map<MenuRoleEntity>(model);
                 entity.updateTime = DateTime.Now;
                 entity.updateBy = AccountModel.CurrentSession.id;
                using (var db = new ApplicationDbContext())
                {
                    _menuRoleRepository.Update(db, m => entity,
                    m => m.id == model.id
                    );
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.UpdateMenuRoleById", ex);
                return ResultType.SystemError;
            }
        }
        public ResultType InsertMenuRole(MenuRoleModel model)
        {
            try
            {
                var entity = TinyMapper.Map<MenuRoleEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    _menuRoleRepository.Insert(db, entity);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.InsertMenuRole", ex);
                return ResultType.SystemError;
            }
        }
        public ResultType DeleteMenuRoleByIds(long[] ids)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _menuRoleRepository.Update(db, _menuRoleRepository.DeleteEntity(),
                    m => ids.Contains(m.id)
                    );
                }
                CacheHelper.RemoveCache(Config.roleCache);
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.DeleteMenuRoleByIds", ex);
                return ResultType.SystemError;
            }
        }
        public ResultType DeleteMenuRoleByRoleId(long roleId)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _menuRoleRepository.Update(db, _menuRoleRepository.DeleteEntity(),
                    m => m.roleId == roleId
                    );
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.DeleteMenuRoleById", ex);
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
