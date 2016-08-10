using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.ADONet.Interface
{
    public interface IADOContext
    {
        /// <summary>
        /// 注册新对象到上下文
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        int ExecuteNonQuery(string commandText, CommandType commandType, IDictionary<string, object> parameters = null);

        /// <summary>
        ///  查询对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <param name="load">自定义处理</param>
        /// <returns></returns>
        List<T> ReadValues<T>(string commandText, CommandType commandType, IDictionary<string, object> parameters = null, Func<IDataReader, T> load = null) where T : class, new();

        /// <summary>
        /// 查询对象集合
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <param name="setItem"></param>
        /// <returns></returns>
        List<object> ReadValues(string commandText, CommandType commandType, Type type, IDictionary<string, object> parameters = null, Action<dynamic> setItem = null);

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <param name="excute"></param>
        /// <returns></returns>
        T ExecuteReader<T>(string commandText, CommandType commandType, IDictionary<string, object> parameters = null, Func<IDataReader, T> load = null) where T : class,new();

        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        object ExecuteScalar(string commandText, CommandType commandType, IDictionary<string, object> parameters = null);
    }
}
