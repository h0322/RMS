using HH.RMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HH.RMS.MVC.Controllers
{
    public class RoleController : ControllerService
    {
        //
        // GET: /Role/

        public ActionResult Index()
        {
            return View();
        }

    }
}
