using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Interface;
using Nelibur.ObjectMapper;
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
        public DateTime createTime { get; set; }
        public List<MenuModel> menuList { get; set; }
        public static JsonResult ToSelect()
        {
            List<SelectModel> selectList = new List<SelectModel>();
            var roleList = RoleModel.ListCache;
            selectList.Add(new SelectModel() { text = "---请选择---", value = "-1" });
            roleList.ForEach(m => selectList.Add(new SelectModel() { text = m.roleName, value = m.roleId.ToString() }));
            JsonResult json = new JsonResult();
            json.Data = selectList;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
        public static void ModelMapper()
        {
            TinyMapper.Bind<RoleEntity, RoleModel>(config =>
            {
                config.Bind(x => x.id, y => y.roleId);
            });
        }
        public static void EntityMapper()
        {
            TinyMapper.Bind<RoleModel, RoleEntity>(config =>
            {
                config.Bind(x => x.roleId, y => y.id);
            });
        }
    }
}