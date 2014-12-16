using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Admin.Component.Data;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.Core.Data.Configrations.Account
{
    public class LoginLogConfiguration : EntityTypeConfiguration<LoginLog>, IEntityMapper
    {
        public LoginLogConfiguration()
        {
            HasRequired(m => m.Member).WithMany(s => s.LoginLogs);
        }

        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
