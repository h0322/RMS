using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat
{
    public class WechatMessageService
    {
    }
    public class WechatMessageManager
    {
        public void WechatMessageConstruct(MessageFactory builder)
        {
            builder.ProcessText();
            builder.ProcessImage();
            builder.ProcessLocation();
            builder.ProcessLink();
            builder.ProcessEvent();
            builder.ProcessVoice();
            builder.ProcessVideo();
        }
        
    }
    public abstract class MessageFactory
    {

        public abstract void ProcessText();
        public abstract void ProcessImage();
        public abstract void ProcessLocation();
        public abstract void ProcessLink();
        public abstract void ProcessEvent();
        public abstract void ProcessVoice();
        public abstract void ProcessVideo();
    }
}
