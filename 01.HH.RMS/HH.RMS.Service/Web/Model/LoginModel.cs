using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HH.RMS.MVC.Models
{
    public class LoginModel
    {
        public string accountName { get; set; }
        public string password { get; set; }
        public string redirectUrl { get; set; }
        public string validateCode { get; set; }
    }
}