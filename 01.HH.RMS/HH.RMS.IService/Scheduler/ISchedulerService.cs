using HH.RMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.Common.Constant;
using HH.RMS.IService.Scheduler.Model;

namespace HH.RMS.IService.Scheduler
{
    public interface ISchedulerService
    {
        List<SchedulerModel> QueryRunningScheduler();
        ResultType DeleteSchedulerById(long id);
    }
}
