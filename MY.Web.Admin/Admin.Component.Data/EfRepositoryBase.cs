using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Compoent.Tool;
using Admin.Compoent.Tool.Unity;
using Admin.Component.Data.EntityFramework;


namespace Admin.Component.Data
{
    
    public abstract class EfRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        protected EfRepositoryBase ()
        {
            if (UnitOfWork != null) return;
            new UnityHelper().ReflexRegisterInstance<IUnitOfWork>("IUnitOfWork");
            UnitOfWork = new UnityHelper().GetObject<IUnitOfWork>();
        }  
            /// <summary>
        /// 获取 仓储上下文的实例
        /// </summary>      
        public static IUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 获取或设置 EntityFramework的数据仓储上下文
        /// </summary>
        public IEfiUnitOfWorkContext EfContext
        {
            get
            {
                if (UnitOfWork is IEfiUnitOfWorkContext)
                {
                    return UnitOfWork as IEfiUnitOfWorkContext;
                }
                throw new DataAccessException(string.Format("数据仓储上下文对象类型不正确，应为IUnitOfWorkContext，实际为 {0}", UnitOfWork.GetType().Name));
            }
        }
        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        public virtual IQueryable<TEntity> Entities {

            get { return EfContext.Set<TEntity,TKey>(); }
            }

       

        public int Insert(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EfContext.RegisterNew<TEntity, TKey>(entity);
            return isSave ? EfContext.Commit() : 0;
        }

        public int Insert(IEnumerable<TEntity> entities, bool isSave = true)
        {
            PublicHelper.CheckArgument(entities, "entities");
            EfContext.RegisterNew<TEntity,TKey>(entities);
            return isSave ? EfContext.Commit() : 0;
        }

        public int Delete(TKey id, bool isSave = true)
        {
           PublicHelper.CheckArgument(id, "id");
           var entity=  EfContext.Set<TEntity, TKey>().Find(id);
           EfContext.RegistreDelete<TEntity, TKey>(entity);
           return isSave ? EfContext.Commit() : 0;
        }

        public int Delete(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EfContext.RegistreDelete<TEntity,TKey>(entity);
            return isSave ? EfContext.Commit() : 0;
        }

        public int Delete(IEnumerable<TEntity> entities, bool isSave = true)
        {
            PublicHelper.CheckArgument(entities, "entities");
            EfContext.RegistreDelete<TEntity,TKey>(entities);
            return isSave ? EfContext.Commit() : 0;
        }

        public int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, bool isSave = true)
        {
            PublicHelper.CheckArgument(predicate, "predicate");
            var entities = EfContext.Set<TEntity, TKey>().Where(predicate).ToList();
            EfContext.RegistreDelete<TEntity,TKey>(entities);
            return isSave ? EfContext.Commit() : 0;
        }

        public int Update(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EfContext.RegistreModified<TEntity,TKey>(entity);
            return isSave ? EfContext.Commit() : 0;
        }
        /// <summary>
        /// 使用附带新值的实体信息更新指定实体属性的值
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="isSave">是否执行保存</param>
        /// <param name="entity">附带新值的实体信息，必须包含主键</param>
        /// <returns>操作影响的行数</returns>
        public int Update(System.Linq.Expressions.Expression<Func<TEntity, object>> propertyExpression, TEntity entity, bool isSave = true)
        {
            throw new NotSupportedException("上下文公用，不支持按需更新功能。");
            PublicHelper.CheckArgument(propertyExpression, "propertyExpression");
            PublicHelper.CheckArgument(entity, "entity");
            //EFContext.RegisterModified<TEntity, TKey>(propertyExpression, entity);
            //if (isSave)
            //{
            //    var dbSet = EFContext.Set<TEntity, TKey>();
            //    dbSet.Local.Clear();
            //    var entry = EFContext.DbContext.Entry(entity);
            //    return EFContext.Commit(false);
            //}
            return 0;
        }

        public TEntity GetByKey(TKey key)
        {
            return EfContext.Set<TEntity, TKey>().Find(key);
        }
    }
}
