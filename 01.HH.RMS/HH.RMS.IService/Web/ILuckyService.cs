using HH.RMS.Common.Constant;
using HH.RMS.Common.Model;
using HH.RMS.Entity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Web
{
    public interface ILuckyService
    {
        ResultModel<LuckyPrizeModel> LuckyDraw(long accountId, long luckyDrawId);
        ResultType InsertLuckyDraw(LuckyPrizeModel model);
        List<LuckyPrizeModel> QueryLuckyPrizeByLuckyDrawId(long id);
        ResultType InsertLuckyPrize(LuckyPrizeModel model);
        List<LuckyLogModel> QueryLuckyLogByLuckyDrawId(long id);
        ResultType InsertLuckyLog(LuckyLogModel model);
        ResultType InsertLuckyResult(LuckyResultModel model);
        List<LuckyResultModel> QueryLuckyResultByLuckyDrawId(long id);
    }
}
