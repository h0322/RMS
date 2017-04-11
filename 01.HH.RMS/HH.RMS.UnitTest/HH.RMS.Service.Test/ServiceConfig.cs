using HH.RMS.Common.Unity;
using HH.RMS.IService;
using HH.RMS.IService.Location;
using HH.RMS.IService.Scheduler;
using HH.RMS.IService.Wechat;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.Service;
using HH.RMS.Service.Wechat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HH.RMS.UnitTest.HH.RMS.Service.Test
{
    public class ServiceConfig
    {
        public UnityManager unityManager;

        public ServiceConfig(UnityManager unityManager)
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
        public virtual void ServiceRegister()
        {
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
            unityManager.RegisterType<ILuckyService, LuckyService>();
            unityManager.RegisterType<IEmailService, EmailService>();

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
