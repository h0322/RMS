using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity;
using HH.RMS.IService.Model;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nelibur.ObjectMapper;
using HH.RMS.Entity.Location;
using HH.RMS.IService.Model.Location;
using HH.RMS.IService.Location;

namespace HH.RMS.Service
{
    public class ProvinceService :  IProvinceService
    {
        private IRepository<ProvinceEntity> _provinceRepository;
        public ProvinceService(IRepository<ProvinceEntity> provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }
        public List<ProvinceModel> QueryProvinceList()
        {
            try
            { 
                using (var db = new ApplicationDbContext())
                {
                    var list = _provinceRepository.Query(db).ToList();

                    return TinyMapper.Map<List<ProvinceModel>>(list);
                }
                
            }
            catch (Exception ex)
            {
                Config.log.Error("ProvinceService.QueryProvinceList", ex);
                return null;
            }
        }
        public ResultType InsertCountry(ProvinceModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = TinyMapper.Map<ProvinceEntity>(model);
                    _provinceRepository.Insert(db, entity);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("CountryService.InsertCountry", ex);
                return ResultType.SystemError;
            }
        }
        public ResultType UpdateCountry(ProvinceModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    _provinceRepository.Update(db, m => new ProvinceEntity()
                    {
                        code = model.code,
                        name = model.name,
                        order = model.order,
                        remark = model.remark,
                        updateBy = AccountModel.CurrentSession.id,
                        updateTime = DateTime.Now
                    }, m => m.id == model.id);
                }
                return ResultType.Success;
            }
            catch (Exception ex)
            {
                Config.log.Error("CountryService.UpdateCountry", ex);
                return ResultType.SystemError;
            }
        }
    }
}
