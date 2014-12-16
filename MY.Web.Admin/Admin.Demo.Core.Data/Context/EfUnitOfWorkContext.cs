using System.Data.Entity;
using Admin.Component.Data.EntityFramework;

namespace Admin.Demo.Core.Data.Context
{
    /// <summary>
    ///     Demo项目单元操作类
    /// </summary>   
    public class EfUnitOfWorkContext : EfUnitOfWorkContextBase
    {
        public EfUnitOfWorkContext(DbContext dbContext)
        {

            DbContext = dbContext;
        }
        public EfUnitOfWorkContext()
        {

            
        }

        /// <summary>
        ///     获取或设置 默认的Demo项目数据访问上下文对象
        /// </summary>      
        public new DbContext DbContext { get; set; }



        /// <summary>
        /// 给上下文赋值
        /// </summary>
        protected override DbContext Context
        {
            get { return DbContext; }
        }
    }
}
