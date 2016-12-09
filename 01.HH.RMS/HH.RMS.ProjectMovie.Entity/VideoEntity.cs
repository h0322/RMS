using HH.ProjectMovie.Common;
using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Entity
{
    public class VideoEntity:EntityBase
    {
        [MaxLength(100)]
        public string title { get; set; }
        public long tag { get; set; }
        [MaxLength(1000)]
        public string actor { get; set; }
        [MaxLength(1000)]
        public string dirctor { get; set; }
        public int year { get; set; }
        [MaxLength(1000)]
        public string rating { get; set; }
        public int area { get; set; }
        public string description { get; set; }
        public VideoStatus status { get; set; }
        public decimal score { get; set; }
        public decimal star { get; set; }
    }
}
