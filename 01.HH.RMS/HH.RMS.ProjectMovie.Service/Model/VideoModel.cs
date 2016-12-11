using HH.ProjectMovie.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Service.Model
{
    public class VideoModel
    {
        public long id { get; set; }
        public string title { get; set; }
        public string otherTitle { get; set; }
        public decimal videoTag { get; set; }
        public string tag { get; set; }
         [JsonProperty(PropertyName = "act")]
        public string actor { get; set; }
         [JsonProperty(PropertyName = "dir")]
        public string dirctor { get; set; }
        public int year { get; set; }
        public decimal rating { get; set; }
        public string area { get; set; }
        public decimal areaTag { get; set; }
        [JsonProperty(PropertyName = "desc")]
        public string description { get; set; }
        public string cover { get; set; }
        public VideoStatus status { get; set; }
        public decimal score { get; set; }
        public decimal star { get; set; }
        public PlayLinkModel playLinks { get; set; }
        [JsonProperty(PropertyName = "video_rec")]
        public List<VideoRelateModel> videoRelate { get; set; }
        public List<VideoPlayerModel> videoPlayList { get; set; }
        [JsonProperty(PropertyName = "act_s")]
        public List<ActorDetailModel> actorDetalList { get; set; }
        public List<FilmManModel> actorList { get; set; }
        public List<FilmManModel> directorList { get; set; }
        public List<VideoImageModel> imageList { get; set; }
        //public static T ModelMapper<T>(object entity)
        //{
        //    return TinyMapper.Map<T>(entity);
        //}
        //public static T EntityMapper<T>(object model)
        //{
        //    return TinyMapper.Map<T>(model);
        //}
    }
    public class PlayLinkModel
    {
        public string levp { get; set; }
        public string tudou { get; set; }
        public string youku { get; set; }
        public string huashu { get; set; }
        public string qiyi { get; set; }
        public string qq { get; set; }

    }
    public class VideoRelateModel
    {
        public string title { get;set;}
        public string cover { get; set; }
       [JsonProperty(PropertyName = "detail_url")]
        public string url { get; set; }

    }
    public class ActorDetailModel
    {
        public string name { get; set; }
        public string url { get; set; }
        public string image { get; set; }
    }
    public class VideoPullModel
    {
        public string reason { get; set; }
        public VideoModel result { get; set; }
    }
}
