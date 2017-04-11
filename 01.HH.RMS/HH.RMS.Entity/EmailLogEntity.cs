using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    [MappingTable(tableName = "EmailLog")]
    public class EmailLogEntity : EntityBase
    {
        public long emailId { get; set; }
        [MaxLength(500)]
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
        [MaxLength(100)]
        public string emailFrom { get; set; }
        [MaxLength(100)]
        public string emailDisplayName { get; set; }
        [MaxLength(100)]
        public string emailTo { get; set; }
        public EncodeType encodeType { get; set; }
        public EmailSendStatus emailSendStatus { get; set; }
    }
}
