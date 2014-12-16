using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Component.Data;
using Admin.Demo.Core.Models.Security;

namespace Admin.Demo.Core.Data.Configrations.security
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>, IEntityMapper
    {
        public RoleConfiguration()
        {
            HasMany(m => m.Members).WithMany(n => n.Roles);
        }


        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
