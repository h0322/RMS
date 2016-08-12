using HH.RMS.Entity;
using HH.RMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Interface
{
    public interface IProvinceService
    {
        List<ProvinceModel> QueryProvinceList();
    }
}
