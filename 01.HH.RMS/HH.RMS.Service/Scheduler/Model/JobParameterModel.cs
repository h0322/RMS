using HH.RMS.Common.Constant;
using HH.RMS.Entity.Scheduler;
using Nelibur.ObjectMapper;
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
        public DataType parameterType { get; set; }
        public static void ModelMapper()
        {
            TinyMapper.Bind<JobParameterEntity, JobParameterModel>(config =>
            {
                config.Bind(x => x.id, y => y.jobParameterId);
            });
        }
        public static void EntityMapper()
        {
            TinyMapper.Bind<JobParameterModel, JobParameterEntity>(config =>
            {
                config.Bind(x => x.jobParameterId, y => y.id);
            });
        }
    }
}
