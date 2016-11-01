using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HH.RMS.MVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "账号不能为空")]
        public string accountName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        [RegularExpression(@"^\d{6,12}$", ErrorMessage = "密码位数要在6~12之间")]
        public string password { get; set; }
        public string redirectUrl { get; set; }
        public string validateCode { get; set; }
    }
}