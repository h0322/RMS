using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    public class EntityBase
    {

        [Required]
        [Key]
        public long id { get; set; }
        public long createBy { get; set; }
        public long? updateBy { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public string remark { get; set; }
        public bool isActive { get; set; }

    }
}
