using HH.RMS.Service.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HH.RMS.MVC.Controllers
{
    public class MenuController : ControllerService
    {
        //
        // GET: /Menu/

        public ActionResult Index()
        {
            return View();
        }

    }
}
