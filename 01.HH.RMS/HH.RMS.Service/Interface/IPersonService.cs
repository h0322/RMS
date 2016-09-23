using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Interface
{
    public interface IPersonService
    {
        GridModel QueryPersonToGrid(PagerModel pager);
        ResultModel<ResultType> CreatePersonAccount(AccountModel model);
        PersonModel QueryPersonById(long id);
        ResultType UpdatePersonById(PersonModel model);
    }
}
