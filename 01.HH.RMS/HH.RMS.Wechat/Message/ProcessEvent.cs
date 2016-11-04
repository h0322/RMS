using HH.RMS.Service.Wechat.Model;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Wechat.Message
{
    public class ProcessEvent : ProcessAdaptor
    {
        public ProcessEvent()
       { }
        public override void Process(WechatPostModel model)
        {
            List<WechatResponseMsgModel> list =new List<WechatResponseMsgModel>();
            ResponseMsg(list, "", "");
        }
    }
}
