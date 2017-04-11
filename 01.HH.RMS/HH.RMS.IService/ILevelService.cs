using HH.RMS.Common.Constant;
using HH.RMS.IService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService
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
