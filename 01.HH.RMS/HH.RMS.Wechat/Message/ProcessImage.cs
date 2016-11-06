using HH.RMS.Service.Wechat.Model;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Wechat.Message
{
    public class ProcessImage : BaseProcess
    {
        public ProcessImage()

        { }
        public override void Process(WechatPostModel model)
        {
            throw new NotImplementedException();
        }
        public override void ResponseMsg(List<WechatResponseMsgModel> model, string from, string to)
        {
            throw new NotImplementedException();
        }
    }
}
