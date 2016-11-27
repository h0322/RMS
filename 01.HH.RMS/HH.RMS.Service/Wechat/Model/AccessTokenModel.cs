using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Wechat.Model;
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
        public static AccessTokenModel CurrentCache
        {
            get {
                if (CacheHelper.GetCache(Config.accessTokenCache) != null)
                {
                    var model = (AccessTokenModel)CacheHelper.GetCache(Config.accessTokenCache);
                    if (DateTime.Now < model.createTime.AddSeconds(CurrentCache.expires - Config.accessTokenRemainSecond))
                    { 
                        return (AccessTokenModel)CacheHelper.GetCache(Config.accessTokenCache);
                    }
                }
                IWechatConfigService service = UnityManager.instance.GetService<IWechatConfigService>();
                var result = service.GetAccessToken();
                CacheHelper.SetCache(Config.accessTokenCache, result.resultObj, TimeSpan.FromSeconds(result.resultObj.expires - Config.accessTokenRemainSecond));
                return result.resultObj;
            }
        }
        [JsonProperty(PropertyName = "access_token")]
        public string accessToken { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public int expires { get; set; }
        public DateTime createTime { get; set; }
    }
}
