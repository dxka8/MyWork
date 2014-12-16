using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Component.Data;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.Core.Data.Configrations.Account
{
    public class MemberConfiguraction : EntityTypeConfiguration<Member>, IEntityMapper
    {
        //　HasMany(m => m.LoginLogs).WithRequired(n => n.Member);主体配置方式
        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
