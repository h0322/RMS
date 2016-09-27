using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HH.RMS.Service.Web.Model
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
        public static JsonResult ToSelect()
        {
            List<SelectModel> selectList = new List<SelectModel>();
            var roleList = RoleModel.ListCache;
            selectList.Add(new SelectModel() { text = "---请选择---", value = "0" });
            roleList.ForEach(m => selectList.Add(new SelectModel() { text = m.roleName, value = m.roleId.ToString() }));
            JsonResult json = new JsonResult();
            json.Data = selectList;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
    }
}