using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    [MappingTable(tableName = "SystemMenu")]
    public class MenuEntity:EntityBase
    {
        [MaxLength(50)]
        public string menuName { get; set; }
        [MaxLength(100)]
        public string description { get; set; }
        public long parentId { get; set; }
        public int menuOrder { get; set; }
        public MenuType menuType { get; set; }
        [MaxLength(100)]
        public string url { get; set; }
    }
}
