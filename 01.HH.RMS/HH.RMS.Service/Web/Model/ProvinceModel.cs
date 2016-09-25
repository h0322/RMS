using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Model
{
    public class ProvinceModel
    {
        public static List<ProvinceModel> ListCache
        {
            get
            {
                if (CacheHelper.GetCache(Config.provinceCache) == null)
                {
                    var provinceService = UnityManager.instance.GetService<IProvinceService>();
                    var provinceList = provinceService.QueryProvinceList();
                    CacheHelper.SetCache(Config.provinceCache, provinceList);
                    return provinceList;
                }
                else
                {
                    return (List<ProvinceModel>)CacheHelper.GetCache(Config.provinceCache);
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
