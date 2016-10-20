using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Scheduler
{
     [MappingTable(tableName = "SystemScheduler")]
    public class SchedulerEntity:EntityBase
    {
        public long jobId { get; set; }
          [MaxLength(50)]
        public string scheduleName { get; set; }
         [MaxLength(100)]
        public string scheduleDescription { get; set; }
        [MaxLength(100)]
        public string scheduleGroup { get; set; }
        public IntervalType intervalType { get; set; }
         [MaxLength(100)]
        public string cronExpression { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int weekday { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
        public SqlScriptType sqlScriptType { get; set; }
         [MaxLength(1000)]
        public string sqlScript { get; set; }
         [MaxLength(100)]
        public string serverName { get; set; }
         [MaxLength(100)]
        public string siteName { get; set; }
        public DateTime runTime { get; set; }
        public DateTime stopTime { get; set; }
        [ForeignKey("jobId")]
        public virtual JobEntity job { get; set; }
    }
}
