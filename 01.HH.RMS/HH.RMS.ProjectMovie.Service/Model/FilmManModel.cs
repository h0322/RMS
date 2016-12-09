using HH.RMS.Common.Attributes;
using HH.RMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Service.Model
{
    public class FilmManModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public long country { get; set; }
        public long province { get; set; }
        public long city { get; set; }
        public string url { get; set; }
    }
}
