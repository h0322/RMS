using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    [MappingTable(tableName = "SystemAccountRole")]
    public class AccountRoleEntity:EntityBase
    {
        public long accountId { get; set; }
        public long roleId { get; set; }
        [ForeignKey("accountId")]
        public virtual AccountEntity account { get; set; }
        [ForeignKey("roleId")]
        public virtual RoleEntity role { get; set; }
    }
}
