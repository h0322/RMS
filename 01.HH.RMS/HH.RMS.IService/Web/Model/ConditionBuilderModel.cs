using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService.Web.Model
{
    public class ConditionBuilderModel<T>
    {
        public string condition { get; set; }
        public void Build(Expression<Func<T, bool>> express,string tableName)
        {
            
        }
        
    }
}
