using HH.RMS.Service;
using HH.RMS.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HH.RMS.MVC
{
    public class UnityConfig : UnityRegister
    {
        public UnityConfig(UnityManager unityManager)
            : base(unityManager)
        {
            EntityRepositoryRegister();
            ContorllerRegister();
            ServiceRegister();
        }    
    }
}