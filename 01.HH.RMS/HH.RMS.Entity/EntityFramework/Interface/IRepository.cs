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
    public interface IRepository<T> where T : EntityBase
    {
        void Delete(ApplicationDbContext db, T t);
        T Find(ApplicationDbContext db, long id);
        int Insert(ApplicationDbContext db, T entity);
        long userId { get; set; }
        IQueryable<T> Query(ApplicationDbContext db, Expression<Func<T, bool>> express = null, bool isNoTracking = true);
        IQueryable<T> Query(ApplicationDbContext db, string include);
        IEnumerable<T> SqlQuery(ApplicationDbContext db, string sql, params object[] parameters);
        int ExecuteSql(ApplicationDbContext db, string sql, params object[] parameters);
        int Update(ApplicationDbContext db, Expression<Func<T, T>> updater, Expression<Func<T, bool>> condition);
        void Dispose(ApplicationDbContext db);
        Expression<Func<T, T>> DeleteEntity();
        int Update(ApplicationDbContext db, T entity);

    }
}
