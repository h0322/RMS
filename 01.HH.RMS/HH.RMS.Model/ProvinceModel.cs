using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Model
{
    public class ProvinceModel
    {
        public long provinceId { get; set; }
        public long countryId { get; set; }
        public string countryDescription { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int order { get; set; }
    }
}
