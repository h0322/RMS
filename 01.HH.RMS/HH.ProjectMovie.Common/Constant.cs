using HH.RMS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Common
{
    public class Constant
    {
        public readonly static  string movieInterfaceAppKey = ConfigHelper.GetConfigString("MovieAppKey");
        public const string movieInterfaceUrl = "http://op.juhe.cn/onebox/movie/video?key={0}&q={1}";
        public const string movieInterfaceRecentUrl = "http://op.juhe.cn/onebox/movie/pmovie?key={0}&city={1}";
    }
}
