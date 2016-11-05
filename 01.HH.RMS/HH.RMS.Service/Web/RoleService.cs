﻿using HH.RMS.Entity.Web;
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

namespace HH.RMS.Service.Web
{
    public class RoleService :  IRoleService
    {
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<MenuEntity> _menuRepository;
        private IRepository<MenuRoleEntity> _menuRoleRepository;
        public RoleService(IRepository<RoleEntity> roleRepository, IRepository<MenuRoleEntity> menuRoleRepository, IRepository<MenuEntity> menuRepository)
        {
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
                    list = RoleModel.CurrentListCache.OrderByDescending(m => m.id).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1)).ToList();
                }
                GridModel gridModel = new GridModel()
                {
                    rows = list.ToList(),
                    total = RoleModel.CurrentListCache.Count
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
                var entity = TinyMapper.Map<RoleEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    _roleRepository.Update(db, entity);
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
                return RoleModel.CurrentListCache.Where(m => m.id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Config.log.Error("roleService.QueryRoleById", ex);
                return null;
            }
        }
        public ResultType DeleteRoleByIds(long[] ids)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _roleRepository.Update(db, _roleRepository.DeleteEntity(),
                    m => ids.Contains(m.id)
                    );
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
                            join b in _menuRoleRepository.Query(db).Where(m=>m.roleId==roleId) on a.id equals b.menuId
                             into ss
                            from m in ss.DefaultIfEmpty()
                            select new MenuRoleModel
                            {
                                menuId = a.id, 
                                code = a.code,
                                menuDescription = a.description, 
                                menuName = a.menuName, 
                                menuOrder = a.menuOrder, 
                                parentId = a.parentId,
                                treeLevel = a.treeLevel,
                                id = m == null ? 0 : m.id,
                                excuteType = m == null ? 0 : m.excuteType
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
