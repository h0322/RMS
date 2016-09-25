using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Model
{
    public class LevelModel
    {
        public LevelModel ListCache
        {
            get
            {
                if (CacheHelper.GetCache(Config.levelCache) == null)
                {
                    return null;
                }
                else
                {
                    return (LevelModel)CacheHelper.GetCache(Config.levelCache);
                }
            }
        }
        public long levelId { get; set; }
        public string levelName { get; set; }
        public int levelOrder { get; set; }
        public string remark { get; set; }
    }
}
