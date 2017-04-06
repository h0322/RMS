using HH.RMS.Common.Constant;
using HH.RMS.Common.Model;
using HH.RMS.Entity.Web;
using HH.RMS.IService.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Web
{
    public interface IPersonService
    {
        GridModel QueryPersonToGrid(PagerModel pager=null);
        ResultModel<ResultType> CreatePersonAccount(AccountModel model);
        PersonModel QueryPersonById(long id);
        ResultType UpdatePersonById(PersonModel model);
    }
}
