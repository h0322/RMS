using HH.RMS.Common.Constant;
using HH.RMS.Entity.EntityFramework.Interface;
using HH.ProjectMovie.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.ProjectMovie.Service.Interface;
using HH.ProjectMovie.Common;
using HH.RMS.Common.Utilities;
using Newtonsoft.Json;
using HH.ProjectMovie.Service.Model;

namespace HH.ProjectMovie.Service
{
    public class VideoService : IVideoService
    {
        private IMovieRepository<VideoEntity> _videoRepository { get; set; }
        public VideoService(IMovieRepository<VideoEntity> videoRepository)
        {
            this._videoRepository = videoRepository;
        }
        public VideoModel GetVideoInfoByName(string name)
        {
            string url = string.Format(Constant.movieInterfaceAppKey, Constant.movieInterfaceAppKey, name);
            string result = NetHelper.Get(url);
            var model = JsonConvert.DeserializeObject<VideoModel>(result);
            return model;
        }
    }
}
