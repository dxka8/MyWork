
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Admin.Component.Data;
using Admin.Demo.Core.Models.Account;


namespace Admin.Demo.Core.Data.Repositories.Account
{
    /// <summary>
    /// 实体类-数据表映射——登录记录信息
    /// </summary>    
	public partial class LoginLogRepository : EfRepositoryBase<LoginLog,Int32>, ILoginLogRepository
    {
        /// <summary>
        /// 实体类-数据表映射构造函数——登录记录信息
        /// </summary>
        public LoginLogRepository(IUnitOfWork unitOfWork)
        {
			 base.UnitOfWork = unitOfWork;
        }
    }
}
