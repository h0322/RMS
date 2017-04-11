using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    [MappingTable(tableName = "LuckyPrize")]
    public class LuckyPrizeEntity : EntityBase
    {
        public long luckyDrawId { get; set; }
        [MaxLength(50)]
        public string prizeName { get; set; }
        [MaxLength(1000)]
        public string prizeDescription { get; set; }
        public decimal score { get; set; }
        public decimal amount { get; set; }
        public int totalCount { get; set; }
        public int leftCount { get; set; }
        public PrizeType prizeType { get; set; }
        public long? accountLevelId { get; set; }
        public decimal rate { get; set; }
        public int prizeOrder { get; set; }
        public bool isLimited { get; set; }
    }
}
