﻿using HH.RMS.Entity;
using HH.RMS.IService.Model;
using HH.RMS.IService.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Location
{
    public interface IProvinceService
    {
        List<ProvinceModel> QueryProvinceList();
    }
}