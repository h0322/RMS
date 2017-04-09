using HH.RMS.Common.Constant;
using HH.RMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using HH.RMS.Repository.Mapping;
using HH.ProjectMovie.Entity;

namespace HH.ProjectMovie.Repository
{
    public class MovieDbContext : ApplicationDbContext
    {
        public MovieDbContext(string sqlConnStr = "")
            : base(string.IsNullOrEmpty(sqlConnStr) ? Config.sqlConnStr : sqlConnStr)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MappingTableBase<FilmManEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<FilmManImageEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<VideoActorEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<VideoImageEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<VideoPlayerEntity>());
            modelBuilder.Configurations.Add(new MappingTableBase<VideoTagEntity>());
            base.OnModelCreating(modelBuilder);
        }
        public void Dispose()
        {
 
        }
    }
}
