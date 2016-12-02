using HH.RMS.Common.Constant;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Interface
{
    public interface IMessageService
    {
        ResultType InsertMessage(MessageModel model);
        GridModel QueryMessageToGrid(PagerModel pager);
        MessageModel QueryMessageById(long id);
    }
}
