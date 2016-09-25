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
    public class LevelModel
    {
        public static List<LevelModel> ListCache
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
        public long levelId { get; set; }
        public string levelName { get; set; }
        public int levelOrder { get; set; }
        public string remark { get; set; }
    }
}
