﻿
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Admin.Component.Data;
using Admin.Demo.Core.Models.Security;


namespace Admin.Demo.Core.Data.Configurations.Security
{
    /// <summary>
    /// 实体类-数据表映射——角色信息
    /// </summary>    
    internal partial class RoleConfiguration : EntityTypeConfiguration<Role>, IEntityMapper
    {
        /// <summary>
        /// 实体类-数据表映射构造函数——角色信息
        /// </summary>
        public RoleConfiguration()
        {
			RoleConfigurationAppend();
        }
		
        /// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void RoleConfigurationAppend();
		
        /// <summary>
        /// 将当前实体映射对象注册到当前数据访问上下文实体映射配置注册器中
        /// </summary>
        /// <param name="configurations">实体映射配置注册器</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
