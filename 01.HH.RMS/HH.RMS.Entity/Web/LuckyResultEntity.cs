using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    [MappingTable(tableName = "LuckyResult")]
    public class LuckyResultEntity : EntityBase
    {
        public long luckyDrawId { get; set; }
        public long accountId { get; set; }
        public long luckPrizeId { get; set; }
        public long placeId { get; set; }
    }
}
