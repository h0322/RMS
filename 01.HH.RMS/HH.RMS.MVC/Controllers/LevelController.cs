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
    public class LevelController : ControllerService
    {
        private ILevelService _levelService { get; set; }
        public LevelController(ILevelService levelService)
        {
            this._levelService = levelService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult QueryLevelToGrid(PagerModel pagerModel)
        {
            pagerModel.searchText = searchText;
            pagerModel.searchType = searchType;
            pagerModel.searchDateFrom = searchDateFrom;
            pagerModel.searchDateTo = searchDateTo;
            pagerModel.searchStatus = searchStatus;
            var model = _levelService.QueryLevelToGrid(pagerModel);
            return Json(model, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult CreateLevel(LevelModel model)
        {
            ResultType result = _levelService.CreateLevel(model);
            return Json(result);
        }
        [HttpPost]
        public JsonResult UpdateLevel(LevelModel model)
        {
            ResultType result = _levelService.UpdateLevel(model);
            return Json(result);
        }
        [HttpPost]
        public JsonResult QueryLevelById(long id)
        {
            var person = _levelService.QueryLevelById(id);
            return Json(person, JsonRequestBehavior.AllowGet);
        }

    }
}
