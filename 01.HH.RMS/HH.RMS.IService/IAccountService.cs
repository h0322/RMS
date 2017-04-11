using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.IService.Model;
using HH.RMS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HH.RMS.IService
{
    public interface IAccountService
    {
         ResultType InsertAccount(AccountModel model);
         AccountModel QueryAccountById(long id);
         ResultType UpdateAccountById(AccountModel model);
         ResultType DeleteAccountById(long id);
         ResultType DeleteAccountMassById(long[] ids);
         int CountAccount();
         
    }
}
