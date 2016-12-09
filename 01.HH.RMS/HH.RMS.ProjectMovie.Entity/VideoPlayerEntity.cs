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
    [MappingTable(tableName = "VideoPlayer")]
    public class VideoPlayerEntity : EntityBase
    {
        public long videoId { get; set; }
        [MaxLength(50)]
        public string playerName { get; set; }
        public string description { get; set; }
        public PlayerType playerType { get; set; }
        [MaxLength(500)]
        public string url { get; set; }
    }
}
