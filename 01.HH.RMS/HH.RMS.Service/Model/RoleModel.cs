using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HH.RMS.Service.Model
{
    public class RoleModel
    {
        public static List<RoleModel> ListCache
        {
            get
            {
                if (CacheHelper.GetCache(Config.roleCache) == null)
                {
                    var roleService = UnityManager.instance.GetService<IRoleService>();
                    var roleList = roleService.QueryRoleList();
                    CacheHelper.SetCache(Config.roleCache, roleList);
                    return roleList;
                }
                else
                {
                    return (List<RoleModel>)CacheHelper.GetCache(Config.roleCache);
                }
            }
        }
        public long roleId { get; set; }
        public string roleName { get; set; }
        public RoleType roleType { get; set; }
        public int roleOrder { get; set; }
    }
}