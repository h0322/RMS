using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Common.Attributes
{
    public class MappingTableAttribute : Attribute
    {
        public string tableName { get; set; }
    }
}
