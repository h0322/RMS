using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Scheduler
{
     [MappingTable(tableName = "SystemJobLog")]
    public class JobLogEntity:EntityBase
    {
        public long schedulerId { get; set; }
        public long jobId { get; set; }
         [MaxLength(100)]
        public string scheduleGroup { get; set; }
         [MaxLength(100)]
        public string jobGroup { get; set; }
         [MaxLength(100)]
        public string scheduleName { get; set; }
         [MaxLength(100)]
        public string jobName { get; set; }
         public long executeSecond { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public ResultType resultType { get; set; }
        public string resultMessage { get; set; }
    }
}
