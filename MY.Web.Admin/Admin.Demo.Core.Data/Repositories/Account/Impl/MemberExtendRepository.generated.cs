
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Admin.Component.Data;
using Admin.Demo.Core.Models.Account;


namespace Admin.Demo.Core.Data.Repositories.Account
{
    /// <summary>
    /// 实体类-数据表映射——用户扩展信息
    /// </summary>    
	public partial class MemberExtendRepository : EfRepositoryBase<MemberExtend,Int32>, IMemberExtendRepository
    {
        /// <summary>
        /// 实体类-数据表映射构造函数——用户扩展信息
        /// </summary>
        public MemberExtendRepository(IUnitOfWork unitOfWork)
        {
			 base.UnitOfWork = unitOfWork;
        }
    }
}
