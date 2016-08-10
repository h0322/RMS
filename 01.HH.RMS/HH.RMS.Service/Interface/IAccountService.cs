using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Model;
using HH.RMS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Interface
{
    public interface IAccountService
    {
         ResultType InsertAccount(AccountModel model);
         GridModel QueryAccountToGridByRole(PagerModel pager = null);
         AccountListModel QueryAccountListByPersonId(long id);
         AccountModel QueryAccountById(long id);
         ResultType UpdateAccount(AccountModel model);
         ResultType DeleteAccountById(long id);
         ResultType DeleteAccountMassById(List<string> idList);
         int CountAccount();
         
    }
}
