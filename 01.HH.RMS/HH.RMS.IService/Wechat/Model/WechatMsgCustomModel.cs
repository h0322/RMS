using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Wechat.Model
{
    public class WechatMsgCustomModel
    {
        public string touser { get; set; }
         [JsonProperty(PropertyName = "msgtype")]
        public string msgType { get; set; }
         public override string ToString()
         {
             return JsonConvert.SerializeObject(this);
         }
    }
    public class WechatMsgCustomTextModel : WechatMsgCustomModel
    {
        public WechatMsgCustomTextDetailModel text { get; set; }
    }
    public class WechatMsgCustomImageModel : WechatMsgCustomModel
    {
        public WechatMsgCustomMediaModel image { get; set; }
    }

    public class WechatMsgCustomVoiceModel : WechatMsgCustomModel
    {
        public WechatMsgCustomMediaModel voice { get; set; }
    }
    public class WechatMsgCustomVideoModel : WechatMsgCustomModel
    {
        public WechatMsgCustomVideoDetailModel video { get; set; }
    }
    public class WechatMsgCustomMusicModel : WechatMsgCustomModel
    {
        public WechatMsgCustomMusicDetailModel music { get; set; }
    }
    public class WechatMsgCustomNewsModel : WechatMsgCustomModel
    {
        public WechatMsgCustomNewsArticleModel news { get; set; }
    }
    public class WechatMsgCustomSingleNewsModel : WechatMsgCustomModel
    {
        public WechatMsgCustomMediaModel mpnews { get; set; }
    }
    public class WechatMsgCustomCardDetailModel
    {
        public string cardId { get; set; }
        public string cardExt { get; set; }
    }

    public class WechatMsgCustomListModel
    {
        public List<string> kfAccount { get; set; }
    }
    public class WechatMsgCustomNewsArticleModel
    {
        public List<WechatMsgCustomNewsDetailModel> articles { get; set; }
    }
    public class WechatMsgCustomNewsDetailModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string picUrl { get; set; }
    }
    public class WechatMsgCustomMusicDetailModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string musicUrl { get; set; }
        public string hqMusicUrl { get; set; }
        public string thumbMediaId { get; set; }
    }

    public class WechatMsgCustomVideoDetailModel
    {
        public string mediaId { get; set; }
        public string thumbMediaId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
    public class WechatMsgCustomMediaModel
    {
        public string mediaId { get; set; }
    }
    public class WechatMsgCustomTextDetailModel
    {
        public string content { get; set; }
    }
}
