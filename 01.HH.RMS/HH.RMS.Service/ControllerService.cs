using HH.RMS.Entity;
using HH.RMS.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HH.RMS.Service
{
    public class ControllerService : Controller
    {
        protected static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string searchText
        {
            get
            {
                if (Request.Cookies.Get("searchText") == null)
                {
                    return "";
                }
                return Request.Cookies.Get("searchText").Value.ToString();
            }
        }
        public DateTime? searchDateFrom
        {
            get
            {
                if (Request.Cookies.Get("searchDateFrom") == null || string.IsNullOrEmpty(Request.Cookies.Get("searchDateFrom").Value))
                {
                    return null;
                }
                return Convert.ToDateTime(Request.Cookies.Get("searchDateFrom").Value);
            }
        }
        public DateTime? searchDateTo
        {
            get
            {
                if (Request.Cookies.Get("searchDateTo") == null || string.IsNullOrEmpty(Request.Cookies.Get("searchDateTo").Value))
                {
                    return null;
                }
                return Convert.ToDateTime(Request.Cookies.Get("searchDateTo").Value);
            }
        }
        public int searchStatus
        {
            get
            {
                if (Request.Cookies.Get("searchStatus") == null || string.IsNullOrEmpty(Request.Cookies.Get("searchStatus").Value))
                {
                    return 0;
                }
                return Convert.ToInt32(Request.Cookies.Get("searchStatus").Value);
            }
        }
        public int searchType
        {
            get
            {
                if (Request.Cookies.Get("searchType") == null || string.IsNullOrEmpty(Request.Cookies.Get("searchType").Value))
                {
                    return 0;
                }
                return Convert.ToInt32(Request.Cookies.Get("searchType").Value);
            }
        }
        public int searchRole
        {
            get
            {
                if (Request.Cookies.Get("searchRole") == null || string.IsNullOrEmpty(Request.Cookies.Get("searchRole").Value))
                {
                    return 0;
                }
                return Convert.ToInt32(Request.Cookies.Get("searchRole").Value);
            }
        }

        public int searchId
        {
            get
            {
                if (Request.Cookies.Get("searchId") == null || string.IsNullOrEmpty(Request.Cookies.Get("searchId").Value))
                {
                    return 0;
                }
                return Convert.ToInt32(Request.Cookies.Get("searchId").Value);
            }
        }
        //protected PagerModel pagerModel=new PagerModel();
        public ControllerService()
        {
            //pagerModel.pageNumber = 1;
            //pagerModel.pageSize = 10;
        }
        public string ToDataGrid()
        {

            return "";
        }
    }
}
