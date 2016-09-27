using HH.RMS.Repository.ADONet;
using HH.RMS.Repository.ADONet.Interface;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Common.Unity;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HH.RMS.Service.Web
{
    public class UnityService
    {
        private UnityManager _unityManager;
        public UnityService(UnityManager unityManager)
        {
            _unityManager = unityManager;

        }
        public virtual void RepositoryRegister()
        {
            _unityManager.RegisterType(typeof(IRepository<>), typeof(RepositoryBase<>));
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
            _unityManager.RegisterType<ICityService, CityService>();
            _unityManager.RegisterType<IProvinceService, ProvinceService>();
            _unityManager.RegisterType<IRoleService, RoleService>();
            _unityManager.RegisterType<ICountryService, CountryService>();
            _unityManager.RegisterType<ILevelService, LevelService>();
            //_unityManager.RegisterType<IADOUnit, ADOUnit>();
        }
        public virtual void ContorllerRegister()
        {
            ControllerBuilder.Current.SetControllerFactory(_unityManager.UnityControllerFactory);
        }
           
    }
}
