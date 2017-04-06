using HH.RMS.Common.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Job
{
    public class ServiceConfig
    {
        public UnityManager unityManager;

        public ServiceConfig(UnityManager unityManager)
        {
            this.unityManager = unityManager;
        }

        public virtual void ServiceRegister()
        {

        }

    }
}
