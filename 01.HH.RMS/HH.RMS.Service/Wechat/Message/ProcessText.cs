using HH.RMS.IService.Wechat.Model;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Wechat.Message
{
    public class ProcessText : BaseProcess
    {
        public ProcessText()
        { }
        public override void Process(WechatReceiveModel model)
        {
            string content = model.content;
            List<WechatResponseMsgModel> list = new List<WechatResponseMsgModel>();
            ResponseMsg(list, model.fromUserName, model.toUserName);
        }
        public override void ResponseMsg(List<WechatResponseMsgModel> model, string fromUserName, string toUserName)
        {
            base.ResponseMsg(model, fromUserName, toUserName);
        }
        public virtual void  SendMessage()
        {

        }
    }
}
