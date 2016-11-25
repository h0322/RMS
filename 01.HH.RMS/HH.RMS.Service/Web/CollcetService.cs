using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web
{
    public class CollcetService : ICollcetService
    {
        public ResultType CollcetMessage(CollectModel model)
        {
            try
            {
                string result = NetHelper.GetHtmlPage(model.url);
                QueryString.GetString(result, "<p><b>", "</b></p>");
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                return ResultType.SystemError;
            }
        }
    }
}
