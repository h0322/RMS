using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using HH.RMS.Repository.EntityFramework;

namespace HH.RMS.Unity
{
    public class UnityManager
    {
        private readonly IUnityContainer container;
        private static readonly UnityManager _instance = new UnityManager();

        public static UnityManager instance
        {
            get { return _instance; }
        }
        public T GetService<T>()
        {
            return container.Resolve<T>();
        }
        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public DefaultControllerFactory UnityControllerFactory
        {
            get
            {
                return new DefaultControllerFactory(new UnityControllerActivator(this));
            }
        }



        private UnityManager()
        {
            this.container = new UnityContainer();

            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(container);
            }
        }

        public void RegisterType<TFrom, TTo>(params InjectionMember[] injectionMembers) where TTo : TFrom
        {
            container.RegisterType<TFrom, TTo>(injectionMembers);
        }
        public void RegisterType(Type type1, Type type2, params InjectionMember[] injectionMembers)
        {

            container.RegisterType(type1, type2, injectionMembers);
        }
        public DefaultControllerFactory DefaultControllerFactory
        {
            get
            {
                return new DefaultControllerFactory(new UnityControllerActivator(this));
            }
        }
    }
}
