using HH.ProjectMovie.Common;
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
    [MappingTable(tableName = "FilmMan")]
    public class FilmManEntity:EntityBase
    {
        [MaxLength(50)]
        public string name { get; set; }
        public string description { get; set; }
        public FilmManType type { get; set; }
        public long country { get; set; }
        public long province { get; set; }
        public long city { get; set; }
        [MaxLength(500)]
        public string url { get; set; }
    }
}
