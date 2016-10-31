using HH.RMS.Common.Constant;
using HH.RMS.Entity.Scheduler;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Scheduler.Model
{
    public class JobLogModel
    {
        public long jobLogId { get; set; }
        public long schedulerLogId { get; set; }
        public long schedulerId { get; set; }
        public long jobId { get; set; }
        public JobType jobType { get; set; }
        public string scheduleGroup { get; set; }
        public string jobGroup { get; set; }
        public string scheduleName { get; set; }
        public string jobName { get; set; }
        public long executeSecond { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public ResultType resultType { get; set; }
        public string resultMessage { get; set; }
        public string remark { get; set; }
    }
}
