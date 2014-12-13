using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Demo.Core.Models.Security
{
    [Description("角色类型")]
    public enum RoleType
    {
        [Description("用户")]
        Uesr=0,
        [Description("管理员")]
        Admin=1
    }

    
}
