using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Wechat.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat.Model
{
    public class AccessTokenModel
    {
        public static AccessTokenModel Cache
        {
            get {
                int remainSecond = 1000;
                if (AccessTokenModel.Cache == null)
                {
                    IAccessTokenService service = UnityManager.instance.GetService<IAccessTokenService>();
                    var result = service.GetAccessToken(new WechatRequestModel() { appId = Config.wechatAppId, appSecret = Config.wechatAppSecret, wechatUrlType = WechatUrlType.GetAccessToken });
                    CacheHelper.SetCache(Config.accessTokenCache, result.resultObj, TimeSpan.FromSeconds(result.resultObj.expires - remainSecond));
                    return result.resultObj;
                }
                AccessTokenModel model = new AccessTokenModel();
                model = (AccessTokenModel)AccessTokenModel.Cache;
                if (DateTime.Now > model.createTime.AddSeconds(model.expires - remainSecond))
                {
                    IAccessTokenService service = UnityManager.instance.GetService<IAccessTokenService>();
                    var result = service.GetAccessToken(new WechatRequestModel() { appId = Config.wechatAppId, appSecret = Config.wechatAppSecret, wechatUrlType = WechatUrlType.GetAccessToken });
                    CacheHelper.SetCache(Config.accessTokenCache, result.resultObj, TimeSpan.FromSeconds(result.resultObj.expires - remainSecond));
                    return result.resultObj;
                }
                return model;
            }
        }
        [JsonProperty(PropertyName = "access_token")]
        public string accessToken { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public int expires { get; set; }
        public DateTime createTime { get; set; }
    }
}
