using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
     [MappingTable(tableName = "SystemRole")]
    public class RoleEntity:EntityBase
    {
         [MaxLength(32)]
        public string roleName { get; set; }
         public long bitMap { get; set; }
        public int roleOrder { get; set; }
    }
}
