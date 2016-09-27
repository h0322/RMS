using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Web
{
    [MappingTable(tableName = "Account")]
    public class AccountEntity : EntityBase
    {
        [MaxLength(32)]
        public string accountName { get; set; }
        [MaxLength(32)]
        public string password { get; set; }
        public long personId { get; set; }
        [ForeignKey("personId")]
        public virtual PersonEntity person { get; set; }
        public decimal amount { get; set; }
        public decimal score { get; set; }
        public long levelId { get; set; }
        public AccountStatusType status { get; set; }
        [ForeignKey("levelId")]
        public virtual LevelEntity level { get; set; }
    }
}
