using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Model;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat
{
    public class WechatService:ServiceBase,IWechatService
    {
        public ResultModel<WechatResponseModel> PostData(WechatRequestModel model)
        {
            try
            {
                string url = model.GetWechatUrl();
                if (string.IsNullOrEmpty(url))
                {
                    log.Info("WechatService.PostToWechat:功能不存在("+model.wechatUrlType.ToString()+")");
                    return new ResultModel<WechatResponseModel>(ResultType.NotExists, "该功能不存在");
                }
                string result = NetHelper.Post(url,model.data);
                return new ResultModel<WechatResponseModel>(ResultType.Success, result, "Post数据成功");
            }
            catch (Exception ex)
            {
                log.Error("WechatService.PostToWechat", ex);
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
                    log.Info("WechatService.PostToWechat:功能不存在(" + model.wechatUrlType.ToString() + ")");
                    return new ResultModel<WechatResponseModel>(ResultType.NotExists, "该功能不存在");
                }
                string accessToken = AccessTokenModel.Cache.accessToken;
                string result = string.Format(url, accessToken);
                return new ResultModel<WechatResponseModel>(ResultType.Success, result, "Get数据成功");
            }
            catch (Exception ex)
            {
                log.Error("WechatService.PostToWechat", ex);
                return null;
            }
        }
    }
}
