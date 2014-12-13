using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.Core.Data.Configrations.Account
{
    public class LoginLogConfigration:EntityTypeConfiguration<LoginLog>
    {
        public LoginLogConfigration()
        {
            HasRequired(m => m.Member).WithMany(s => s.LoginLogs);
        }
    }
}
