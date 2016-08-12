using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    [MappingTable(tableName = "province")]
    public class ProvinceEntity:EntityBase
    {
        public long countryId { get; set; }
        [ForeignKey("countryId")]
        public virtual CountryEntity country { get; set; }
        [MaxLength(20)]
        public string code { get; set; }
         [MaxLength(50)]
        public string name { get; set; }
        public int order { get; set; }
    }
}
