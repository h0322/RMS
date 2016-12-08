using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
   [MappingTable(tableName = "ResetPasswordLog")]
    public class ResetPasswordLogEntity:EntityBase
    {
        public long accountId { get; set; }
        public string password { get; set; }
    }
}
