using HH.RMS.Entity;
using HH.RMS.Entity.Web;
using HH.RMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Repository.Interface
{
    public interface IMovieRepository<T>:IRepository<T> where T : EntityBase
    {
    }
}
