using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.IService.Model;
using HH.RMS.IService.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Location
{
    public interface ICountryService
    {
        List<CountryModel> QueryCountryList();
        ResultType InsertCountry(CountryModel model);
        ResultType UpdateCountry(CountryModel model);
    }
}
