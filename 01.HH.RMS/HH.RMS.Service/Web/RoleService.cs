using HH.RMS.Entity;
using HH.RMS.Service.Web.Model;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.Common.Constant;

namespace HH.RMS.Service.Web
{
    public class RoleService : ServiceBase, IRoleService
    {
        private IRepository<RoleEntity> _roleRepository;
        public RoleService(IRepository<RoleEntity> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public GridModel QueryRoleToGrid(PagerModel pager)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = (from a in _roleRepository.Query(db)
                             where (string.IsNullOrEmpty(pager.searchText) || a.roleName.Contains(pager.searchText))
                                && (pager.searchDateFrom == null || a.createTime > pager.searchDateFrom)
                                && (pager.searchDateTo == null || a.createTime < pager.searchDateTo)
                             select new RoleModel
                             {
                                 roleName = a.roleName,
                                 roleOrder = a.roleOrder,
                                 roleId = a.id,
                                 roleType = a.roleType
                             });
                    IQueryable<RoleModel> qPager = null;
                    if (pager != null)
                    {
                        qPager = q.OrderByDescending(m => m.roleId).Take(pager.rows * pager.page).Skip(pager.rows * (pager.page - 1));
                    }
                    GridModel gridModel = new GridModel()
                    {
                        rows = qPager.ToList(),
                        total = q.Count()
                    };
                    return gridModel;
                    //return null;
                }
            }
            catch (Exception ex)
            {
                log.Error("RoleService.QueryRoleToGrid", ex);
                return null;
            }
        }
        public List<RoleModel> QueryRoleList()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _roleRepository.Query(db)
                            select new RoleModel()
                            {
                                roleId = a.id,
                                roleName = a.roleName,
                                roleOrder = a.roleOrder,
                                roleType = a.roleType
                            };
                    return q.ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("RoleService.QueryRoleList", ex);
                return null;
            }
        }
        public ResultType CreateRole(RoleModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _roleRepository.Insert(db, new RoleEntity()
                    {
                        roleName = model.roleName,
                        roleOrder = model.roleOrder
                    });
                    return ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                log.Error("roleService.Inserrole", ex);
                return ResultType.SystemError;
            }

        }

        public ResultType UpdateRole(RoleModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _roleRepository.Update(db, m => new RoleEntity()
                    {
                        roleName = model.roleName,
                        roleOrder = model.roleOrder,
                        updateTime = DateTime.Now,
                        updateBy = AccountModel.Session.accountId
                    },
                    m => m.id == model.roleId
                    );
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                log.Error("roleService.Updaterole", ex);
                return ResultType.SystemError;
            }

        }
        public RoleModel QueryRoleById(long id)
        {
            try
            {
                return RoleModel.ListCache.Where(m => m.roleId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                log.Error("roleService.QueryRoleById", ex);
                return null;
            }
        }
    }
}
