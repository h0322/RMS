using HH.RMS.Entity.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.EntityFramework.Mapping
{
    public class AccountMapping : MappingTableBase<AccountEntity>
    {
        public int i = 0;
        public override void TableProperty()
        {
            this.Property(t => t.personId).IsRequired();
            base.TableProperty();
        }
    }
}
