using HH.RMS.Entity.Scheduler;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Scheduler.Model;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web
{
    public class JobService : ServiceBase, IJobService
    {
        private IRepository<JobEntity> _jobRepository;
        private IRepository<JobParameterEntity> _jobParameterRepository;
        public JobService(IRepository<JobEntity> jobRepository, IRepository<JobParameterEntity> jobParameterRepository)
        {
            _jobRepository = jobRepository;
            _jobParameterRepository = jobParameterRepository;
        }
        public List<JobModel> QueryRunningJobBy()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _jobRepository.Query(db)
                            where a.fromDate <= DateTime.Now && a.toDate >= DateTime.Now
                            select new JobModel()
                            {
                                fromDate = a.fromDate,
                                toDate = a.toDate,
                                jobAssembly = a.jobAssembly,
                                jobCode = a.jobCode,
                                jobDescription = a.jobDescription,
                                jobId = a.id,
                                jobName = a.jobName,
                                jobType = a.jobType
                            };
                    return q.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
                log.Error("JobService.QueryRunningJobBy", ex);
            }
        }

        public List<JobModel> QueryRunningJobBySchedulerId(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _jobRepository.Query(db)
                            where a.fromDate <= DateTime.Now && a.toDate >= DateTime.Now && a.schedulerId == id
                            select new JobModel()
                            {
                                schedulerId = a.schedulerId,
                                fromDate = a.fromDate,
                                toDate = a.toDate,
                                jobAssembly = a.jobAssembly,
                                jobCode = a.jobCode,
                                jobDescription = a.jobDescription,
                                jobId = a.id,
                                jobName = a.jobName,
                                jobType = a.jobType
                            };
                    return q.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
                log.Error("JobService.QueryRunningJobBySchedulerId", ex);
            }
        }

        public List<JobParameterModel> QueryJobParameterByJobId(long id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = from a in _jobParameterRepository.Query(db)
                            where a.jobId == id
                            select new JobParameterModel()
                            {
                                jobId=a.jobId,
                                jobParameterId = a.id,
                                parameterName = a.parameterName,
                                parameterValue = a.parameterValue
                            };
                    return q.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
                log.Error("JobService.QueryJobParameterByJobId", ex);
            }
        }
    }
}
