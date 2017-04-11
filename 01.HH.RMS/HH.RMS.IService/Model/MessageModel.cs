using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Model
{
    public class MessageModel
    {
        public long id { get; set; }
        public long accountId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int support { get; set; }
        public int oppose { get; set; }
        public long parentId { get; set; }
        public static T ModelMapper<T>(object entity)
        {
            return TinyMapper.Map<T>(entity);
        }
        public static T EntityMapper<T>(object model)
        {
            return TinyMapper.Map<T>(model);
        }
    }
}
