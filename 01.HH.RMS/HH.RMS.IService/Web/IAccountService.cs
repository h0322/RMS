﻿using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.IService.Web.Model;
using HH.RMS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HH.RMS.IService.Web
{
    public interface IAccountService
    {
         ResultType InsertAccount(AccountModel model);
         GridModel QueryAccountToGridByRole(PagerModel pager = null);
         AccountModel QueryAccountById(long id);
         ResultType UpdateAccountById(AccountModel model);
         ResultType DeleteAccountById(long id);
         ResultType DeleteAccountMassById(long[] ids);
         int CountAccount();
         
    }
}
