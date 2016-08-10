using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    [MappingTable(tableName = "SystemJob")]
    public class JobEntity : EntityBase
    {
        public string jobCode { get; set; }
        public string jobName { get; set; }
        public string jobDescription { get; set; }
        public string jobType { get; set; }
        public string jobAssembly { get; set; }
        public virtual ICollection<SchedulerEntity> schedulerList { get; set; }
    }
}
