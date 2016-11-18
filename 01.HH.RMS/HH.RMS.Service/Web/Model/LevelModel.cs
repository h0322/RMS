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
    public class LevelModel
    {
        public static List<LevelModel> CurrentCacheList
        {
            get
            {
                if (CacheHelper.GetCache(Config.cityCache) == null)
                {
                    ILevelService levelService = UnityManager.instance.GetService<ILevelService>();
                    var levelList = levelService.QueryLevelList();
                    CacheHelper.SetCache(Config.cityCache, levelList);
                    return levelList;
                }
                else
                {
                    return (List<LevelModel>)CacheHelper.GetCache(Config.cityCache);
                }
            }
        }
        public long id { get; set; }
        public string levelName { get; set; }
        public int levelOrder { get; set; }
        public string remark { get; set; }
        public DateTime createTime { get; set; }
        public static JsonResult ToSelect()
        {
            List<SelectModel> selectList = new List<SelectModel>();
            var levelList = LevelModel.CurrentCacheList;
            selectList.Add(new SelectModel() { text = "---请选择---", value = "0" });
            levelList.ForEach(m => selectList.Add(new SelectModel() { text = m.levelName, value = m.id.ToString() }));
            JsonResult json = new JsonResult();
            json.Data = selectList;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
    }
}
