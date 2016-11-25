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
using HH.RMS.Service.Web;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat;

namespace HH.RMS.Service
{
    public class UnityService
    {
        public UnityManager unityManager;

        public UnityService(UnityManager unityManager)
        {
            this.unityManager = unityManager;
            Register();
        }
        public virtual void Register()
        {
            RepositoryRegister();
            ServiceRegister();
            ContorllerRegister();
        }
        public virtual void RepositoryRegister()
        {
            unityManager.RegisterType(typeof(IRepository<>), typeof(RepositoryBase<>));
        }
        public virtual void ADORepositoryRegister()
        {
            unityManager.RegisterType(typeof(IADORepository<>), typeof(ADORepositoryBase<>));
            //unityManager.RegisterType<IADORepository, ADORepositoryBase>();
        }
        public virtual void ServiceRegister()
        {
            unityManager.RegisterType<IPersonService, PersonService>();
            unityManager.RegisterType<IAccountService, AccountService>();
            unityManager.RegisterType<ISchedulerService, SchedulerService>();
            unityManager.RegisterType<IMenuService, MenuService>();
            unityManager.RegisterType<ILoginService, LoginService>();
            unityManager.RegisterType<ICityService, CityService>();
            unityManager.RegisterType<IProvinceService, ProvinceService>();
            unityManager.RegisterType<IRoleService, RoleService>();
            unityManager.RegisterType<ICountryService, CountryService>();
            unityManager.RegisterType<ILevelService, LevelService>();
            unityManager.RegisterType<ISchedulerService, SchedulerService>();
            unityManager.RegisterType<IJobService, JobService>();
            unityManager.RegisterType<ICollcetService, CollcetService>();
            #region wechat
            unityManager.RegisterType<IWechatConfigService, WechatConfigService>();
            unityManager.RegisterType<IResponseMessageService, ResponseMessageService>();
            unityManager.RegisterType<IWechatJsSdkService, WechatJsSdkService>();
            unityManager.RegisterType<IWechatOAuthService, WechatOAuthService>();
            unityManager.RegisterType<IWechatQRCodeService, WechatQRCodeService>();
            unityManager.RegisterType<IWechatReceiveService, WechatReceiveService>();
            unityManager.RegisterType<IWechatUserService, WechatUserService>();
            unityManager.RegisterType<IWechatRequestService, WechatRequestService>();
            #endregion
        }
        public virtual void ContorllerRegister()
        {
            ControllerBuilder.Current.SetControllerFactory(unityManager.UnityControllerFactory);
        }
           
    }
}
