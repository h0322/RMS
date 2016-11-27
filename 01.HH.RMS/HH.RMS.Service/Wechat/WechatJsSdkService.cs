using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Wechat;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace HH.RMS.Service.Wechat
{
    public class WechatJsSdkService : IWechatJsSdkService
    {
        public string GetJsSDKTicket()
        {
            string wechatUrl = string.Format(Config.getJsapiTicketUrl, AccessTokenModel.CurrentCache.accessToken);
            try
            {
                string result = NetHelper.Get(wechatUrl);
                return result;
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatJsSdkService.GetJsSDKTicket", ex);
                return null;
            }
        }
        public WechatJsSdkModel GetJsSDK(string url)
        {
            string getJsSDKTicket = GetJsSDKTicket();
            if (getJsSDKTicket == null)
            {
                return null;
            }
            string ticket = "";
            JObject jsonObj = JsonConvert.DeserializeObject<JObject>(GetJsSDKTicket());
            if (jsonObj["ticket"] != null)
            {
                ticket = jsonObj["ticket"].ToString();
            }
            WechatJsSdkModel model = new WechatJsSdkModel();
            model.appId = WechatConfigModel.CurrentCache.appId;
            model.nonceStr = Guid.NewGuid().ToString("N");
            model.timestamp = DateTime.Now.Ticks.ToString();
            //jsapi_ticket=sM4AOVdWfPE4DxkXGEs8VMCPGGVi4C3VM0P37wVUCFvkVAy_90u5h9nbSlYy3-Sl-HhTdfl2fzFy1AOcHKP7qg&noncestr=Wm3WZYTPz0wzccnW&timestamp=1414587457&url=http://mp.weixin.qq.com?params=value
            string str = "jsapi_ticket=" + ticket + "&noncestr=" + model.nonceStr + "&timestamp=" + model.timestamp + "&url="+url;
            model.signature = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1").ToLower();
            return model;
        }
    }
}
