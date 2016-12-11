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
    [MappingTable(tableName = "AreaTag")]
    public class AreaTagEntity : EntityBase
    {
        [MaxLength(50)]
        public string tagName { get; set; }
        public string description { get; set; }
        public decimal tagNum { get; set; }
    }
}
