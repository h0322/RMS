using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Model
{
    public class CityModel
    {
        public static List<CityModel> Cache
        {
            get
            {
                if (CacheHelper.GetCache(Config.cityCache) == null)
                {
                    return null;
                }
                else
                {
                    return (List<CityModel>)CacheHelper.GetCache(Config.cityCache);
                }
            }
        }
        public long provinceId { get; set; }
        public string provinceName { get; set; }
        public long cityId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int order { get; set; }
    }
}
