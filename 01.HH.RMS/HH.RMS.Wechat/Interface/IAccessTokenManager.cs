﻿using HH.RMS.Common.Constant;
using HH.RMS.Service.Model;
using HH.RMS.Service.Wechat.Model;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Wechat.Interface
{
    public interface IAccessTokenManager
    {
        ResultModel<AccessTokenModel> GetAccessToken(WechatRequestModel model);
    }
}