using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HH.RMS.Scheduler.Job
{
    public class EmailJob : IJob
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Execute(IJobExecutionContext context)
        {
            log.Info("EmailJob.Execute:Start");
            Thread.Sleep(10000);
            log.Info("EmailJob.Excute:End");
        }
    }
}
