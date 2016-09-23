using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HH.RMS.Model
{
    public class RoleModel
    {
        public static RoleModel Cache
        {
            get
            {
                if (CacheHelper.GetCache(Config.roleCache) == null)
                {
                    return null;
                }
                else
                {
                    return (RoleModel)CacheHelper.GetCache(Config.roleCache);
                }
            }
        }
        public long roleId { get; set; }
        public string roleName { get; set; }
        public RoleType roleType { get; set; }
        public int roleOrder { get; set; }
    }
}