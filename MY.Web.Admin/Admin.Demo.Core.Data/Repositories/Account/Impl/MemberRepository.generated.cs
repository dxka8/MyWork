
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Admin.Component.Data;
using Admin.Demo.Core.Models.Account;


namespace Admin.Demo.Core.Data.Repositories.Account
{
    /// <summary>
    /// 实体类-数据表映射——用户信息
    /// </summary>    
	public partial class MemberRepository : EfRepositoryBase<Member,Int32>, IMemberRepository
    {
        /// <summary>
        /// 实体类-数据表映射构造函数——用户信息
        /// </summary>
        public MemberRepository(IUnitOfWork unitOfWork)
        {
			 base.UnitOfWork = unitOfWork;
        }
    }
}
