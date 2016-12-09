using HH.RMS.Common.Constant;
using HH.RMS.Entity.Scheduler;
using HH.RMS.Entity.Web;
using HH.RMS.Entity.Wechat;
using HH.RMS.Entity.EntityFramework.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity.EntityFramework
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(string sqlConnStr="")
            : base(string.IsNullOrEmpty(sqlConnStr)?Config.sqlConnStr:sqlConnStr)
        {
            this.Database.Initialize(false);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMapping());
            modelBuilder.Configurations.Add(new LevelMapping());
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
            //modelBuilder.Configurations.Add(new MappingTableBase<LevelEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<JobParameterEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<WechatConfigEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<LuckyDrawEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<LuckyLogEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<LuckyPrizeEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<LuckyResultEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<VoteEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<VoteBoxEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<VoteLogEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<ResetPasswordLogEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<EmailLogEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<EmailEntity>());
            base.OnModelCreating(modelBuilder);
        }
        public void CreateExcute()
        {
 
        }       
    }
}
