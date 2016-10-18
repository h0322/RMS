using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Scheduler.Model
{
    public class SchedulerLogModel
    {
        public long schedulerLogId { get; set; }
        public long schedulerId { get; set; }
        public string scheduleDescription { get; set; }
        public DateTime scheduleTime { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public ResultType resultType { get; set; }
        public string resultMessage { get; set; }
    }
}
