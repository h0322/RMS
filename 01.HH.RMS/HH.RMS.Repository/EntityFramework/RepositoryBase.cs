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
        //private DbContext _dbContext { get; set; }
        public long userId { get; set; }
        //public T SetDefaultValue()
        //{
        //    T t = new T();
        //    t.up
        //    return t;
        //}
        //public RepositoryBase(DbContext _dbContext)
        //{
        //    this._dbContext = _dbContext;
        //    //this._dbContext.Configuration.AutoDetectChangesEnabled = false;
        //}
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
            //if (isNoTracking)
            //{
            //    if (express != null)
            //    {
            //        return this._dbContext.Set<T>().Where(express).Where(m => m.isActive).AsNoTracking();
            //    }
            //    return this._dbContext.Set<T>().Where(m => m.isActive).AsNoTracking();
            //}
            //else
            //{
            //    if (express != null)
            //    {
            //        return this._dbContext.Set<T>().Where(express).Where(m => m.isActive);
            //    }
            //    return this._dbContext.Set<T>().Where(m=>m.isActive);
            //}
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
        public void Update(ApplicationDbContext db, Expression<Func<T, T>> updater, Expression<Func<T, bool>> condition)
        {
            db.Set<T>().Where(condition).Update(updater);
            db.SaveChanges();
        }

        public Expression<Func<T, T>> UpdateCondition()
        {
            return m => new T() { updateBy = 1 ,updateTime = DateTime.Now};
        }

        public void Insert(ApplicationDbContext db, T t)
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
            db.SaveChanges();
        }

        #region sp

        public IEnumerable<T> SqlQuery(ApplicationDbContext db,string sql, params object[] parameters)
        {
            return db.Database.SqlQuery<T>(sql, parameters);
        }

        public int ExecuteSql(ApplicationDbContext db,string sql, params object[] parameters)
        {
            return db.Database.ExecuteSqlCommand(sql, parameters);
        }

        #endregion sp


        public static Expression<Func<T, T>> And<T>(Expression<Func<T, T>> expr1,
                                                        Expression<Func<T, T>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, T>>(Expression.And(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public void Dispose(ApplicationDbContext db)
        {
            db.Dispose();
        }

        public Expression<Func<T, T>> UpdateEntity(T t)
        {
            t.updateBy = 1;
            t.updateTime = DateTime.Now;
            return m=>t;
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
        public ResultType ExecuteDataSetSql<T>(string sqlString,SqlScriptType sqlType,SqlParameter[] sqlParameters)
        {
            return ResultType.Success;
        }
        public ResultType ExecuteNonQuerySql<T>(string sqlString, SqlScriptType sqlType, SqlParameter[] sqlParameters)
        {
            return ResultType.Success;

        }
        public ResultType ExecuteReaderSql<T>(string sqlString, SqlScriptType sqlType, SqlParameter[] sqlParameters)
        {
            return ResultType.Success;

        }
        public ResultType ExecuteScalarSql<T>(string sqlString, SqlScriptType sqlType, SqlParameter[] sqlParameters)
        {
            return ResultType.Success;

        }
    }

}
