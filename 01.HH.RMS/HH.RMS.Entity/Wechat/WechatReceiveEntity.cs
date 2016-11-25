using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Wechat
{
    public class WechatReceiveEntity:EntityBase
    {
        [MaxLength(50)]
        public string toUserName { get; set; }
        [MaxLength(50)]
        public string fromUserName { get; set; }
        public int createTime { get; set; }
        [MaxLength(50)]
        public string msgType { get; set; }
        [MaxLength(500)]
        public string content { get; set; }
        [MaxLength(500)]
        public string picUrl { get; set; }
        [MaxLength(500)]
        public string mediaId { get; set; }
        [MaxLength(500)]
        public string thumbMediaId { get; set; }
        [MaxLength(100)]
        public string format { get; set; }
        public decimal locationX { get; set; }
        public decimal locationY { get; set; }
        [MaxLength(20)]
        public string scale { get; set; }
        [MaxLength(100)]
        public string label { get; set; }
        [MaxLength(100)]
        public string title { get; set; }
        [MaxLength(1000)]
        public string description { get; set; }
        [MaxLength(500)]
        public string url { get; set; }
        public long msgId { get; set; }
        [MaxLength(100)]
        public string eventKey { get; set; }
        [MaxLength(100)]
        public string eventType { get; set; }
        [MaxLength(100)]
        public string ticket { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        [MaxLength(50)]
        public string precision{get;set;}
    }
}
