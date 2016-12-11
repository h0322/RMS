using HH.RMS.Common.Attributes;
using HH.RMS.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Entity
{
    [MappingTable(tableName = "VideoImage")]
    public class VideoImageEntity:EntityBase
    {
        [MaxLength(50)]
        public string title { get; set; }
        public long videoId { get; set; }
        public string description { get; set; }
       [MaxLength(500)]
        public string url { get; set; }
        public bool isCover { get; set; }
    }
}
