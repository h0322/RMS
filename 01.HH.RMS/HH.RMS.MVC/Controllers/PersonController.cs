using HH.RMS.Common.Constant;
using HH.RMS.Service.Web.Model;
using HH.RMS.Service.Web;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HH.RMS.Service.Model;
using HH.RMS.Service;

namespace HH.RMS.MVC.Controllers
{
    [RMSAuthorize]
    public class PersonController : ControllerService
    {
        //
        // GET: /Person/
        private IPersonService _personService;
        private IProvinceService _provinceService;
        private ICityService _cityService;
        private IRoleService _roleService;
        public PersonController(IPersonService personService, IProvinceService provinceService, ICityService cityService, IRoleService roleService)
        {
            _personService = personService;
            _provinceService = provinceService;
            _cityService = cityService;
            _roleService = roleService;

        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [RMSAuthorize(menuCode="Person",excuteType=(int)ExcuteType.Select)]
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
            return ProvinceModel.ToSelect();
        }
        public JsonResult QueryCityByProvinceId(long id)
        {
            return CityModel.ToSelect(id);
        }
          [HttpPost]
        public JsonResult QueryRoleList()
        {
            return RoleModel.ToSelect();
        }
          [HttpPost]
          public JsonResult QueryLevelList()
          {
              return LevelModel.ToSelect();
          }
        [RMSAuthorize(menuCode = "Person", excuteType = (int)ExcuteType.Insert)]
        public JsonResult CreatePersonAccount(AccountModel model)
        {
            ResultModel<ResultType> result =  _personService.CreatePersonAccount(model);
            return Json(result);
        }
        [RMSAuthorize(menuCode = "Person", excuteType = (int)ExcuteType.Select)]
        public JsonResult QueryPersonById(long id)
        {
            var person = _personService.QueryPersonById(id);
            return Json(person, JsonRequestBehavior.AllowGet);
        }
        [RMSAuthorize(menuCode = "Person", excuteType = (int)ExcuteType.Update)]
        public JsonResult UpdatePerson(PersonModel model)
        {
            var result = _personService.UpdatePersonById(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [RMSAuthorize(menuCode = "Person", excuteType = (int)ExcuteType.Delete)]
        public JsonResult DeletePersonById(long id)
        {
            return null;
        }
    }
}
