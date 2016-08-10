using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Repository.EntityFramework.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.EntityFramework
{
    public class RepositoryBase<T> :IRepository<T>, IDisposable where T:EntityBase
    {
        private DbContext _dbContext { get; set; }
        public int userId { get; set; }

        public RepositoryBase(DbContext _dbContext)
        {
            this._dbContext = _dbContext;
            this._dbContext.Configuration.AutoDetectChangesEnabled = false;
        }


        public T Find(long id)
        {
            return this._dbContext.Set<T>().Find(id);
        }

        public void Delete(T t)
        {
            RemoveHoldingEntityInContext(t);
            //this._dbContext.Set<T>().Remove(t);
            _dbContext.Set<T>().Attach(t);
            var entry = this._dbContext.Entry<T>(t);
            entry.State = EntityState.Deleted;
            this._dbContext.SaveChanges();
        }

        public IQueryable<T> QueryAsNoTracking()
        {
            using (DbContext db = new DbContext(Config.sqlConnStr))
            {
                return db.Set<T>().AsNoTracking();
            }
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> express = null,bool isNoTracking = true)
        {
            if (isNoTracking)
            {
                if (express != null)
                {
                    return this._dbContext.Set<T>().Where(express).Where(m => m.isActive).AsNoTracking();
                }
                return this._dbContext.Set<T>().Where(m => m.isActive).AsNoTracking();
            }
            else
            {
                if (express != null)
                {
                    return this._dbContext.Set<T>().Where(express).Where(m => m.isActive);
                }
                return this._dbContext.Set<T>().Where(m=>m.isActive);
            }
        }
        public IQueryable<T> Query(string include)
        {
            return this._dbContext.Set<T>().Where(m => m.isActive).Include(include);
        }

        //public IQueryable<SchedulerEntity> Query()
        //{
        //    return this._dbContext.Set<SchedulerEntity>().Include(m=>m.job);
        //}
        public void Update(T t)
        {
            RemoveHoldingEntityInContext(t);

            if (!t.updateBy.HasValue)
            {
                t.updateBy = this.userId;
            }
            t.updateTime = DateTime.Now;
            this._dbContext.Set<T>().Attach(t);
            var entry = this._dbContext.Entry<T>(t);
            entry.State = EntityState.Modified;
            this._dbContext.SaveChanges();
            //RepositoryTrigger.Execute(t, this._dbContext);
        }

        public void Insert(T t)
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
            _dbContext.Set<T>().Attach(t);
            var entry = this._dbContext.Entry<T>(t);
            entry.State  = EntityState.Added;
            //db.Entry(blog).State = EntityState.Modified;
            this._dbContext.SaveChanges();
            //RepositoryTrigger.Execute(t, this._dbContext);
        }

        #region sp

        public IEnumerable<T> SqlQuery(string sql, params object[] parameters)
        {
            return this._dbContext.Database.SqlQuery<T>(sql, parameters);
        }

        public int ExecuteSql(string sql, params object[] parameters)
        {
            return this._dbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        #endregion sp

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        private Boolean RemoveHoldingEntityInContext(T entity)
        {
            var objContext = ((IObjectContextAdapter)_dbContext).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

            Object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);

            if (exists)
            {
                objContext.Detach(foundEntity);
            }

            return (exists);
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
    }
}
