using HH.RMS.Model;
using HH.RMS.Service;
using HH.RMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HH.RMS.MVC.Controllers
{
    public class PersonController : ControllerService
    {
        //
        // GET: /Person/
        private IPersonService _personService;
        private IProvinceService _provinceService;
        private ICityService _cityService;
        public PersonController(IPersonService personService, IProvinceService provinceService, ICityService cityService)
        {
            _personService = personService;
            _provinceService = provinceService;
            _cityService = cityService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult QueryPersonToGrid(PagerModel pagerModel)
        {
            pagerModel.searchText = searchText;
            pagerModel.searchType = searchType;
            pagerModel.searchDateFrom = searchDateFrom;
            pagerModel.searchDateTo = searchDateTo;
            pagerModel.searchStatus = searchStatus;
            var model = _personService.QueryPersonToGrid(pagerModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult QueryProvinceList()
        {
            var provinceList = _provinceService.QueryProvinceList();
            List<SelectModel> selectList = new List<SelectModel>();
            selectList.Add(new SelectModel() { text = "---请选择---", value = "0" });
            provinceList.ForEach(m => selectList.Add(new SelectModel() { text = m.name, value = m.provinceId.ToString() }));
            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult QueryCityByProvinceId(long id)
        {
            List<SelectModel> selectList = new List<SelectModel>();
            var cityList = _cityService.QueryCityListByProvinceId(id);
            selectList.Add(new SelectModel() { text = "---请选择---", value = "0" });
            cityList.ForEach(m => selectList.Add(new SelectModel() { text = m.name, value = m.cityId.ToString() }));
            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
    }
}
