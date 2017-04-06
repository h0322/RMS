using HH.RMS.Common.Constant;
using HH.RMS.IService.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Web
{
    public interface ICollcetService
    {
        ResultType CollcetMessage(CollectModel model);
    }
}
