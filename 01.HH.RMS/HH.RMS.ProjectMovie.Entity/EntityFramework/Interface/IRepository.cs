using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Entity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.EntityFramework.Interface
{
    public interface IMovieRepository<T>:IRepository<T> where T : EntityBase
    {
    }
}
