using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    [MappingTable(tableName="person")]
    public class PersonEntity : EntityBase
    {
        [MaxLength(10)]
        public string name { get; set; }
        [MaxLength(20)]
        public string nickName { get; set; }
        [MaxLength(11)]
        public string mobile { get; set; }
        [MaxLength(50)]
        public string email { get; set; }
        public SexType sex { get; set; }
        [MaxLength(10)]
        public string birthday { get; set; }
        public long countryId { get; set; }
        public long provinceId { get; set; }
        public long cityId { get; set; }
        [MaxLength(100)]
        public string address { get; set; }
    }
}
