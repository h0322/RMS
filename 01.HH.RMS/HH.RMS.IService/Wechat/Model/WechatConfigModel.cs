using HH.RMS.Common.Constant;
using HH.RMS.Common.Unity;
using HH.RMS.Common.Utilities;
using HH.RMS.IService.Wechat;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Wechat
{
    public class WechatConfigModel
    {
        public static WechatConfigModel CurrentCache
        {
            get
            {
                if (CacheHelper.GetCache(Config.accessTokenCache) != null)
                {
                    return (WechatConfigModel)CacheHelper.GetCache(Config.accessTokenCache);
                }
                IWechatConfigService service = UnityManager.instance.GetService<IWechatConfigService>();
                var result = service.QueryWechatConfig();
                CacheHelper.SetCache(Config.accessTokenCache, result);
                return result;
                
            }
        }
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string openId { get; set; }
        public string appId { get; set; }
        public string appName { get; set; }
        public string appSecret { get; set; }
        public string accessToken { get; set; }
        public string token { get; set; }
        public string security { get; set; }
        public string ticket { get; set; }
        public string componentName { get; set; }
        public string componentAppId { get; set; }
        public string componentAppSecret { get; set; }
        public string componentAccessToken { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public static T ModelMapper<T>(object entity)
        {
            return TinyMapper.Map<T>(entity);
        }
        public static T EntityMapper<T>(object model)
        {
            return TinyMapper.Map<T>(model);
        }
    }
}
