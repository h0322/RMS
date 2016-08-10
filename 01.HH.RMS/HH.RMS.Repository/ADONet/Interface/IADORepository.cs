using HH.RMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.ADONet.Interface
{
    public interface IADORepository<T>
    {
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="entity"></param>
        int Insert(T entity);

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="predicate"></param>
        int Update(T entity, Expression<Func<T, bool>> express);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="predicate"></param>
        int Delete(Expression<Func<T, bool>> express = null);

        /// <summary>
        /// 查询对象集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<T> QueryAll(Expression<Func<T, bool>> express = null);

        /// <summary>
        /// 查询对象集合
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pagesize"></param>
        /// <param name="order"></param>
        /// <param name="asc"></param>
        /// <param name="express"></param>
        /// <returns></returns>
        List<T> QueryByPager(int index, int pagesize, List<SortConditionModel> orderFields, Expression<Func<T, bool>> express = null);

        /// <summary>
        /// 查询对象集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<object> QueryAll(string commandText, List<Type> typeList, IDictionary<string, object> parameters, CommandType commandType = CommandType.Text, Expression<Func<T, bool>> express = null);

        List<object> QueryAll(string commandText, Type type, IDictionary<string, object> parameters, CommandType commandType = CommandType.Text, Expression<Func<T, bool>> express = null);
        /// <summary>
        /// 查询对象
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Query(Expression<Func<T, bool>> express);

        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int QueryCount(Expression<Func<T, bool>> express = null);
    }
}
