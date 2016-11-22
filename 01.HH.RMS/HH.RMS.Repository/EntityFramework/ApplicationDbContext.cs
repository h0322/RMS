using HH.RMS.Common.Constant;
using HH.RMS.Entity.Scheduler;
using HH.RMS.Entity.Web;
using HH.RMS.Entity.Wechat;
using HH.RMS.Repository.EntityFramework.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.EntityFramework
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
            : base(Config.sqlConnStr)
        {
            this.Database.Initialize(false);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMapping());
            modelBuilder.Configurations.Add(new PersonMapping());
            modelBuilder.Configurations.Add(new LogMapping());
            modelBuilder.Configurations.Add(new SchedulerMapping());
            modelBuilder.Configurations.Add(new JobMapping());
            modelBuilder.Configurations.Add(new SchedulerLogMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
            modelBuilder.Configurations.Add(new MappingTableBase<MenuEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<MenuRoleEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<CountryEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<ProvinceEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<CityEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<LevelEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<JobParameterEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<WechatConfigEntity>());
            base.OnModelCreating(modelBuilder);
        }
        public void CreateExcute()
        {
 
        }
        //public DataSet ExecuteDataSetSql(ApplicationDbContext db, string sqlString, SqlScriptType sqlType, SqlParameter[] sqlParameters)
        //{
        //    return null;
        //}
        //public int ExecuteNonQuerySql(string sqlString, SqlScriptType sqlType, SqlParameter[] sqlParameters)
        //{
        //    this.sq
        //    return 0;

        //}
        //public object ExecuteScalarSql(string sqlString, SqlScriptType sqlType, SqlParameter[] sqlParameters)
        //{

        //    return ResultType.Success;

        //}
        //public DbSet<AccountEntity> Account { get; set; }
        //public DbSet<PersonEntity> Person { get; set; }
        //public DbSet<SchedulerLogEntity> Scheduler { get; set; }
        
    }
}
