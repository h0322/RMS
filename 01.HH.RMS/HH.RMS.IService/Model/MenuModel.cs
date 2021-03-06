﻿using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Model
{
    public class MenuModel
    {
        public static string CurrentSession
        {
            get {
                if (SessionHelper.GetSession(Config.menuSession) == null)
                {
                    IMenuService menuService = UnityManager.instance.GetService<IMenuService>();
                    SessionHelper.SetSession(Config.menuSession, menuService.GetMenuString());
                }
                return SessionHelper.GetSession(Config.menuSession).ToString();
            }
        }
        public static List<MenuModel> CurrentCacheList
        {
            get
            {
                if (CacheHelper.GetCache(Config.menuCache) == null)
                {
                    IMenuService menuService = UnityManager.instance.GetService<IMenuService>();
                    var menuList = menuService.QueryMenuALL();
                    CacheHelper.SetCache(Config.menuCache, menuList);
                    return menuList;
                }
                else
                {
                    return (List<MenuModel>)CacheHelper.GetCache(Config.menuCache);
                }
            }
        }
        public long id { get; set; }
        public string code { get; set; }
        public string menuName { get; set; }
        public string description { get; set; }
        public long parentId { get; set; }
        public int menuOrder { get; set; }
        public MenuType menuType { get; set; }
        public List<RoleModel> roleList { get; set; }
        public string url { get; set; }
        public int treeLevel { get; set; }
        public DateTime createTime { get; set; }
        public long selectBitMap { get; set; }
        public long insertBitMap { get; set; }
        public long updateBitMap { get; set; }
        public long deleteBitMap { get; set; }
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
