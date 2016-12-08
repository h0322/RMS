using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Movie
{
    public class VideoEntity:EntityBase
    {
        public string title { get; set; }
        public long tag { get; set; }
        public int year { get; set; }
        public string rating { get; set; }
        public int area { get; set; }
        public string description { get; set; }
        public VideoStatus status { get; set; }

    }
}
