using HH.ProjectMovie.Common;
using HH.RMS.Common.Attributes;
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
    [MappingTable(tableName = "Video")]
    public class VideoEntity : EntityBase
    {
        [MaxLength(100)]
        public string title { get; set; }
        [MaxLength(500)]
        public string otherTitle { get; set; }
        public decimal videoTag { get; set; }
        [MaxLength(1000)]
        public string actor { get; set; }
        [MaxLength(1000)]
        public string dirctor { get; set; }
        public int year { get; set; }
        [MaxLength(500)]
        public string cover { get; set; }
        public decimal rating { get; set; }
        public decimal areaTag { get; set; }
        public string description { get; set; }
        public VideoStatus status { get; set; }
        public decimal score { get; set; }
        public decimal star { get; set; }
    }
}
