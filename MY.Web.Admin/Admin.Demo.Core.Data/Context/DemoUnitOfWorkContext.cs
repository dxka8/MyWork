using System;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Reflection;
using Admin.Compoent.Tool.Unity;
using Admin.Component.Data;
using Admin.Component.Data.EntityFramework;

namespace Admin.Demo.Core.Data.Context
{
    /// <summary>
    ///     Demo项目单元操作类
    /// </summary>   
    public class EfDemoUnitOfWorkContext : EfUnitOfWorkContextBase
    {
        public EfDemoUnitOfWorkContext()
        {
            if (DbContext == null) return;
            var unity = new UnityHelper();
            unity.ReflexRegisterInstance<DbContext>("DbContext");
            DbContext = unity.GetObject<DbContext>();
        }

        /// <summary>
        ///     获取或设置 默认的Demo项目数据访问上下文对象
        /// </summary>      
        public DbContext DbContext { get; set; }



        /// <summary>
        /// 给上下文赋值
        /// </summary>
        protected override DbContext Context
        {
            get { return DbContext; }
        }
    }
}
