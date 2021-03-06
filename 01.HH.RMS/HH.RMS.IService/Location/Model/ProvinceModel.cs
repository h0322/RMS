﻿using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.IService.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HH.RMS.IService.Model.Location
{
    public class ProvinceModel
    {
        public static List<ProvinceModel> CurrentCacheList
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
        public long id { get; set; }
        public long countryId { get; set; }
        public string countryDescription { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public string remark { get; set; }
        public static JsonResult ToSelect()
        {
            List<SelectModel> selectList = new List<SelectModel>();
            var provinceList = ProvinceModel.CurrentCacheList;
            selectList.Add(new SelectModel() { text = "---请选择---", value = "0" });
            provinceList.ForEach(m => selectList.Add(new SelectModel() { text = m.name, value = m.id.ToString() }));
            JsonResult json = new JsonResult();
            json.Data = selectList;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
    }
}
