using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Interface;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Model
{
    public class MenuRoleModel
    {
        public static List<MenuRoleModel> ListSession
        {
            get
            {
                if (SessionHelper.GetSession(Config.menuRoleSession) == null)
                {
                    IRoleService roleService = UnityManager.instance.GetService<IRoleService>();
                    SessionHelper.SetSession(Config.menuRoleSession, roleService.QueryMenuByRoleIdList(AccountModel.CurrentSession.roleBitMap));
                }
                return (List<MenuRoleModel>)SessionHelper.GetSession(Config.menuRoleSession);
            }
            //get { List<MenuRoleModel> QueryMenuByRoleIdList(long roleId)}
        }
        public long id { get; set; }
        public long menuId { get; set; }
        public string code { get; set; }
        public string menuName { get; set; }
        public string menuDescription { get; set; }
        public int menuOrder { get; set; }
        public long parentId { get; set; }
        public int treeLevel { get; set; }
        public long roleId { get; set; }
        public int excuteType { get; set; }
        public bool isSelect { get; set; }
        public bool isUpdate { get; set; }
        public bool isInsert { get; set; }
        public bool isDelete { get; set; }

    }
}
