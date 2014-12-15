

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Admin.Compoent.Tool;
using Admin.Demo.Core.Models.Security;

namespace Admin.Demo.Core.Models.Account
{
    /// <summary>
    ///     ʵ���ࡪ���û���Ϣ
    /// </summary>
    [Description("�û���Ϣ")]
    public class Member : EntityBase<int>
    {
        //public Member()
        //{
           
        //    LoginLogs = new List<LoginLog>();
        //}

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string NickName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// ��ȡ������ �û���չ��Ϣ
        /// </summary>     
        public virtual  MemberExtend Extend { get; set; }


        /// <summary>
        /// ��ȡ������ �û���¼��¼����
        /// </summary>
        public virtual ICollection<LoginLog> LoginLogs { get; set; }

        /// <summary>
        /// ��ȡ������ �û�ӵ�еĽ�ɫ��Ϣ����
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

    

    }
}