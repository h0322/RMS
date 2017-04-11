using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Model
{
    public class EmailModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
        public string remark { get; set; }
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
