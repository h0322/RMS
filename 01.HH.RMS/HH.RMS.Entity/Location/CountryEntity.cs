using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Location
{
    [MappingTable(tableName = "country")]
    public class CountryEntity :EntityBase
    {
        [MaxLength(20)]
        public string code { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
        public int order { get; set; }
    }
}
