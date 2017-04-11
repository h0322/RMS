using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    [MappingTable(tableName = "AccountLevel")]
    public class LevelEntity:EntityBase
    {
        [MaxLength(100)]
        public string levelName { get; set; }
        public int levelOrder { get; set; }

    }
}
