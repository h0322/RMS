using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    [MappingTable(tableName="person")]
    public class PersonEntity : EntityBase
    {

        public string name { get; set; }
        public string nickName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public SexType sex { get; set; }
        public string birthday { get; set; }
        public long country { get; set; }
        public long privonce { get; set; }
        public long city { get; set; }
    }
}
