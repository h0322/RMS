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
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ResultModel<string> PostData(WechatRequestModel model)
        {
            return null;
            //try
            //{
            //    if (string.IsNullOrEmpty(model.url))
            //    {
            //        Config.log.Info("WechatService.PostToWechat:功能不存在("+model.data+")");
            //        return new ResultModel<string>(ResultType.NotExists, "Url 为空","");
            //    }
            //    string result = NetHelper.Post(model.url, model.data);
            //    return new ResultModel<string>(ResultType.Success, result, "Post数据成功","");
            //}
            //catch (Exception ex)
            //{
            //    Config.log.Error("WechatService.PostToWechat", ex);
            //    return new ResultModel<string>(ResultType.SystemError, "", ex.Message);
            //}
        }
        public ResultModel<string> GetData(WechatRequestModel model)
        {
            return null;
            //try
            //{
            //    string url = model.GetWechatUrl();
            //    if (string.IsNullOrEmpty(url))
            //    {
            //        Config.log.Info("WechatService.PostToWechat:功能不存在(" + model.wechatUrlType.ToString() + ")");
            //        return new ResultModel<string>(ResultType.NotExists, "该功能不存在","");
            //    }
            //    string result = NetHelper.Get(url);
            //    return new ResultModel<string>(ResultType.Success, result, "Get数据成功","");
            //}
            //catch (Exception ex)
            //{
            //    Config.log.Error("WechatService.PostToWechat", ex);
            //    return new ResultModel<string>(ResultType.SystemError,  ex.Message,"");
            //}
        }
        public void GetOpenIdTest(string a, int b, DateTime date)
        {
            Thread.Sleep(10000);
            Config.log.Info("This is a Job Test:A:" + a + ";B:" + b+";DateTime:"+date);
            return;
 
        }
    }
}
