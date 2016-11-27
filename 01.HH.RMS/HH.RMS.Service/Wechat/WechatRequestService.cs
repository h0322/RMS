using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Model;
using HH.RMS.Service.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HH.RMS.Wechat.Model;
using HH.RMS.Service.Wechat.Interface;

namespace HH.RMS.Service.Wechat
{
    public class WechatRequestService : IWechatRequestService
    {
        public ResultModel<string> PostData(WechatRequestModel model)
        {
            try
            {
                string result = NetHelper.Post(model.url, model.data);
                return new ResultModel<string>(ResultType.SystemError, result, "", "");
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatRequestService.PostData", ex);
                return new ResultModel<string>(ResultType.SystemError, null,"","");
            }
        }
        public ResultModel<string> GetData(WechatRequestModel model)
        {
            try
            {
                string result = NetHelper.Get(model.url);
                return new ResultModel<string>(ResultType.SystemError, result, "", "");
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatRequestService.PostData", ex);
                return new ResultModel<string>(ResultType.SystemError, null, "", "");
            }
        }
    }
}
