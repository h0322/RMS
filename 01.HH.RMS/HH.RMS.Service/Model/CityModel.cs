using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Model
{
    public class CityModel
    {
        public static List<CityModel> ListCache
        {
            get
            {
                if (CacheHelper.GetCache(Config.cityCache) == null)
                {
                    ICityService cityService = UnityManager.instance.GetService<ICityService>();
                    var cityList = cityService.QueryCityListAll();
                    CacheHelper.SetCache(Config.cityCache, cityList);
                    return cityList;
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
