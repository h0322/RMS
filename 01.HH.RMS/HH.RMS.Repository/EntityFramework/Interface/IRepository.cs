using HH.RMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.EntityFramework.Interface
{
    public interface IRepository<T> where T : EntityBase
    {
        void Delete(ApplicationDbContext db, T t);

        T Find(ApplicationDbContext db, long id);

        void Insert(ApplicationDbContext db, T entity);

        int UserID { get; set; }

        IQueryable<T> Query(ApplicationDbContext db, Expression<Func<T, bool>> express = null, bool isNoTracking = true);
        IQueryable<T> Query(ApplicationDbContext db, string include);
        IEnumerable<T> SqlQuery(ApplicationDbContext db, string sql, params object[] parameters);
        int ExecuteSql(ApplicationDbContext db, string sql, params object[] parameters);
        void Update(ApplicationDbContext db,Expression<Func<T, T>> updater, Expression<Func<T, bool>> condition);
        void Dispose(ApplicationDbContext db);
        Expression<Func<T, T>> UpdateEntity(T t);
        //void MassUpdate(ApplicationDbContext db,Expression<Func<T, T>> updater, Expression<Func<T, bool>> condition);
    }
}
