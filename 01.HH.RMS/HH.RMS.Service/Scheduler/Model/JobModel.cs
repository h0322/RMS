using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Scheduler.Model
{
    public class JobModel
    {
        public long jobId { get; set; }
        public long schedulerId { get; set; }
        public string jobCode { get; set; }
        public string jobName { get; set; }
        public string jobDescription { get; set; }
        public JobType jobType { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string jobAssembly { get; set; }
    }
}
