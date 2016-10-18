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
    [MappingTable(tableName = "SystemJob")]
    public class JobEntity : EntityBase
    {
        public long schedulerId { get; set; }
        [MaxLength(20)]
        public string jobCode { get; set; }
        [MaxLength(50)]
        public string jobName { get; set; }
        [MaxLength(50)]
        public string jobDescription { get; set; }
        public JobType jobType { get; set; }
         [MaxLength(100)]
        public string jobAssembly { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public virtual ICollection<SchedulerEntity> schedulerList { get; set; }
    }
}
