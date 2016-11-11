﻿using HH.RMS.Service.Wechat.Model;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Wechat.Message
{
    public abstract class BaseProcess
    {
        public abstract void Process(WechatPostModel model);
        public virtual void ResponseMsg(List<WechatResponseMsgModel> model, string from, string to)
        {

        }
    }
}