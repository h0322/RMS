using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HH.RMS.Service.Web.Model
{
    public class AccountModel
    {
        public static AccountModel CurrentSession
        {
            get
            {
                var value = SessionHelper.GetSession(Config.loginSession);
                if (value == null)
                {
                    return null;
                }
                else
                {
                    try
                    {
                        return (AccountModel)value;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
        public long id { get; set; }
        [Required(ErrorMessage = "账号不能为空")]
        public string accountName { get; set; }
        [Required(ErrorMessage = "邮箱不能为空")]
        public string email { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string password { get; set; }
        public AccountStatusType status { get; set; }
        public decimal score { get; set; }
        public decimal amount { get; set; }
        public long roleBitMap { get; set; }
        public AccountType accountType { get; set; }
        public string remark { get; set; }
        public DateTime createTime { get; set; }
        public long createBy { get; set; }
        #region Level
        [Required(ErrorMessage = "等级为必选项")]
        public long levelId {get;set;}
        public string levelName { get; set; }
        public int levelOrder { get; set; }
        #endregion
        #region Person
        public long personId{get;set;}
        public string birthday{get;set;}
        public long cityId{get;set;}
        public long countryId{get;set;}
        public long provinceId{get;set;}
        public string name{get;set;}
        public string nickName{get;set;}
        public SexType sex{get;set;}
        #endregion
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static T ModelMapper<T>(object entity)
        {
            return TinyMapper.Map<T>(entity);
        }
        public static T EntityMapper<T>(object model)
        {
            return TinyMapper.Map<T>(model);
        }
    }
}