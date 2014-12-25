using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
