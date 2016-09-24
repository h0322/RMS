﻿using HH.RMS.Entity;
using HH.RMS.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Interface
{
    public interface ICityService
    {
        List<CityModel> QueryCityListByProvinceId(long provinceId);
        List<CityModel> QueryCityListAll();
    }
}
