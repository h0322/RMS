using HH.RMS.Common.Attributes;
using HH.RMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Service.Model
{
    public class VideoActorModel
    {
        public long videoId { get; set; }
        public long actorId { get; set; }
    }
}
