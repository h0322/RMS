using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Model
{
    public class EmailLogModel
    {
        public long id { get; set; }
        public long emailId { get; set; }
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
        public string emailFrom { get; set; }
        public string emailDisplayName { get; set; }
        public string emailTo { get; set; }
        public EncodeType encodeType { get; set; }
        public Encoding encode
        {
            get { return TypeHelper.GetEncoding(encodeType); }
        }
        public EmailSendStatus emailSendStatus { get; set; }
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
