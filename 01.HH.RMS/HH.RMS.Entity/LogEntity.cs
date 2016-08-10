using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
     [MappingTable(tableName = "SystemLog")]
    public class LogEntity : EntityBase
    {
        public DateTime date { get; set; }
        public string thread { get; set; }
        public string level { get; set; }
        public string logger { get; set; }
        public string source { get; set; }
        public string exception { get; set; }
        public string message { get; set; }
    }
}
