using HH.RMS.Entity.EntityFramework;
using HH.RMS.Entity.EntityFramework.Interface;
using HH.RMS.Common.Unity;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.RMS.Service.Web;
using HH.RMS.Service.Wechat.Interface;
using HH.RMS.Service.Wechat;
using HH.ProjectMovie.Service;
using HH.ProjectMovie.Service.Interface;

namespace HH.RMS.Service
{
    public class VideoUnityService:UnityService
    {
        public UnityManager unityManager;

        public VideoUnityService(UnityManager unityManager)
            : base(unityManager)
        {
            this.unityManager = unityManager;
        }
        public override void ServiceRegister()
        {
            unityManager.RegisterType<IVideoService, VideoService>();
            base.ServiceRegister();
        }
    }
}
