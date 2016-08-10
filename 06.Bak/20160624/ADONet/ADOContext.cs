using HH.RMS.Common.Constant;
using HH.RMS.Repository.ADONet.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.ADONet
{
    public class ADOContext : IADOContext, IDisposable
    {
        /// <summary>
        /// 数据库连接字符串标识
        /// </summary>

        private SqlConnection _connection;

        private SqlConnection connection
        {
            get
            {
                if (_connection == null)
                {
                    ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[Config.sqlConnStr];
                    _connection = new SqlConnection(settings.ConnectionString);
                }
                return _connection;
            }
        }

        /// <summary>
        /// 注册新对象到事务
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public int ExecuteNonQuery(string commandText, CommandType commandType, IDictionary<string, object> parameters = null)
        {
            
            Func<SqlCommand, int> excute = (commend) =>
            {
                return commend.ExecuteNonQuery();
            };
            return CreateDbCommondAndExcute<int>(commandText, commandType, parameters, excute);
        }

        /// <summary>
        /// 查询对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <param name="load">自定义处理</param>
        /// <returns>泛型实体集合</returns>

        public List<T> ReadValues<T>(string commandText, CommandType commandType, IDictionary<string, object> parameters = null, Func<IDataReader, T> load = null) where T : class,new()
        {
            Func<SqlCommand, List<T>> excute = (dbCommand) =>
            {
                List<T> result = new List<T>();
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (load == null)
                        {
                            load = (s) => { return s.GetReaderData<T>(); };
                        }
                        var item = load(reader);
                        result.Add(item);
                    }
                    return result;
                }
            };
            return CreateDbCommondAndExcute(commandText, commandType, parameters, excute);
        }

        /// <summary>
        /// 查询对象集合
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <param name="setItem"></param>
        /// <returns></returns>
        public List<object> ReadValues(string commandText, CommandType commandType, Type type, IDictionary<string, object> parameters = null, Action<dynamic> setItem = null)
        {
            Func<SqlCommand, List<object>> excute = (dbCommand) =>
            {
                var result = new List<object>();

                using (IDataReader dataReader = dbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var item = dataReader.GetReaderData(type);
                        if (setItem != null)
                        {
                            setItem(item);
                        }
                        result.Add(item);
                    }
                }
                return result;
            };
            return CreateDbCommondAndExcute<List<object>>(commandText, commandType, parameters,
                excute);
        }

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <param name="excute"></param>
        /// <returns></returns>
        public T ExecuteReader<T>(string commandText, CommandType commandType, IDictionary<string, object> parameters = null, Func<IDataReader, T> load = null) where T : class,new()
        {
            Func<SqlCommand, T> excute = (dbCommand) =>
            {
                var result = default(T);
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (load == null)
                        {
                            load = (s) => { return s.GetReaderData<T>(); };
                        }
                        result = load(reader);
                    }
                    return result;
                }
            };
            return CreateDbCommondAndExcute<T>(commandText,commandType, parameters, excute);
        }

        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(string commandText, CommandType commandType, IDictionary<string, object> parameters = null)
        {
            Func<SqlCommand, object> excute = (dbCommand) =>
            {
                return dbCommand.ExecuteScalar();
            };
            return CreateDbCommondAndExcute(commandText, commandType,parameters, excute);
        }

        /// <summary>
        /// 创建命令并执行
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <param name="excute"></param>
        /// <returns></returns>
        private TValue CreateDbCommondAndExcute<TValue>(string commandText, CommandType commandType,
            IDictionary<string, object> parameters, Func<SqlCommand, TValue> excute)
        {
            if (connection.State == ConnectionState.Closed) { connection.Open(); };
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = commandType;
                command.CommandText = commandText; ;
                command.Connection = connection;
                command.Parameters.Add(parameters);
                return excute(command);
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();//非托管资源
            }
        }
    }
}
