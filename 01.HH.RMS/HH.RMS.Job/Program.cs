using HH.RMS.Common.Unity;
using HH.RMS.Scheduler;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Job
{
    class Program
    {
        static void Main(string[] args)
        {
            new UnityScheduler(UnityManager.instance);
            SchedulerManager manager = new SchedulerManager();
            manager.Initialize();
            Console.Write("Job Excetue");
        }
    }
}
