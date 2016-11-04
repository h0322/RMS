using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HH.RMS.Wechat.Model
{
    [XmlRoot(ElementName = "xml")]
    public class WechatPostModel
    {
        [XmlElement(ElementName = "ToUserName")]
        public string to { get; set; }
        [XmlElement(ElementName = "FromUserName")]
        public string from { get; set; }
        [XmlElement(ElementName = "CreateTime")]
        public string createTime { get; set; }
        [XmlElement(ElementName = "MsgType")]
        public string msgType { get; set; }
        [XmlElement(ElementName = "Event")]
        public string eventString { get; set; }
        [XmlElement(ElementName = "EventKey")]
        public string eventKey { get; set; }
        [XmlElement(ElementName = "Ticket")]
        public string ticket { get; set; }
        [XmlElement(ElementName = "Content")]
        public string content { get; set; }
        [XmlElement(ElementName = "MsgId")]
        public string msgId { get; set; }
    }
}
