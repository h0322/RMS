using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web
{
    public class ServiceBase
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Expression<Func<T, T>> UpdateCondition<T>(T t)
        {

            return m=>t;
        }
    }
}
