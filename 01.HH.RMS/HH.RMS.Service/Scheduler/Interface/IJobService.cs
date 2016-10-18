using HH.RMS.Service.Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Interface
{
    public interface IJobService
    {
        List<JobModel> QueryRunningJob();
        List<JobModel> QueryRunningJobBySchedulerId(long id);
        List<JobParameterModel> QueryJobParameterByJobId(long id);
    }
}
