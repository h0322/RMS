using HH.RMS.Wechat.Message;
using HH.RMS.Wechat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Wechat.Interface
{
    public interface IResponseMessageService
    {
        void Manager(string postString);
    }
}
