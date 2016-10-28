using HH.RMS.Service.Web.Model;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.Service.Model;
using HH.RMS.Entity.Scheduler;
using HH.RMS.Service.Scheduler.Model;
using HH.RMS.Common.Constant;

namespace HH.RMS.Service.Web.Interface
{
    public interface ISchedulerService
    {
        List<SchedulerModel> QueryRunningScheduler();
        ResultType DeleteSchedulerById(long id);
    }
}
