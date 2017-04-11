using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    public class LuckyLogModel
    {
        public long id { get; set; }
        public long accountId { get; set; }
        public long luckyDrawId { get; set; }
        public long luckyPrizeId { get; set; }
        public long? placeId { get; set; }
        public string remark { get; set; }
        public static T ModelMapper<T>(object entity)
        {
            return TinyMapper.Map<T>(entity);
        }
        public static T EntityMapper<T>(object model)
        {
            return TinyMapper.Map<T>(model);
        }
    }
}
