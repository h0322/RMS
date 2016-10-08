﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Model
{
    public class SortConditionModel
    {
                  /// <summary>
          ///     构造一个指定属性名称的升序排序的排序条件
         /// </summary>
         /// <param name="propertyName">排序属性名称</param>
         public SortConditionModel(string propertyName)
             : this(propertyName, ListSortDirection.Ascending) { }
 
         /// <summary>
         ///     构造一个排序属性名称和排序方式的排序条件
         /// </summary>
        /// <param name="propertyName">排序属性名称</param>
         /// <param name="listSortDirection">排序方式</param>
         public SortConditionModel(string propertyName, ListSortDirection listSortDirection)
         {
             PropertyName = propertyName;
             ListSortDirection = listSortDirection;
         }
 
         /// <summary>
         ///     获取或设置 排序属性名称
         /// </summary>
         public string PropertyName { get; set; }
 
         /// <summary>
         ///     获取或设置 排序方向
         /// </summary>
         public ListSortDirection ListSortDirection { get; set; }
    }
}