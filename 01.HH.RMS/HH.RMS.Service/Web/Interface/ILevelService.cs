using HH.RMS.Common.Constant;
using HH.RMS.Service.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Interface
{
    public interface ILevelService
    {
        List<LevelModel> QueryLevelList();
        ResultType CreateLevel(LevelModel model);
        ResultType UpdateLevel(LevelModel model);
        LevelModel QueryLevelById(long id);
        GridModel QueryLevelToGrid(PagerModel pager);
        ResultType DeleteLevelByIds(long[] ids);
    }
}
