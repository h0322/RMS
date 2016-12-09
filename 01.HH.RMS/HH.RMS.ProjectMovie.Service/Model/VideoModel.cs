using HH.ProjectMovie.Common;
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
        public decimal tag { get; set; }
        public string actor { get; set; }
        public string dirctor { get; set; }
        public int year { get; set; }
        public string rating { get; set; }
        public int area { get; set; }
        public string description { get; set; }
        public VideoStatus status { get; set; }
        public decimal score { get; set; }
        public decimal star { get; set; }
        List<VideoPlayerModel> videoPlayList { get; set; }
        List<FilmManModel> actorList { get; set; }
        List<FilmManModel> directorList { get; set; }
        List<VideoImageModel> imageList { get; set; }
    }
}
