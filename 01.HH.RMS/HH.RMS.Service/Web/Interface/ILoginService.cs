﻿using HH.RMS.Service.Model;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Interface
{
    public interface ILoginService
    {
        ResultModel<AccountModel> UserLogin(string accountName, string password);
        void ExitLogin();
    }
}