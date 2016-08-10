using HH.RMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace HH.RMS.Repository.EntityFramework.Mapping
{
    public class MappingTableBase<T> : EntityTypeConfiguration<T> where T : class,new()
    {
        public MappingTableBase()
        {
            MappingTableAttribute attr = (MappingTableAttribute)typeof(T).GetCustomAttribute(typeof(MappingTableAttribute));
            this.ToTable(attr.tableName);
            TableProperty();
        }
        public virtual void TableProperty()
        {
            return;
        }
    }
}
