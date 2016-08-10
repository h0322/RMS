using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Model
{
    public class PagerModel
    {
        public int page { get; set; }
        public int rows { get; set; }
        public string searchText { get; set; }
        public DateTime? searchDateFrom { get; set; }
        public DateTime? searchDateTo { get; set; }
        public int searchStatus { get; set; }
        public int searchType { get; set; }
    }
    public class GridModel
    {
        public object rows { get; set; }
        public int total { get; set; }
    }
}
