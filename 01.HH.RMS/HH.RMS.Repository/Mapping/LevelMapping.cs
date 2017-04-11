using HH.RMS.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.Mapping
{
    public class LevelMapping : EntityTypeConfiguration<LevelEntity>
    {
        public LevelMapping()
        {
            this.ToTable("AccountLevel");
        }
    }
}
