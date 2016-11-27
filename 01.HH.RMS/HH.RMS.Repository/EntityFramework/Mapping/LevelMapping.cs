﻿using HH.RMS.Entity.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.EntityFramework.Mapping
{
    public class LevelMapping : EntityTypeConfiguration<LevelEntity>
    {
        public LevelMapping()
        {
            this.ToTable("AccountLevel");
        }
    }
}
