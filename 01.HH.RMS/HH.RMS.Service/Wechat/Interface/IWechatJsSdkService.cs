﻿using HH.RMS.Service.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat.Interface
{
    public interface IWechatJsSdkService
    {
        WechatJsSdkModel GetJsSDK(string url);
    }
}