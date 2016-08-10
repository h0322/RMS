using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Common.Attributes
{
    public class EntityObjectAttribute : Attribute
    {
        public string value { get; set; }
        public ObjectType type { get; set; }
    }
}
