using HH.RMS.Common.Constant;
using HH.RMS.Scheduler;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Common.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HH.RMS.MVC
{
    public static class SchedulerConfig
    {
        public static void Register()
        {
            SchedulerManager.Start();
            var scheduler = UnityManager.instance.GetService<ISchedulerService>();
            var list = scheduler.QuerySchedulerAll();
            foreach(var info in list)
            {
                SchedulerManager.ExecuteScheduler(info);
            }
        }
    }
}
