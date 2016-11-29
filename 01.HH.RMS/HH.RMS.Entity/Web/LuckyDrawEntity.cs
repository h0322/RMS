using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    [MappingTable(tableName = "LuckyDraw")]
    public class LuckyDrawEntity : EntityBase
    {
        [MaxLength(50)]
        public string name { get; set; }
        [MaxLength(1000)]
        public string description { get; set; }
    }
}
