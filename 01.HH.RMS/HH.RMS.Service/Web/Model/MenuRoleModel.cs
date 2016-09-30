using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Model
{
    public class MenuRoleModel
    {
        public long menuRoleId { get; set; }
        public MenuModel menu { get; set; }
        public RoleModel role { get; set; }
        public bool isInsert { get; set; }
        public bool isUpdate { get; set; }
        public bool isDelete { get; set; }

    }
    public class MenuRoleListModel
    {
        public List<MenuRoleModel> menuRoleList { get; set; }
    }
}
