using Common.Logging;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Scheduler.Job
{
    public class JobBase
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected static void ConsoleBegin(string jobName)
        {
            Console.WriteLine("StartJob:" + jobName);
        }
        protected static void ConsoleEnd(string jobName,ResultType resultType,string resultMessage)
        {
            Console.WriteLine("EndJob:" + jobName + " " + resultType + " " + resultMessage);
        }
    }
}
