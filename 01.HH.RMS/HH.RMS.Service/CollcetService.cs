﻿using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.IService;
using HH.RMS.IService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service
{
    public class CollcetService : ICollcetService
    {
        public ResultType CollcetMessage(CollectModel model)
        {
            try
            {
                string result = NetHelper.GetHtmlPage(model.url);
                QueryString.GetStringRange(result, model.fromString, model.toString);
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("CollcetService.CollcetMessage", ex);
                return ResultType.SystemError;
            }
        }
    }
}
