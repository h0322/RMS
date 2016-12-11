using HH.ProjectMovie.Entity;
using HH.ProjectMovie.Entity.EntityFramework;
using HH.ProjectMovie.Service.Interface;
using HH.ProjectMovie.Service.Model;
using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.EntityFramework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Service
{
    public class VideoTagService : IVideoTagService
    {
        private IMovieRepository<VideoTagEntity> _videoTagRepository { get; set; }
        public VideoTagService(IMovieRepository<VideoTagEntity> videoTagRepository)
        {
            _videoTagRepository = videoTagRepository;
        }
        public ResultType InsertTag(string tag)
        {
            string[] tagArray = tag.Split('/');

            return ResultType.Success;
        }
        public ResultType InsertTag(VideoTagModel model)
        {
            //try
            //{
            //    var entity = 
            //    using (var db = new MovieDbContext())
            //    {

            //    }
            //    return ResultType.Success;
            //}
            //catch (Exception ex)
            //{
            //    Config.log.Error("VideoTagService.InsertTag", ex);
            //    return ResultType.FieldError;
            //}
            return ResultType.Success;
        }
        public VideoTagModel QueryVideoTagByName(string tagName)
        {
            try
            {
                using (var db = new MovieDbContext())
                {
                    var entity = _videoTagRepository.Query(db).Where(m=>m.tagName == tagName).FirstOrDefault();
                    return null;
                }
            }
            catch(Exception ex)
            {
                Config.log.Error("VideoTagService.QueryVideoTagByName", ex);
                return null;
            }
        }
    }
}
