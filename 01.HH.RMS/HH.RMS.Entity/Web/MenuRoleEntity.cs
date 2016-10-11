using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    [MappingTable(tableName = "SystemMenuRole")]
    public class MenuRoleEntity:EntityBase
    {
        public long menuId { get; set; }
        public long roleId { get; set; }
        public int excuteType { get; set; }

    }
}
