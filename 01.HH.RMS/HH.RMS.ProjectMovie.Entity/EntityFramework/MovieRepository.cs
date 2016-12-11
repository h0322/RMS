using HH.RMS.Entity;
using HH.RMS.Entity.EntityFramework;
using HH.RMS.Entity.EntityFramework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Entity.EntityFramework
{
    public class MovieRepository<T> : RepositoryBase<T>,IMovieRepository<T>,  IRepository<T> where T : EntityBase, new()
    {

    }
}
