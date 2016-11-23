﻿using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat.Interface
{
    public interface IWechatQRCodeService
    {
        string GetQRCodeUrl();
        ResultType SaveQRCode(string filePath);
    }
}
