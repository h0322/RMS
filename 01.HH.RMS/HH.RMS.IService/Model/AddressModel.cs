using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Model
{
    public class AddressModel
    {
        public long accountId { get; set; }
        public long countryId { get; set; }
        public long provinceId { get; set; }
        public long cityId { get; set; }
        public string address { get; set; }
        public string remark { get; set; }
    }
}
