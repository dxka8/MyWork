using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Admin.Component.Data.EntityFramework
{

    /// <summary>
    ///     单元操作实现
    /// </summary>
    public abstract class EfUnitOfWorkContextBase : IEfiUnitOfWorkContext
    {
      
        /// <summary>
        /// 获取 当前使用的数据访问上下文对象
        /// </summary>
        protected abstract DbContext Context { get; }

        public DbContext DbContext { get { return Context; } }

        /// <summary>
        ///     获取 当前单元操作是否已被提交
        /// </summary>
        public bool IsCommitted { get; private set; }

        /// <summary>
        /// 把操作单元回滚成未提交状态
        /// </summary>
        public void Rollback()
        {
            IsCommitted = false;
        }
        /// <summary>
        ///     提交当前单元操作的结果
        /// </summary>
        /// <param name="validateOnSaveEnabled">保存时是否自动验证跟踪实体</param>
        /// <returns></returns>
        public int Commit(bool validateOnSaveEnabled = true)
        {
            if (IsCommitted)
            {
                return 0;
            }
            try
            {
                int result = Context.SaveChanges();
                IsCommitted = true;
                return result;
            }
            catch (Exception e)
            {

                if (e.InnerException != null && e.InnerException.InnerException is SqlException)
                {
                    var sqlEx = e.InnerException.InnerException as SqlException;
                    var msg = DataHelper.GetSqlExceptionMessage(sqlEx.Number);
                    //todo:Error
                    //throw PublicHelper.ThrowDataAccessException("提交数据更新时发生异常：" + msg, sqlEx);
                }
                throw;
            }
        }


        public void Dispose()
        {
            if (!IsCommitted)
                Commit();
            Context.Dispose();
        }

        /// <summary>
        ///   为指定的类型返回 System.Data.Entity.DbSet，这将允许对上下文中的给定实体执行 CRUD 操作。
        /// </summary>
        /// <typeparam name="TEntity"> 应为其返回一个集的实体类型。 </typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns> 给定实体类型的 System.Data.Entity.DbSet 实例。 </returns>
        public DbSet<TEntity> Set<TEntity, TKey>() where TEntity : Compoent.Tool.EntityBase<TKey>
        {
            return Context.Set<TEntity>();
        }

        /// <summary>
        ///     注册一个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public void RegisterNew<TEntity, TKey>(TEntity entity) where TEntity : Compoent.Tool.EntityBase<TKey>
        {
            EntityState state = Context.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                Context.Entry(entity).State = EntityState.Added;
            }
            IsCommitted = false;
        }

        /// <summary>
        ///     批量注册多个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <typeparam name="TKey"></typeparam>
        public void RegisterNew<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : Compoent.Tool.EntityBase<TKey>
        {
            try
            {
                Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    RegisterNew<TEntity, TKey>(entity);
                }
            }
            finally
            {
                Context.Configuration.AutoDetectChangesEnabled = true;
            }   
        }
        /// <summary>
        ///  注册一个更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity"></param>
        public void RegistreModified<TEntity, TKey>(TEntity entity) where TEntity : Compoent.Tool.EntityBase<TKey>
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            Context.Entry(entity).State = EntityState.Modified;
            IsCommitted = false;
        }
        /// <summary>
        /// 注册一个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity"></param>
        public void RegistreDelete<TEntity, TKey>(TEntity entity) where TEntity : Compoent.Tool.EntityBase<TKey>
        {
            Context.Entry(entity).State = EntityState.Deleted;
            IsCommitted = false;
        }

        /// <summary>
        /// 批量注册多个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entities"></param>
        public void RegistreDelete<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : Compoent.Tool.EntityBase<TKey>
        {
            try
            {
                //在进行数据的变更时，EF默认会自动的跟踪数据的变化（AutoDetectChangesEnabled = true），当变更的数据量较大的时候，EF的跟踪工作量就会骤增，使指定操作变得非常缓慢（这也是部分同学怀疑EF的性能问题的一个怀疑点），其实，只要在批量操作的时候把自动跟踪关闭（AutoDetectChangesEnabled = false），即可解决缓慢的问题。
                Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    RegistreDelete<TEntity, TKey>(entity);
                }
                
            }
            finally
            {
                Context.Configuration.AutoDetectChangesEnabled = true;
            }
        }

       

    }
}

