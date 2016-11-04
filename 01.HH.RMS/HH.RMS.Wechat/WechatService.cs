using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Model;
using HH.RMS.Wechat.Interface;
using HH.RMS.Service.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HH.RMS.Wechat.Model;

namespace HH.RMS.Wechat
{
    public class WechatService
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ResultModel<WechatResponseModel> PostData(WechatRequestModel model)
        {
            try
            {
                string url = model.GetWechatUrl();
                if (string.IsNullOrEmpty(url))
                {
                    Config.log.Info("WechatService.PostToWechat:功能不存在("+model.wechatUrlType.ToString()+")");
                    return new ResultModel<WechatResponseModel>(ResultType.NotExists, "该功能不存在");
                }
                string result = NetHelper.Post(url,model.data);
                return new ResultModel<WechatResponseModel>(ResultType.Success, result, "Post数据成功");
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatService.PostToWechat", ex);
                return null;
            }
        }
        public ResultModel<WechatResponseModel> GetData(WechatRequestModel model)
        {
            try
            {
                string url = model.GetWechatUrl();
                if (string.IsNullOrEmpty(url))
                {
                    Config.log.Info("WechatService.PostToWechat:功能不存在(" + model.wechatUrlType.ToString() + ")");
                    return new ResultModel<WechatResponseModel>(ResultType.NotExists, "该功能不存在");
                }
                string accessToken = AccessTokenModel.Cache.accessToken;
                string result = string.Format(url, accessToken);
                return new ResultModel<WechatResponseModel>(ResultType.Success, result, "Get数据成功");
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatService.PostToWechat", ex);
                return null;
            }
        }
        public void GetOpenIdTest(string a, int b, DateTime date)
        {
            Thread.Sleep(10000);
            Config.log.Info("This is a Job Test:A:" + a + ";B:" + b+";DateTime:"+date);
            return;
 
        }
    }
}
