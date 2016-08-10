using HH.RMS.Common.Constant;
using HH.RMS.Model;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity;
using HH.RMS.Model;
using HH.RMS.MVC.Models;
using HH.RMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HH.RMS.Service;

namespace HH.RMS.MVC.Controllers
{
    [RMSAuthorize]
    public class AccountController : ControllerService
    {
        private IAccountService _accountService;
        private IPersonService _personService;
        public AccountController(IAccountService accountService, IPersonService personService)
        {
            _accountService = accountService;
            _personService = personService;
        }
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
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
        public JsonResult QueryAccountById(long id)
        {
            var account = _accountService.QueryAccountById(id);
            return Json(account, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteAccountById(string ids)
        {
            List<string> idList = ids.Split(',').ToList();
            var account = _accountService.DeleteAccountMassById(idList);
            return Json(account, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveAccount(AccountModel model)
        {
           var result = _accountService.InsertAccount(model);
           return Json(new { result= (int)result}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateAccount(AccountModel model)
        {
            var result = _accountService.UpdateAccount(model);
            return Json(new { result = (int)result }, JsonRequestBehavior.AllowGet);
        }
    }
}
