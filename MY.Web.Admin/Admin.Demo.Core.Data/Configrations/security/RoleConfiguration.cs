using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Demo.Core.Models.Security;

namespace Admin.Demo.Core.Data.Configrations.security
{
    public class RoleConfiguration:EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasMany(m => m.Members).WithMany(n => n.Roles);
        }
       
    }
}
