using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Web.Model
{
    public class CountryModel
    {
        public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public string remark { get; set; }
    }
}
