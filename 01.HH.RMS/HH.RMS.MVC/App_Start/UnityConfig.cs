using HH.RMS.Service;
using HH.RMS.Common.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HH.RMS.MVC
{
    public class UnityConfig : ServiceRegister
    {
        public UnityConfig(UnityManager unityManager)
            : base(unityManager)
        {
            _unityManager.RegisterType(typeof(IADORepository<>), typeof(ADORepositoryBase<>));
            ContorllerRegister();
            ServiceRegister();
        }    
    }
}