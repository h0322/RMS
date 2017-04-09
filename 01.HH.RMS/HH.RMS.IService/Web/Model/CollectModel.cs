using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Web.Model
{
    public class CollectModel
    {
        public string fromString { get; set;}
        public string toString { get; set; }
        public string url { get; set; }
        public string dbConnectionString { get; set; }
        public string dbUsername { get; set; }
        public string dbPassword { get; set; }
    }
}
