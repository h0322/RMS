using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
     [MappingTable(tableName = "LuckyLog")]
    public class LuckyLogEntity: EntityBase
    {
        public long accountId { get; set; }
        public long luckyDrawId { get; set; }
        public long luckyPrizeId { get; set; }
        public long? placeId { get; set; }
    }
}
