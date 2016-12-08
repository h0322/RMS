using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Movie
{
    public class VideoImageEntity:EntityBase
    {
        public string title { get; set; }
        public long videoId { get; set; }
        public string url { get; set; }
        public bool isCover { get; set; }
    }
}
