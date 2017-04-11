using HH.RMS.Common.Constant;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    public class LuckyPrizeModel
    {
        public long id { get; set; }
        public long luckyDrawId { get; set; }
        public string prizeName { get; set; }
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
