using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat.Model
{
    public class WechatMsgMassModel
    {
        public string[] touser { get; set; }
        [JsonProperty(PropertyName="msgtype")]
        public string msgType { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class WechatMsgMassNewsModel : WechatMsgMassModel
    {
        public WechatMsgMassMediaModel mpNews { get; set; }
    }
    public class WechatMsgMassTextModel : WechatMsgMassModel
    {
        public WechatMsgMassTextDetailModel text { get; set; }
    }
    public class WechatMsgMassVoiceModel : WechatMsgMassModel
    {
        public WechatMsgMassMediaModel voice { get; set; }
    }
    public class WechatMsgMassImageModel : WechatMsgMassModel
    {
        public WechatMsgMassMediaModel image { get; set; }
    }
    public class WechatMsgMassVideoModel : WechatMsgMassModel
    {
        public WechatMsgMassVideoDetailModel video { get; set; }
    }
    public class WechatMsgMassCardModel : WechatMsgMassModel
    {
        public WechatMsgMassCardDetailModel wxCard { get; set; }
    }

    public class WechatMsgMassVideoDetailModel
    {
        public string mediaId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
    public class WechatMsgMassMediaModel
    {
        public string mediaId { get; set; }
    }
    public class WechatMsgMassCardDetailModel
    {
        public string cardId { get; set; }
    }
    public class WechatMsgMassTextDetailModel
    {
        public string content { get; set; }
    }
}
