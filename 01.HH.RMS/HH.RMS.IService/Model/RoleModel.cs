﻿using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity;

using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HH.RMS.IService.Model
{
    public class RoleModel
    {
        public static List<RoleModel> CurrentCacheList
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
        public long id { get; set; }
        public string roleName { get; set; }
        public long bitMap { get; set; }
        public int roleOrder { get; set; }
        public DateTime createTime { get; set; }
        public List<MenuModel> menuList { get; set; }
        public static JsonResult ToSelect()
        {
            List<SelectModel> selectList = new List<SelectModel>();
            var roleList = RoleModel.CurrentCacheList;
            selectList.Add(new SelectModel() { text = "---请选择---", value = "0" });
            roleList.ForEach(m => selectList.Add(new SelectModel() { text = m.roleName, value = m.id.ToString() }));
            JsonResult json = new JsonResult();
            json.Data = selectList;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
        public static T ModelMapper<T>(object entity)
        {
            return TinyMapper.Map<T>(entity);
        }
        public static T EntityMapper<T>(object model)
        {
            return TinyMapper.Map<T>(model);
        }
    }
}