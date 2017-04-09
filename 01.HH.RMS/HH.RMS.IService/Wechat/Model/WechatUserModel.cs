using HH.RMS.Common.Constant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Wechat.Model
{
    public class WechatUserResponseModel
    {
        public WechatSubscribeType subscribe { get; set; }
        public string openId { get; set; }
        public string nickname { get; set; }
        public SexType sex { get; set; }
        public string language { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        [JsonProperty(PropertyName = "subscribe_time")]
        public string subscribeTime { get; set; }
        public string unionid { get; set; }
        public string remark { get; set; }
        public int groupId { get; set; }
    }
    public class WechatUserRequestModel
    {
        public string openId { get; set; }
        public string lang { get; set; }
    }
    public class WechatOpenIdListResponseModel
    {
        public int total { get; set; }
        public int count { get; set; }
        public OpenIdListModel data { get; set; }

        [JsonProperty("next_openid")]
        public string nextOpenId { get; set; }
    }
    public class OpenIdListModel
    {
        [JsonProperty("openid")]
        public List<string> openIdList { get; set; }
    }
}
