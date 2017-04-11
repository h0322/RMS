using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    public class MessageEntity:EntityBase
    {
        public long accountId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int support { get; set; }
        public int oppose { get; set; }
        public long parentId { get; set; }
    }
}
