using HH.ProjectMovie.Common;
using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Service.Model
{
    public class VideoPlayerModel
    {
        public long videoId { get; set; }
        public string code { get; set; }
        public string playerName { get; set; }
        public string description { get; set; }
        public PlayerType playerType { get; set; }
        public string url { get; set; }
    }
}
