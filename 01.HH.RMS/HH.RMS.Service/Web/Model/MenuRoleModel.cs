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
        public long menuId { get; set; }
        public string menuName { get; set; }
        public string menuDescription { get; set; }
        public int menuOrder { get; set; }
        public long parentId { get; set; }
        public int treeLevel { get; set; }
        public long roleId { get; set; }
        public bool isSelect { get; set; }
        public bool isInsert { get; set; }
        public bool isUpdate { get; set; }
        public bool isDelete { get; set; }

    }
}
