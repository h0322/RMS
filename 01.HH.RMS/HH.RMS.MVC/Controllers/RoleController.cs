using HH.RMS.Common.Constant;
using HH.RMS.Service;
using HH.RMS.Service.Web;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HH.RMS.MVC.Controllers
{
    [RMSAuthorize]
    public class RoleController : ControllerService
    {
        private IRoleService _roleService { get; set; }
        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult QueryRoleToGrid(PagerModel pagerModel)
        {
            pagerModel.searchText = searchText;
            pagerModel.searchType = searchType;
            pagerModel.searchDateFrom = searchDateFrom;
            pagerModel.searchDateTo = searchDateTo;
            pagerModel.searchStatus = searchStatus;
            var model = _roleService.QueryRoleToGrid(pagerModel);
            return Json(model, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult CreateRole(RoleModel model)
        {
            ResultType result = _roleService.CreateRole(model);
            return Json(result);
        }
        [HttpPost]
        public JsonResult UpdateRole(RoleModel model)
        {
            ResultType result = _roleService.UpdateRole(model);
            return Json(result);
        }
        [HttpPost]
        public JsonResult QueryRoleById(long id)
        {
            var person = _roleService.QueryRoleById(id);
            return Json(person, JsonRequestBehavior.AllowGet);
        }

    }
}
