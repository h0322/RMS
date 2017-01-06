using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web
{
    public class MenuService :  IMenuService
    {
        private IRepository<MenuEntity> _menuRepository;
        private IRepository<MenuRoleEntity> _menuRoleRepository;
        public MenuService(IRepository<MenuEntity> menuRepository, IRepository<MenuRoleEntity> menuRoleRepository)
        {
            _menuRepository = menuRepository;
            _menuRoleRepository = menuRoleRepository;
        }
        public List<MenuModel> QueryMenuALL()
        {
            List<MenuModel> menuList = new List<MenuModel>();
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var list = _menuRepository.Query(db).ToList();
                    return MenuModel.ModelMapper<List<MenuModel>>(list);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("MenuService.QueryMenuALL", ex);
                return null;
            }
        }
        public string GetMenuString()
        {
            var menuList = QueryMenuByRole();
            if (menuList == null)
            { 
                return ""; 
            }
            var parentList = menuList.Where(m => m.parentId == 0).ToList();
            StringBuilder menuBuilder = new StringBuilder();
            foreach (var parent in parentList)
            {
                menuBuilder.Append("<li>");
                menuBuilder.AppendFormat("<span>{0}</span>", parent.menuName);
                var child = menuList.Where(m => m.parentId == parent.id);
                if(child!=null)
                {menuBuilder.Append(GetChildMenu(parent.id, menuList)); }
                
                menuBuilder.Append("</li>");
            }
            string menuString = menuBuilder.ToString();
            
            return menuString;
        }
        private List<MenuEntity> QueryMenuByRole()
        {
            if (AccountModel.CurrentSession == null)
            {
                return null;
            }
            long roleBitMap = AccountModel.CurrentSession.roleBitMap;

            using(var db = new ApplicationDbContext())
            {
                var q = (from a in _menuRepository.Query(db)
                         join b in _menuRoleRepository.Query(db) on a.id equals b.menuId into t1
                         from t in t1.DefaultIfEmpty()
                         where ((t.roleId & roleBitMap) == t.roleId || AccountModel.CurrentSession.accountType == AccountType.Admin)
                         select a).Distinct();
                return q.OrderBy(m => m.menuOrder).ToList();
            }
        }
        private StringBuilder GetChildMenu(long parentId, List<MenuEntity> menuList)
        {
            StringBuilder menuBuilder = new StringBuilder();
            var childList = menuList.Where(m => m.parentId == parentId);
            if (childList.Count()<1)
            {
                return menuBuilder;
            }
            menuBuilder.Append("<ul>");
            foreach (var child in childList)
            {
                menuBuilder.Append("<li>");
                menuBuilder.AppendFormat("<span>{0}</span>", "<a href='"+child.url+"'>"+child.menuName+"</a>");
                menuBuilder.Append(GetChildMenu(child.id,menuList));
                menuBuilder.Append("</li>");
            }
            menuBuilder.Append("</ul>");
            return menuBuilder;
        }


    }
}
