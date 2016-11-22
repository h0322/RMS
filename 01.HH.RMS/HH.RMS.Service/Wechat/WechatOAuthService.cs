using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Wechat;
using HH.RMS.Service.Model;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat.Model;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HH.RMS.Service.Wechat
{
    public class WechatOAuthService : IWechatOAuthService
    {

        public void RedirectCodeUrl(string redirectUrl,WechatScopeType scopeType,string state="")
        {
            string scope = "";
            switch (scopeType)
            {
                case WechatScopeType.Base:
                    scope = "snsapi_base";
                    break;
                case WechatScopeType.UserInfo:
                    scope = "snsapi_userinfo";
                    break;
            }
            string wechatUrl = string.Format(Config.getAuthorizeUrl, WechatConfigModel.CurrentCache.appId, scope, state);
            HttpContext.Current.Response.Redirect(wechatUrl);
            return;
        }
        public ResultModel<string> GetOAuthByCode(string code)
        {
            string wechatUrl = string.Format(Config.getAccessTokenByCodeUrl, WechatConfigModel.CurrentCache.appId, WechatConfigModel.CurrentCache.appSecret, code);
            try
            {
                string result = NetHelper.Get(wechatUrl);
                return new ResultModel<string>(ResultType.Success, result,"","");
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatOAuthService.GetOAuthByCode", ex);
                return new ResultModel<string>(ResultType.SystemError, "系统出错", "");
            }
        }
        public ResultModel<string> GetUserInfoByOAuth(string token, string openId)
        {
            string wechatUrl = string.Format(Config.getUserinfoUrl, token, openId);
            try
            {
                string result = NetHelper.Get(wechatUrl);
                return new ResultModel<string>(ResultType.Success, result, "", "");
            }
            catch (Exception ex)
            {
                Config.log.Error("WechatOAuthService.GetUserInfoByOAuth", ex);
                return new ResultModel<string>(ResultType.SystemError, "系统出错", "");
            }
        }
    }
}
