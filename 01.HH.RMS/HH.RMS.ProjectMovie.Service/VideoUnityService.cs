using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
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
using HH.ProjectMovie.Repository;
using HH.ProjectMovie.Repository.Interface;

namespace HH.RMS.Service
{
    public class VideoUnityService:UnityService
    {

        public VideoUnityService(UnityManager unityManager)
            : base(unityManager)
        {
        }
        public override void ServiceRegister()
        {
            unityManager.RegisterType<IVideoService, VideoService>();
            base.ServiceRegister();
        }
        public override void RepositoryRegister()
        {
            unityManager.RegisterType(typeof(IMovieRepository<>), typeof(MovieRepository<>));
            base.RepositoryRegister();
        }
    }
}
