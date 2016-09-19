using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HH.RMS.Model
{
    public class AccountDetailModel
    {

        public AccountModel account { get; set; }
        public PersonModel person { get; set; }
        public RoleModel role { get; set; }

        public static AccountDetailModel loginSession
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
                        return (AccountDetailModel)value;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        
    }

    
}