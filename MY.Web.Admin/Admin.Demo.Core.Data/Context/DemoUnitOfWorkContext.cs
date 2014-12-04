using System;
using System.ComponentModel.Composition;
using System.Data.Entity;
using Admin.Component.Data;
using Admin.Component.Data.EntityFramework;

namespace Admin.Demo.Core.Data.Context
{
    /// <summary>
    ///     Demo项目单元操作类
    /// </summary>
    [Export(typeof(IUnitOfWork))]
    public class EfDemoUnitOfWorkContext : EfUnitOfWorkContextBase
    {
      

        /// <summary>
        ///     获取或设置 默认的Demo项目数据访问上下文对象
        /// </summary>
        [Import(typeof(DbContext))]
        public  DemoDbContext DemoDbContext { get; set; }

        protected override DbContext Context
        {
            get { throw new NotImplementedException(); }
        }
    }
}
