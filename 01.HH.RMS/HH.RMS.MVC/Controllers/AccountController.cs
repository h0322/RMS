using HH.RMS.Common.Constant;
using HH.RMS.Service.Web.Model;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
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
        public JsonResult QueryRoleList()
        {
            var roleList = _roleService.QueryRoleList();
            List<SelectModel> selectList = new List<SelectModel>();
            selectList.Add(new SelectModel() { text = "请选择", value = "-1" });
            roleList.ForEach(m => selectList.Add(new SelectModel() { text = m.roleName, value = m.roleId.ToString() }));
            return Json(selectList, JsonRequestBehavior.AllowGet);
        }

    }
}
