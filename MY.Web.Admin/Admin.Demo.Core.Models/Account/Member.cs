using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Admin.Compoent.Tool;

namespace Admin.Demo.Core.Models.Account
{
    
        /// <summary>
        ///     实体类——用户信息
        /// </summary>
        [Description("用户信息")]
        public class Member : EntityBase<int>
        {
           

            /// <summary>
            /// 获取或设置 用户名
            /// </summary>
            [Required]
            [StringLength(20)]
            public string UserName { get; set; }

            /// <summary>
            /// 获取或设置 密码
            /// </summary>
            [Required]
            [StringLength(32)]
            public string Password { get; set; }

            /// <summary>
            /// 获取或设置 用户昵称
            /// </summary>
            [Required]
            [StringLength(20)]
            public string NickName { get; set; }

            /// <summary>
            /// 获取或设置 用户邮箱
            /// </summary>
            [Required]
            [StringLength(50)]
            public string Email { get; set; }

           
        }
    
}
