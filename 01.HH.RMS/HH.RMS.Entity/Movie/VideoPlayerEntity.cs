using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Movie
{
    public class VideoPlayerEntity : EntityBase
    {
        public long videoId { get; set; }
        public PlayerType playerType { get; set; }
        public string url { get; set; }
    }
}
