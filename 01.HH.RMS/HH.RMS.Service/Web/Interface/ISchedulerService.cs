using HH.RMS.Service.Web.Model;
using HH.RMS.Entity;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.Service.Model;

namespace HH.RMS.Service.Web.Interface
{
    public interface ISchedulerService
    {
        List<SchedulerEntity> QuerySchedulerAll();
        ResultModel<SchedulerEntity> QuerySchedulerById(long schedulerId);
    }
}
