using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    [MappingTable(tableName = "AccountLevel")]
    public class LevelEntity:EntityBase
    {
        
        public string levelName { get; set; }
        public int levelOrder { get; set; }

    }
}
