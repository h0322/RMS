using HH.RMS.Common.Constant;
using HH.RMS.Service.Web.Model;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using HH.RMS.MVC.Models;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HH.RMS.Service.Web;
using HH.RMS.Service;

namespace HH.RMS.MVC.Controllers
{
    [RMSAuthorize]
    public class AccountController : ControllerService
    {
        private IAccountService _accountService;
        private IPersonService _personService;
        private IRoleService _roleService;
        public AccountController(IAccountService accountService, IPersonService personService, IRoleService roleService)
        {
            _accountService = accountService;
            _personService = personService;
            _roleService = roleService;
        }
        
        public ActionResult Index()
        {
            ViewBag.personId = 0;
            if (Request.QueryString["personId"] != null && Convert.ToInt64(Request.QueryString["personId"]) > 0)
            {
                ViewBag.personId = Convert.ToInt64(Request.QueryString["personId"]);
            }
            return View();
        }
        [HttpPost]
        [RMSAuthorize(excuteType = (int)ExcuteType.Select, menuCode = "Account")]
        public JsonResult QueryAccountToGrid(PagerModel pagerModel)
        {
            pagerModel.searchText = searchText;
            pagerModel.searchType = searchType;
            pagerModel.searchDateFrom = searchDateFrom;
            pagerModel.searchDateTo = searchDateTo;
            pagerModel.searchStatus = searchStatus;
            var model = _accountService.QueryAccountToGridByRole(pagerModel);
            return Json(model, JsonRequestBehavior.AllowGet);
           
        }
        [HttpPost]
        [RMSAuthorize(excuteType = (int)ExcuteType.Select, menuCode = "Account")]
        public JsonResult QueryAccountById(long id)
        {
            var account = _accountService.QueryAccountById(id);
            return Json(account, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [RMSAuthorize(excuteType = (int)ExcuteType.Delete, menuCode = "Account")]
        public JsonResult DeleteAccountById(string idString)
        {
            long[] ids = (long[])ConvertHelper.StringToArray(idString, DataType.Int64);
            var account = _accountService.DeleteAccountMassById(ids);
            return Json(account, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [RMSAuthorize(excuteType = (int)ExcuteType.Insert, menuCode = "Account")]
        public JsonResult SaveAccount(AccountModel model)
        {
          model.password = SecurityHelper.Hash(model.password);
           var result = _accountService.InsertAccount(model);
           return Json(new { result= (int)result}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [RMSAuthorize(excuteType = (int)ExcuteType.Update, menuCode = "Account")]
        public JsonResult UpdateAccount(AccountModel model)
        {
            ResultType result = ResultType.Fail;
            if (model.id > 0)
            {
                result = _accountService.UpdateAccount(model);
            }
            else
            {
                result = _accountService.InsertAccount(model);
            }
           
            return Json(new { result = (int)result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult QueryRoleList()
        {
            return RoleModel.ToSelect();
        }
        public JsonResult QueryLevelList()
        {
            return LevelModel.ToSelect();
        }

    }
}
