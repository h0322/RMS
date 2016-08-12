using HH.RMS.Entity;
using HH.RMS.Model;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service
{
    public class RoleService : ServiceBase, IRoleService
    {
        private IRepository<RoleEntity> _roleRepository;
        public RoleService(IRepository<RoleEntity> roleRepository)
        {
            _roleRepository = roleRepository;
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
    }
}
