using System;
using System.Collections.Generic;
using System.Data.Entity;
using Admin.Compoent.Tool;

namespace Admin.Component.Data.EntityFramework
{
    /// <summary>
    ///     数据单元操作接口
    /// </summary>   
    public interface IEfiUnitOfWorkContext : IUnitOfWork, IDisposable
    {

        /// <summary>
        ///   为指定的类型返回 System.Data.Entity.DbSet，这将允许对上下文中的给定实体执行 CRUD 操作。
        /// </summary>
        /// <typeparam name="TEntity"> 应为其返回一个集的实体类型。 </typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns> 给定实体类型的 System.Data.Entity.DbSet 实例。 </returns>
        DbSet<TEntity> Set<TEntity, TKey>() where TEntity : Compoent.Tool.EntityBase<TKey>;
        /// <summary>
        /// 注册一个新的对象到上下文仓储
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity"></param>
        void RegisterNew<TEntity, TKey>(TEntity entity) where TEntity : EntityBase<TKey>;
        /// <summary>
        /// 批量注册多个新的对象到上下文仓储
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity"></param>
        void RegisterNew<TEntity, TKey>(IEnumerable<TEntity> entity) where TEntity : EntityBase<TKey>;
        /// <summary>
        /// 注册一个修改对象到上下文仓储
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity"></param>
        void RegistreModified<TEntity, TKey>(TEntity entity) where TEntity : EntityBase<TKey>;
        /// <summary>
        /// 注册一个删除对象到上下文仓储
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity"></param>
        void RegistreDelete<TEntity, TKey>(TEntity entity) where TEntity : EntityBase<TKey>;
        /// <summary>
        /// 注册一批删除对象到上下文仓储
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity"></param>
        void RegistreDelete<TEntity, TKey>(IEnumerable<TEntity> entity) where TEntity : EntityBase<TKey>;

    }
}