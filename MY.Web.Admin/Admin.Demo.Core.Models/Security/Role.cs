using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Compoent.Tool;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.Core.Models.Security
{
    [Description("角色信息")]
    public class Role : EntityBase<int>
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置 角色类型的数值表示，用于数据库存储
        /// </summary>
        public int RoleTypeNum { get; set; }
            
        /// <summary>
        /// 获取或设置 角色类型
        /// </summary>
        public RoleType RoleType { get; set; }

        public virtual ICollection<Member> Members { get; set; }

    }
}
