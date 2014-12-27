using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Admin.Component.Data;

namespace Admin.Compoent.Tool.Extensions
{
    public static class CollectionsExtensions
    {
        #region 公共方法

        #region IEnumerable的扩展
        /// <summary>
        /// 将集合展开并分别转换成字符串，再以指定的分隔符衔接，拼成一个字符串返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string ExpandAndToString<T>(this IEnumerable<T> collection, string separator)
        {        
            var enumerable = collection as List<T> ?? collection.ToList();
            if (enumerable.IsEmpty())
            {
                return null;
            }
            var result = enumerable.Cast<object>().Aggregate<object, string>(null, (a, b) => a + string.Format("{0}{1}", a, (b != null && !string.IsNullOrEmpty(b.ToString()) ? separator : "")));
           return result.Substring(0,result.Length-separator.Length);
        }
  
        /// <summary>
        /// 集合是否为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns>为空返回True，不为空返回False </returns>
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            return !collection.Any();
        }

        /// <summary>
        /// 根据第三方条件是否为真来决定是否执行指定条件的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        ///  根据指定条件返回集合中不重复的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="sourec"></param>
        /// <param name="keyselector"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T,TKey>(this IEnumerable<T> sourec,Func<T,TKey> keyselector)
        {
           return sourec.GroupBy(keyselector).Select(group => group.First());
        }


        #endregion

        #region IQueryable的扩展
        /// <summary>
        ///     根据第三方条件是否为真来决定是否执行指定条件的查询
        /// </summary>
        /// <param name="source"> 要查询的源 </param>
        /// <param name="predicate"> 查询条件 </param>
        /// <param name="condition"> 第三方条件 </param>
        /// <typeparam name="T"> 动态类型 </typeparam>
        /// <returns> 查询的结果 </returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
        {
            PublicHelper.CheckArgument(predicate, "predicate");
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要查询的源</param>
        /// <param name="propertyName">排序字段名字</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName,
            ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            PublicHelper.CheckArgument(propertyName, "propertyName");
            return QueryableHelper<T>.OrderBy(source, propertyName, sortDirection);
        }

        /// <summary>
        ///     把IQueryable[T]集合按指定属性排序条件进行排序
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要排序的数据集</param>
        /// <param name="sortCondition">列表属性排序条件</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, PropertySortCondition sortCondition)
        {
            PublicHelper.CheckArgument(sortCondition, "sortCondition");
            return source.OrderBy(sortCondition.PropertyName, sortCondition.ListSortDirection);
        }
        /// <summary>
        ///     把IOrderedQueryable[T]集合继续按指定属性排序方式进行排序
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要排序的数据集</param>
        /// <param name="propertyName">排序属性名</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName,
            ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            PublicHelper.CheckArgument(propertyName, "propertyName");
            return QueryableHelper<T>.ThenBy(source, propertyName, sortDirection);
        }

        /// <summary>
        ///     把IOrderedQueryable[T]集合继续指定属性排序方式进行排序
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要排序的数据集</param>
        /// <param name="sortCondition">列表属性排序条件</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, PropertySortCondition sortCondition)
        {
            PublicHelper.CheckArgument(sortCondition, "sortCondition");
            return source.ThenBy(sortCondition.PropertyName, sortCondition.ListSortDirection);
        }

        public static IQueryable<TEntity> Where<TEntity, TKey>(this IQueryable<TEntity> source,Expression<Func<TEntity,bool>> predicate,int pageIndex,int pageSize,out int total, PropertySortCondition[] sortConditions)where TEntity :EntityBase<TKey>
        {
            
            PublicHelper.CheckArgument(predicate, "predicate");
            PublicHelper.CheckArgument(sortConditions, "sortCondition");
            PublicHelper.CheckArgument(pageIndex, "pageIndex");
            PublicHelper.CheckArgument(pageSize, "pageSize");
            total = source.Count(predicate);
            if (sortConditions == null || sortConditions.Length == 0)
            {
                source=source.OrderBy(a => a.Id);
            }
            else
            {
                var count = 0;
                IOrderedQueryable<TEntity> orderSource = null;
                foreach (var sortCondition in sortConditions)
                {
                    orderSource = count == 0 ? source.OrderBy(sortCondition) : orderSource.ThenBy(sortCondition);
                    count++;
                }
                source = orderSource;
            }
            return source != null?source.Where(predicate).Skip((pageIndex - 1) * pageSize).Take(pageSize)
                : Enumerable.Empty<TEntity>().AsQueryable();
                
        }
        #endregion

        #endregion

        #region 辅助操作类

        private static readonly ConcurrentDictionary<string, LambdaExpression> Cache = new ConcurrentDictionary<string, LambdaExpression>();
    
        private static class QueryableHelper<T>
        {
            internal static IOrderedQueryable<T> OrderBy(IQueryable<T> source, string propertyName, ListSortDirection sortDirection)
            {
                dynamic keySelector = GetLambdaExpression(propertyName);
                return sortDirection == ListSortDirection.Ascending
                    ? Queryable.OrderBy(source, keySelector)
                    : Queryable.OrderByDescending(source, keySelector);
            }
            internal static IOrderedQueryable<T> ThenBy(IQueryable<T> source, string propertyName, ListSortDirection sortDirection)
            {
                dynamic keySelector = GetLambdaExpression(propertyName);
                return sortDirection == ListSortDirection.Ascending
                    ? Queryable.OrderBy(source, keySelector)
                    : Queryable.OrderByDescending(source, keySelector);
            }

            private static LambdaExpression GetLambdaExpression(string propertyName)
            {
                if (Cache.ContainsKey(propertyName))
                {
                    return Cache[propertyName];
                }
                ParameterExpression param = Expression.Parameter(typeof(T));
                MemberExpression body = Expression.Property(param, propertyName);
                LambdaExpression keySelector = Expression.Lambda(body, param);
                Cache[propertyName] = keySelector;
                return keySelector;
            }
        }
        #endregion
    }

    
}
