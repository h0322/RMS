using HH.ProjectMovie.Repository.Interface;
using HH.RMS.Entity;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Repository
{
    public class MovieRepository<T> : RepositoryBase<T>,IMovieRepository<T>,  IRepository<T> where T : EntityBase, new()
    {

    }
}
