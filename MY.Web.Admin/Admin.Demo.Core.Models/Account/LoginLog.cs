using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Admin.Compoent.Tool;

namespace Admin.Demo.Core.Models.Account
{
    /// <summary>
    /// 实体类——登录记录信息
    /// </summary>
    [Description("登录记录信息")]
    public class LoginLog : EntityBase<Int32>
    {
        /// <summary>
        /// 初始化一个 登录记录实体类 的新实例
        /// </summary>
      

        [Required]
        [StringLength(15)]
        public string IpAddress { get; set; }

        /// <summary>
        /// 获取或设置 所属用户信息
        /// </summary>
        public virtual Member Member { get; set; }

        //public virtual ICollection<Member> Member { get; set; }
    }
}
