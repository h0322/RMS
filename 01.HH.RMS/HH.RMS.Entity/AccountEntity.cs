using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    //[MappingTable(tableName = "Account")]
    public class AccountEntity : EntityBase
    {
        [MaxLength(50)]
        public string accountName { get; set; }
        [MaxLength(32)]
        public string password { get; set; }
        [MaxLength(50)]
        public string nickName { get; set; }
        public string name { get; set; }
        [MaxLength(50)]
        public string email { get; set; }
        [MaxLength(20)]
        public string mobile { get; set; }
        public DateTime birthday { get; set; }
        public long countryId { get; set; }
        public long provinceId { get; set; }
        public long cityId { get; set; }
        [MaxLength(100)]
        public string address { get; set; }
        public SexType sex { get; set; }
        public decimal amount { get; set; }
        public decimal score { get; set; }
        public long levelId { get; set; }
        public long roleBitMap { get; set; }
        public AccountType accountType { get; set; }
        public PasswordType passwordType { get; set; }
        public AccountStatusType status { get; set; }
        public long parentAccountId { get; set; }

    }
}
