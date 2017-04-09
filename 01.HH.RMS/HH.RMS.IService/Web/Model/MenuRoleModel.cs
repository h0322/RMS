using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;

using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Web.Model
{
    public class MenuRoleModel
    {
        public long id { get; set; }
        public long menuId { get; set; }
        public string code { get; set; }
        public string menuName { get; set; }
        public string menuDescription { get; set; }
        public int menuOrder { get; set; }
        public long parentId { get; set; }
        public int treeLevel { get; set; }
        public long roleId { get; set; }
        public ExcuteType excuteType { get; set; }
        public bool isSelect { get; set; }
        public bool isUpdate { get; set; }
        public bool isInsert { get; set; }
        public bool isDelete { get; set; }

    }
    public class RoleMenuModel
    {
        public long roleId { get; set; }
        public long[] isSelect { get; set; }
        public long[] isUpdate { get; set; }
        public long[] isInsert { get; set; }
        public long[] isDelete { get; set; }
    }
}
