using HH.RMS.Common.Unity;
using HH.RMS.Service.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Scheduler
{
    public class UnityScheduler : UnityService
    {
        public UnityScheduler(UnityManager unityManager)
            : base(unityManager)
        {
            Register();
        }
        public override void ContorllerRegister()
        {
            return;
        }
    }
}
