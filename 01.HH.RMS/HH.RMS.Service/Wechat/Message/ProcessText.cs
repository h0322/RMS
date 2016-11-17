using HH.RMS.Service.Wechat.Model;
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
        public override void Process(WechatPostModel model)
        {
            string content = model.content;
            List<WechatResponseMsgModel> list = new List<WechatResponseMsgModel>();
            ResponseMsg(list, model.from, model.to);
        }
        public override void ResponseMsg(List<WechatResponseMsgModel> model, string from, string to)
        {
            base.ResponseMsg(model, from, to);
        }
        public virtual void  SendMessage()
        {

        }
    }
}
