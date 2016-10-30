using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HH.RMS.Service.Web.Model
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
        public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public static JsonResult ToSelect(long id)
        {
            List<SelectModel> selectList = new List<SelectModel>();
            var cityList = CityModel.ListCache.Where(m=>m.provinceId == id).ToList();
            selectList.Add(new SelectModel() { text = "---请选择---", value = "-1" });
            cityList.ForEach(m => selectList.Add(new SelectModel() { text = m.name, value = m.id.ToString() }));
            JsonResult json = new JsonResult();
            json.Data = selectList;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
    }
}
