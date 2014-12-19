using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Demo.Core.Data.Configurations.Account
{
    partial class MemberExtendConfiguration
    {
        partial void MemberExtendConfigurationAppend()
        {
            HasRequired(m => m.Member).WithOptional(n => n.Extend);
        }
    }
}
