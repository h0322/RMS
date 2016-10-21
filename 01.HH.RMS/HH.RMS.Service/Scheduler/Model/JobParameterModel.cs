using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Scheduler.Model
{
    public class JobParameterModel
    {
        public long jobParameterId { get; set; }
        public long jobId { get; set; }
        public string parameterName { get; set; }
        public string parameterValue { get; set; }
    }
}
