﻿using HH.RMS.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Interface
{
    public interface ILoginService
    {
        ResultModel<AccountModel> UserLogin(string accountName, string password);
        void ExitLogin();
    }
}
