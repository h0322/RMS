using HH.RMS.Common.Constant;
using HH.RMS.Entity.Web;
using HH.RMS.Repository.EntityFramework.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            modelBuilder.Configurations.Add(new AccountRoleMapping());
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
            base.OnModelCreating(modelBuilder);
        }
        public void CreateExcute()
        {
 
        }
        //public DbSet<AccountEntity> Account { get; set; }
        //public DbSet<PersonEntity> Person { get; set; }
        //public DbSet<SchedulerLogEntity> Scheduler { get; set; }
        
    }
}
