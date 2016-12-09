using HH.RMS.Entity;
using HH.RMS.Entity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Entity.EntityFramework
{
    public class RepositoryMovie<T> : RepositoryBase<T> where T : EntityBase, new()
    {

    }
}
