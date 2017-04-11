using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    public class ConfigEntity:EntityBase
    {
        [MaxLength(100)]
        public string section { get; set; }
        [MaxLength(100)]
        public string key { get; set; }
        [MaxLength(500)]
        public string value { get; set; }
        [MaxLength(1000)]
        public string description { get; set; }
        public int order { get; set; }
    }
}
