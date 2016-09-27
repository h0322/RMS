using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Model;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat
{
    public class AccessTokenService :ServiceBase, IAccessTokenService
    {
        public ResultModel<AccessTokenModel> GetAccessToken(WechatRequestModel model)
        {
            try
            {
                string url = model.GetWechatUrl();
                if (url == null)
                {
                    return new ResultModel<AccessTokenModel>(ResultType.NotExists, "该功能不存在");
                }
                string wechatUrl = string.Format(url, model.appId, model.appSecret);
                string result = NetHelper.Get(wechatUrl);
                if (string.IsNullOrEmpty(result))
                {
                    return new ResultModel<AccessTokenModel>(ResultType.Fail, "微信访问失败");
                }
                AccessTokenModel accessToken = JsonConvert.DeserializeObject<AccessTokenModel>(result);
                return new ResultModel<AccessTokenModel>(ResultType.Success, accessToken);
            }
            catch (Exception ex)
            {
                log.Error("AccessTokenService.GetAccessToken", ex);
                return null;
            }
            //model.GetWechatUrl
        }
    }
}
