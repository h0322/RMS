using HH.RMS.Common.Constant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat.Model
{
    public class WechatUserModel
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
}
