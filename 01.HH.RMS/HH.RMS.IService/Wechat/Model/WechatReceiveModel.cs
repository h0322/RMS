using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HH.RMS.IService.Wechat.Model
{
    public class WechatReceiveModel
    {
        public string signature { get; set; }
        public string timestamp { get; set; }
        public string nonce { get; set; }
        public string echostr { get; set; }
        public string toUserName { get; set; }
        public string fromUserName { get; set; }
        public int createTime { get; set; }
        public string msgType { get; set; }
        public string content { get; set; }
        public string picUrl { get; set; }
        public string mediaId { get; set; }
        public string thumbMediaId { get; set; }
        public string format { get; set; }
        public decimal locationX { get; set; }
        public decimal locationY { get; set; }
        public string scale { get; set; }
        public string label { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public long msgId { get; set; }
        public string eventKey { get; set; }
        [XmlElement(ElementName = "Event")]
        public string eventType { get; set; }
        public string ticket { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string precision{get;set;}

        public string ToSign()
        {
            return AccessTokenModel.CurrentCache.accessToken+timestamp+nonce;
        }
        public string ToXML()
        { return "";}
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
