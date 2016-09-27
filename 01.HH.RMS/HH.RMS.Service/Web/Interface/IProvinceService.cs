using HH.RMS.Entity.Web;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Interface
{
    public interface IProvinceService
    {
        List<ProvinceModel> QueryProvinceList();
    }
}
