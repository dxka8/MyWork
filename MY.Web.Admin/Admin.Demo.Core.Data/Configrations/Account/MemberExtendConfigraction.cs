using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.Core.Data.Configrations.Account
{
    public class MemberExtendConfigraction:EntityTypeConfiguration<MemberExtend>
    {
        public MemberExtendConfigraction()
        {
            HasRequired(m => m.Member).WithOptional(n => n.Extend);
        }
    }
}
