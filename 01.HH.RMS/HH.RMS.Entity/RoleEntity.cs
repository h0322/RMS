using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
     [MappingTable(tableName = "SystemRole")]
    public class RoleEntity:EntityBase
    {
        public string roleName { get; set; }
        public RoleType roleType { get; set; }
        public int roleOrder { get; set; }
        public virtual ICollection<AccountEntity> accountList { get; set; }
    }
}
