using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.Repository.EntityFramework.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using HH.RMS.Common.Utilities;
using System.Data.Common;
using HH.RMS.Entity;

namespace HH.RMS.Repository.EntityFramework
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase,new()
    {
        public long userId { get; set; }
        public RepositoryBase()
        {
            
        }

        public T Find(ApplicationDbContext db, long id)
        {
            return db.Set<T>().Find(id);
        }

        public void Delete(ApplicationDbContext db, T t)
        {
            db.Set<T>().Attach(t);
            var entry = db.Entry<T>(t);
            entry.State = EntityState.Deleted;
            db.SaveChanges();
        }


        public IQueryable<T> QueryAsNoTracking(ApplicationDbContext db)
        {
                return db.Set<T>().AsNoTracking();
        }

        public IQueryable<T> Query(ApplicationDbContext db, Expression<Func<T, bool>> express = null, bool isNoTracking = true)
        {
            if (isNoTracking)
            {
                if (express != null)
                {
                    return db.Set<T>().Where(express).Where(m => m.isActive).AsNoTracking();
                }
                return db.Set<T>().Where(m => m.isActive).AsNoTracking();
            }
            else
            {
                if (express != null)
                {
                    return db.Set<T>().Where(express).Where(m => m.isActive);
                }
                return db.Set<T>().Where(m => m.isActive);
            }
        }
        public IQueryable<T> Query(ApplicationDbContext db, string include)
        {
            return db.Set<T>().Where(m => m.isActive).Include(include);
        }
        public int Update(ApplicationDbContext db, Expression<Func<T, T>> updater, Expression<Func<T, bool>> condition)
        {
            return db.Set<T>().Where(condition).Update(updater);
        }
        public int Update(ApplicationDbContext db,T entity)
        {
            if (!entity.updateBy.HasValue)
            {
                entity.updateBy = this.userId;
            }
            entity.updateTime = DateTime.Now;
            db.Set<T>().Attach(entity);
            var entry = db.Entry<T>(entity);
            entry.State = EntityState.Modified;
            return  db.SaveChanges();
        }

        public Expression<Func<T, T>> DeleteEntity()
        {
            return m => new T() { updateBy = 1 ,updateTime = DateTime.Now, isActive=false};
        }
        public int Insert(ApplicationDbContext db, T t)
        {
            if (t.createBy == 0)
            {
                t.createBy = this.userId;
            }
            if (!t.updateBy.HasValue)
            {
                t.updateBy = this.userId;
            }
            t.createTime = DateTime.Now;
            t.updateTime = DateTime.Now;
            t.isActive = true;
            db.Set<T>().Attach(t);
            var entity = db.Entry(t);
            entity.State = EntityState.Added;
            return db.SaveChanges();
        }

        #region sp

        public IEnumerable<T> SqlQuery(ApplicationDbContext db,string sql, params object[] parameters)
        {
            if (parameters == null)
            {
                parameters = new object[0];
            }
            return db.Database.SqlQuery<T>(sql, parameters);
        }

        public int ExecuteSql(ApplicationDbContext db,string sql, params object[] parameters)
        {
            if (parameters == null)
            {
                parameters = new object[0];
            }
            return db.Database.ExecuteSqlCommand(sql, parameters);
        }

        #endregion sp



        public void Dispose(ApplicationDbContext db)
        {
            db.Dispose();
        }



        public int UserID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #region ADO.NET
        public int ExecuteNonQuerySql(ApplicationDbContext db, string sqlString, SqlScriptType sqlType, SqlParameter[] sqlParameters)
        {
            return 0;

        }

        public object ExecuteScalarSql(string sqlString, SqlScriptType sqlType, SqlParameter[] sqlParameters)
        {

            return ResultType.Success;

        }
        #endregion
    }

}
