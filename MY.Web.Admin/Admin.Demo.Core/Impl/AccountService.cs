using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Compoent.Tool;
using Admin.Demo.Core.Data.Repositories.Account;
using Admin.Demo.Core.Data.Repositories.Security;
using Admin.Demo.Core.Models.Account;
using Admin.Demo.Core.Models.Account.BusMode;
using Admin.Demo.ICore;

namespace Admin.Demo.Core.Impl
{
    public  class AccountService:IAccountContract
    {

        #region 受保护的属性
        protected IMemberRepository MemberRepository { get; set; }

        public AccountService(IMemberRepository memberRepository)
        {
            MemberRepository = memberRepository;
        }
        protected IMemberExtendRepository MemberExtendRepository { get; set; }

        public AccountService(IMemberExtendRepository memberExtendRepository)
        {
            MemberExtendRepository = memberExtendRepository;
        }
        protected ILoginLogRepository LoginLogRepository { get; set; }

        public AccountService(ILoginLogRepository loginLogRepository)
        {
            LoginLogRepository = loginLogRepository;
        }
        protected IRoleRepository RoleRepository { get; set; }

        public AccountService(IRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
        } 
        #endregion

        #region 公共属性     
        public IQueryable<Member> Members
        {
            get { return MemberRepository.Entities; }
        }

        public IQueryable<MemberExtend> MemberExtends
        {
            get { return MemberExtendRepository.Entities; }
        }

        IQueryable<LoginLog> IAccountContract.LoginLogs
        {
            get { return LoginLogRepository.Entities; }
        }

        public IQueryable<Models.Security.Role> Roles
        {
            get { return RoleRepository.Entities; }
        } 
        #endregion

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
