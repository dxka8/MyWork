using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using Admin.Compoent.Tool;
using Admin.Compoent.Tool.Eum;
using Admin.Compoent.Tool.Unity;
using Admin.Demo.Core.Models.Account;
using Admin.Demo.Core.Models.Account.BusMode;
using Admin.Demo.ICore;
using Admin.Demo.ISite;
using Admin.Demo.Site.Models;

namespace Admin.Demo.Site.Impl
{
   
    public class AccountSiteService :  IAccountSiteContract
    {
        #region 0.1 Http上下文 及 相关属性
        /// <summary>
        /// Http上下文
        /// </summary>
        HttpContext ContextHttp
        {
            get
            {
                return HttpContext.Current;
            }
        }

        HttpResponse Response
        {
            get
            {
                return ContextHttp.Response;
            }
        }

        HttpRequest Request
        {
            get
            {
                return ContextHttp.Request;
            }
        }

        System.Web.SessionState.HttpSessionState Session
        {
            get
            {
                return ContextHttp.Session;
            }
        }
        #endregion


        private static IAccountContract AccountService { get; set; }
        public AccountSiteService(IAccountContract accountContract)
        {
            AccountService = accountContract;
        } 


        /// <summary>
        /// 用户登陆方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OperationResult Login(LoginModel model)
        {
                  
            //todo:model NUll
                var loginInfo = new LoginInfo()
                {
                    Account = model.Account,
                    IpAddress = "127.0.0.1",
                    Password = model.Password,
                };
                
                var result = AccountService.Login(loginInfo);
                if (result.ResultType == OperationResultType.Success)
                {                 
                    var member = (Member) result.AppendData;
                    if (model.IsRememberLogin)
                    {
                        CookieHelper.WriteCookie(CookieEum.AdminCookieName,CookieEum.AdminCookieMember,member.UserName+"#"+member.NickName);
                             
                    }
                    Session[CookieEum.AdminSessionMember] = member;
                    
                    result.AppendData = null;
                }
                return result;          
           
        }

        public void Logout()
        {
            Session[CookieEum.AdminSessionMember] = null;
            CookieHelper.WriteCookie(CookieEum.AdminCookieName, CookieEum.AdminCookieMember,"",-1);
        }


        public IQueryable<Member> Members
        {
            get { return AccountService.Members; }
        }

        public IQueryable<MemberExtend> MemberExtends
        {
            get { return AccountService.MemberExtends; }
        }

        public IQueryable<LoginLog> LoginLogs
        {
            get { return AccountService.LoginLogs; }
        }

        public IQueryable<Core.Models.Security.Role> Roles
        {
            get { return AccountService.Roles; }
        }
    }
}
