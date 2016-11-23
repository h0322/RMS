using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat
{
    public class WechatUserService : IWechatUserService
    {
        public WechatUserModel GetWechatUserByOpenId(string openId, string lang = "zh_CN")
        {
            string wechatUrl = string.Format(Config.getDetailUserInfoUrl, AccessTokenModel.CurrentCache.accessToken, openId, lang);
            try
            {
                string result = NetHelper.Get(wechatUrl);
                WechatUserModel model = JsonConvert.DeserializeObject<WechatUserModel>(result);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
