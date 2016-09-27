using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Model;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Interface
{
    public interface IPersonService
    {
        GridModel QueryPersonToGrid(PagerModel pager);
        ResultModel<ResultType> CreatePersonAccount(AccountModel model);
        PersonModel QueryPersonById(long id);
        ResultType UpdatePersonById(PersonModel model);
    }
}
