
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Admin.Component.Data;
using Admin.Demo.Core.Models.Security;


namespace Admin.Demo.Core.Data.Repositories.Security
{
    /// <summary>
    /// 仓储操作层接口——角色信息
    /// </summary>    
	public partial interface IRoleRepository : IRepository<Role,Int32>
    {
       
    }
}
