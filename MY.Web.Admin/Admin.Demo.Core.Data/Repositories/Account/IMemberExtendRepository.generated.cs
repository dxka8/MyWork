﻿
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Admin.Component.Data;
using Admin.Demo.Core.Models.Account;


namespace Admin.Demo.Core.Data.Repositories.Account
{
    /// <summary>
    /// 仓储操作层接口——用户扩展信息
    /// </summary>    
	public partial interface IMemberExtendRepository : IRepository<MemberExtend,Int32>
    {
       
    }
}
