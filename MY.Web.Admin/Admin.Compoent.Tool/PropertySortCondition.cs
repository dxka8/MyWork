using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Compoent.Tool
{
    /// <summary>
    /// 属性排序条件信息类
    /// </summary>
    public class PropertySortCondition
    {
        /// <summary>
        ///  构造一个指定属性名称的升序排序的排序条件
        /// </summary>
        /// <param name="propertyName"></param>
        public  PropertySortCondition(string propertyName)
        {
            PropertyName = propertyName;
        }
        /// <summary>
        ///  构造一个排序属性名称和排序方式的排序条件
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="listSort"></param>
        public PropertySortCondition(string propertyName,ListSortDirection listSort)
        {
            PropertyName = propertyName;
            ListSortDirection = listSort;
        }
        /// <summary>
        /// 排序属性名称
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>

        public ListSortDirection ListSortDirection { get; set; }
    }
}
