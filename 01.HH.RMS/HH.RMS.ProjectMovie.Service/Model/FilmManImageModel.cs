using HH.RMS.Common.Attributes;
using HH.RMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Service.Model
{
    public class FilmManImageModel
    {
        public long id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public long acotrId { get; set; }
        public string url { get; set; }
        public bool isCover { get; set; }
    }
}
