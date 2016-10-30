using HH.RMS.Common.Constant;
using HH.RMS.Entity.Scheduler;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Scheduler.Model
{
    public class SchedulerModel
    {
        public long schedulerId { get; set; }
        public long jobId { get; set; }
        public string scheduleName { get; set; }
        public string scheduleDescription { get; set; }
        public string scheduleGroup { get; set; }
        public IntervalType intervalType { get; set; }
        public string cronExpression { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int weekday { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
        public SqlScriptType sqlScriptType { get; set; }
        public string sqlScript { get; set; }
        public string serverName { get; set; }
        public string siteName { get; set; }
        public DateTime runTime { get; set; }
        public DateTime stopTime { get; set; }


    }
}
