using HH.RMS.Common.Constant;
using HH.RMS.Common.Utilities;
using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
using HH.RMS.Repository.EntityFramework;
using HH.RMS.Repository.EntityFramework.Interface;
using HH.RMS.Service.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nelibur.ObjectMapper;

namespace HH.RMS.Service.Web
{
    public class ProvinceService : ServiceBase, IProvinceService
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
                log.Error("ProvinceService.QueryProvinceList", ex);
                return null;
            }
        }
    }
}
