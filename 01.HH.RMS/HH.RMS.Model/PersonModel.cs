using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Model
{
    public class PersonListModel : PagerModel
    {
        public List<PersonModel> personList { get; set; }
    }
    public class PersonModel
    {
        public long personId { get; set; }
        public string name { get; set; }
        public string nickName { get; set; }
        public long provinceId { get; set; }
        public string provinceName { get; set; }
        public long cityId { get; set; }
        public string cityName { get; set; }
        public long countryId { get; set; }
        public string countryDescription { get; set; }
        public string address { get; set; }
        public string birthday { get; set; }
        public SexType sex { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public DateTime createTime { get; set; }
        public long createBy { get; set; }
        public List<AccountModel> accountList { get; set; }
        public string remark { get; set; }
    }
}
