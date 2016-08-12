using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    [MappingTable(tableName = "SystemJob")]
    public class JobEntity : EntityBase
    {
        [MaxLength(20)]
        public string jobCode { get; set; }
        [MaxLength(50)]
        public string jobName { get; set; }
        [MaxLength(50)]
        public string jobDescription { get; set; }
         [MaxLength(100)]
        public string jobType { get; set; }
         [MaxLength(100)]
        public string jobAssembly { get; set; }
        public virtual ICollection<SchedulerEntity> schedulerList { get; set; }
    }
}
