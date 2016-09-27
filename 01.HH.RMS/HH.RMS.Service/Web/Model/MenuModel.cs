using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Model
{
    public class MenuModel
    {
        public static string Session
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
        public string menuName { get; set; }
        public string description { get; set; }
        public long parentId { get; set; }
        public int menuOrder { get; set; }
        public MenuType menuType { get; set; }
        public string url { get; set; }
    }
}
