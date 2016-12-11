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
    [MappingTable(tableName = "FilmManImage")]
    public class FilmManImageEntity : EntityBase
    {
        [MaxLength(100)]
        public string title { get; set; }
        public string description { get; set; }
        public long acotrId { get; set; }
        [MaxLength(500)]
        public string url { get; set; }
        public bool isCover { get; set; }
    }
}
