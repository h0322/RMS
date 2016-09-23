using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace HH.RMS.Common.Unity
{
    public class UnityControllerActivator : IControllerActivator
    {
        private UnityManager unityManager;
        public UnityControllerActivator(UnityManager unityManager)
        {
            this.unityManager = unityManager;
        }
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            //return unityManager.GetService<IController>();
            return (IController)unityManager.GetService(controllerType);
        }
    }
}
