using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Component.Data;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.Core.Data.Configurations.Account
{
  
        partial class LoginLogConfiguration : EntityTypeConfiguration<LoginLog>, IEntityMapper
        {
            partial void LoginLogConfigurationAppend()
            {

                HasRequired(m => m.Member).WithMany(s => s.LoginLogs);
            }


        }
    
}
