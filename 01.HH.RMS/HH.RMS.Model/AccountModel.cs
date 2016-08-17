using HH.RMS.Common.Constant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HH.RMS.Model
{
    public class AccountListModel : PagerModel
    {
        public List<AccountModel> accountList { get; set; }
        
    }
    public class AccountModel
    {
        public long accountId { get; set; }
        public string accountName { get; set; }
        public string password { get; set; }
        public AccountStatusType statusType { get; set; }
        public decimal score { get; set; }
        public LevelType level { get; set; }
        public DateTime createTime { get; set; }
        public long createBy { get; set; }
        public PersonModel person { get; set; }
        public decimal amount { get; set; }
        public string remark { get; set; }
        public RoleType roleType { get; set; }
        public long[] roles { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}