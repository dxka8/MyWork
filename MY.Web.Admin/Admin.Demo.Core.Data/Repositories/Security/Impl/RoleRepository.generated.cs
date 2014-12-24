
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Admin.Component.Data;
using Admin.Demo.Core.Models.Security;


namespace Admin.Demo.Core.Data.Repositories.Security
{
    /// <summary>
    /// 实体类-数据表映射——角色信息
    /// </summary>    
	public partial class RoleRepository : EfRepositoryBase<Role,Int32>, IRoleRepository
    {
        /// <summary>
        /// 实体类-数据表映射构造函数——角色信息
        /// </summary>
        public RoleRepository(IUnitOfWork unitOfWork)
        {
			 base.UnitOfWork = unitOfWork;
        }
    }
}
