using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Service;
using HH.RMS.Service.Web;
using HH.RMS.Service.Web.Interface;
using HH.RMS.Service.Web.Model;
using Newtonsoft.Json;
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
            long[] bitMap = _roleService.QueryRoleList().Select(m => m.bitMap).ToArray();
            model.bitMap = BitMapHelper.GetBitMap(bitMap);
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
            var role = _roleService.QueryRoleById(id);
            return Json(role, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteRoleByIds(string idString)
        {
            long[] ids = (long[])ConvertHelper.StringToArray(idString,DataType.Int64);
            var result = _roleService.DeleteRoleByIds(ids);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateMenuRole(string menuRoleString, long roleId)
        {
            var result = ResultType.Success;// _roleService.DeleteMenuRoleByRoleId(roleId);
            List<MenuRoleModel> list = JsonConvert.DeserializeObject<List<MenuRoleModel>>(menuRoleString);
            if(result == ResultType.Success)
            {
                foreach (var item in list)
                {
                    item.roleId = roleId;
                    //if (item.isSelect)
                    //{
                    //    item.excuteType = item.excuteType | (int)ExcuteType.Select; 
                    //}
                    //if (item.isInsert)
                    //{
                    //    item.excuteType = item.excuteType | (int)ExcuteType.Insert;
                    //}
                    //if (item.isUpdate)
                    //{
                    //    item.excuteType = item.excuteType | (int)ExcuteType.Update;
                    //}
                    //if (item.isDelete)
                    //{
                    //    item.excuteType = item.excuteType | (int)ExcuteType.Delete;
                    //}
                    result = _roleService.InsertMenuRole(item);
                    if (result != ResultType.Success)
                    {
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult QueryMenuRole(long roleId)
        {
            var menuRole = _roleService.QueryMenuByRoleIdList(roleId);
            return Json(menuRole, JsonRequestBehavior.AllowGet);
        }

    }
}
