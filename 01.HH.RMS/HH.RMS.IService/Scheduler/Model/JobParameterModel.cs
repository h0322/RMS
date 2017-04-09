using HH.RMS.Common.Constant;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Scheduler.Model
{
    public class JobParameterModel
    {
        public long jobParameterId { get; set; }
        public long jobId { get; set; }
        public string parameterName { get; set; }
        public string parameterValue { get; set; }
        public DataType parameterType { get; set; }

    }
}
