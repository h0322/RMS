using HH.RMS.Repository.ADONet;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Service;
using HH.RMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HH.RMS.Common.Constant;
using HH.RMS.Unity;
using Microsoft.Practices.Unity;
using HH.RMS.Repository.ADONet.Interface;

namespace HH.RMS.Unity
{
    public class UnityRegister
    {
        private UnityManager _unityManager;
        public UnityRegister(UnityManager unityManager)
        {
            _unityManager = unityManager;

        }
        public virtual  void EntityRepositoryRegister()
        {
           // _unityManager.RegisterType<DbContext, ApplicationDbContext>(new InjectionConstructor(Config.sqlConnStr));
           // _unityManager.RegisterType(typeof(IRepository<>), typeof(RepositoryBase<>), new InjectionConstructor(new ApplicationDbContext()));
            _unityManager.RegisterType(typeof(IRepository<>), typeof(RepositoryBase<>));
            _unityManager.RegisterType(typeof(DbContext), typeof(ApplicationDbContext));
            //_unityManager.RegisterType(typeof(IRepository<>), typeof(RepositoryBase<>));
        }
        public virtual void ADORepositoryRegister()
        {
            _unityManager.RegisterType(typeof(IADORepository<>), typeof(ADORepositoryBase<>));
            //_unityManager.RegisterType<IADORepository, ADORepositoryBase>();
        }
        public virtual void ServiceRegister()
        {
            _unityManager.RegisterType<IPersonService, PersonService>();
            _unityManager.RegisterType<IAccountService, AccountService>();
            _unityManager.RegisterType<ISchedulerService, SchedulerService>();
            _unityManager.RegisterType<IMenuService, MenuService>();
            _unityManager.RegisterType<ILoginService, LoginService>();
            //_unityManager.RegisterType<IADOUnit, ADOUnit>();
        }
        public virtual void ContorllerRegister()
        {
            ControllerBuilder.Current.SetControllerFactory(_unityManager.UnityControllerFactory);
        }
                    
    }
}
