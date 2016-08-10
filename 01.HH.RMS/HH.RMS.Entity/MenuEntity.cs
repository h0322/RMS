using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    [MappingTable(tableName = "SystemMenu")]
    public class MenuEntity:EntityBase
    {
        public string menuName { get; set; }
        public string description { get; set; }
        public long parentId { get; set; }
        public int menuOrder { get; set; }
        public MenuType menuType { get; set; }
        public string url { get; set; }
    }
}
