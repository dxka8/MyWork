using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Compoent.Tool;
using Admin.Demo.Core.Data.Repositories.Account;
using Admin.Demo.Core.Models.Account;
using Admin.Demo.ICore;

namespace Admin.Demo.Core.Impl
{
    public  class AccountService:IAccountContract
    {
       
        public IMemberRepository MemberRepository { get; set; }

        public AccountService(IMemberRepository memberRepository)
        {
            MemberRepository=memberRepository;
        }
        private static readonly List<LoginLog> LoginLogs = new List<LoginLog>();
        public OperationResult Login(LoginInfo loginInfo)
        {
           
            if (loginInfo != null)
            {              
               var member= MemberRepository.Entities.SingleOrDefault(
                    m => m.UserName == loginInfo.Account || m.Email == loginInfo.Account);
                if (member == null)
                {
                    return new OperationResult(OperationResultType.QueryNull, "指定账号的用户不存在。");
                }
                if (member.Password != loginInfo.Password)
                {
                    return new OperationResult(OperationResultType.Success, "登陆密码不正确。");
                }
                var loginLog = new LoginLog {IpAddress = loginInfo.IpAddress, Member = member};
                LoginLogs.Add(loginLog);
                return new OperationResult(OperationResultType.Success, "登录成功。", member);
            }
            return null;

        }
    }
}
