using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Scheduler
{
    public class JobParameterEntity : EntityBase
    {
        public long jobId { get; set; }
        public string parameterName { get; set; }
        public string parameterValue { get; set; }
    }
}
