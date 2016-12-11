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
using HH.ProjectMovie.Entity.EntityFramework;

namespace HH.ProjectMovie.Service
{
    public class VideoService : IVideoService
    {
        private IMovieRepository<VideoEntity> _videoRepository { get; set; }
        public VideoService(IMovieRepository<VideoEntity> videoRepository)
        {
            this._videoRepository = videoRepository;
        }
        public VideoPullModel GetVideoInfoByName(string name)
        {
            string url = string.Format(Constant.movieInterfaceUrl, Constant.movieInterfaceAppKey, name);
            string result = NetHelper.Get(url);
            var model = JsonConvert.DeserializeObject<VideoPullModel>(result);
            return model;
        }
        public ResultType InsertVideo(VideoModel model)
        {
            //try
            //{
            //    using (var db = new MovieDbContext())
            //    {
            //        _videoRepository.Insert(db,)
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Config.log.Error("VideoService.InsertVideo", ex);
            //    return ResultType.SystemError;
            //}
            return ResultType.Success;
        }

    }
}
