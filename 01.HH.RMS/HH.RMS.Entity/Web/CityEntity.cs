using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    [MappingTable(tableName = "city")]
    public class CityEntity:EntityBase
    {
        public long provinceId { get; set; }
        //[ForeignKey("provinceId")]
        //public virtual ProvinceEntity province { get; set; }
        [MaxLength(20)]
        public string code { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
        public int order { get; set; }
    }
}
