using Admin.Compoent.Tool;
using Admin.Demo.Core.Models.Account;

namespace Admin.Demo.ICore
{
    /// <summary>
    ///     账户模块核心业务契约
    /// </summary>
    public interface IAccountContract   
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginInfo">登录信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult Login(LoginInfo loginInfo);
    }
}
