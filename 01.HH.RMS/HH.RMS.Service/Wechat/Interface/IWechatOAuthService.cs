using HH.RMS.Common.Constant;
using HH.RMS.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat.Interface
{
    public interface IWechatOAuthService
    {
        void RedirectCodeUrl(string redirectUrl, WechatScopeType scopeType, string state = "");
        ResultModel<string> GetOAuthByCode(string code);
        ResultModel<string> GetUserInfoByOAuth(string token, string openId);
    }
}
