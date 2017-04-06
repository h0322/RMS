using HH.RMS.Common.Constant;
using HH.RMS.IService.Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Scheduler
{
    public interface IJobService
    {
        List<JobModel> QueryRunningJob();
        List<JobModel> QueryRunningJobBySchedulerId(long id);
        List<JobParameterModel> QueryJobParameterByJobId(long id);
        ResultType InsertJobLog(JobLogModel model);
    }
}
