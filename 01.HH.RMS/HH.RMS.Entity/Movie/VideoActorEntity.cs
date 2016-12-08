using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.Movie
{
    public class VideoActorEntity:EntityBase
    {
        public long videoId { get; set; }
        public long actorId { get; set; }
    }
}
