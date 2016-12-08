using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    [MappingTable(tableName = "Email")]
    public class EmailEntity:EntityBase
    {
        [MaxLength(100)]
        public string name { get; set; }
        [MaxLength(1000)]
        public string description { get; set; }
        [MaxLength(500)]
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
    }
}
