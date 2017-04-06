using HH.RMS.IService.Wechat.Model;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Wechat.Message
{
    public class ProcessEvent : BaseProcess
    {
        public ProcessEvent()
       { }
        public override void Process(WechatReceiveModel model)
        {
            List<WechatResponseMsgModel> list =new List<WechatResponseMsgModel>();
            ResponseMsg(list, "", "");
        }
    }
}
