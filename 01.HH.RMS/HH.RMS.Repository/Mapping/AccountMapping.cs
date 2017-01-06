using HH.RMS.Entity.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.Mapping
{
    public class AccountMapping : EntityTypeConfiguration<AccountEntity>
    {
        public AccountMapping()
        {
            //this.Property(t => t.personId).IsRequired();
            //base.TableProperty();
            this.ToTable("Account");
        }
    }
}
