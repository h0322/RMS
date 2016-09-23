using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Model
{
    public class ProvinceModel
    {
        public static ProvinceModel Cache
        {
            get
            {
                if (CacheHelper.GetCache(Config.provinceCache) == null)
                {
                    //UnityManager
                    return null;
                }
                else
                {
                    return (ProvinceModel)CacheHelper.GetCache(Config.provinceCache);
                }
            }
        }
        public long provinceId { get; set; }
        public long countryId { get; set; }
        public string countryDescription { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int order { get; set; }
    }
}
