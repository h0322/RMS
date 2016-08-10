using HH.RMS.Common.Constant;
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
    public class ADORepositoryBase : IADORepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SqlConnection _connection;

        public SqlConnection connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(Config.sqlConnStr);
                }
                return _connection;
            }
        }
        public virtual int Command(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            try
            {
                Func<SqlCommand, int> excute = (commend) =>
                {
                    return commend.ExecuteNonQuery();
                };
                return CreateDbCommondAndExcute<int>(commandText, parameters, commandType, excute);
            }
            catch (Exception ex)
            {
                log.Error("RepositoryBase.Command", ex);
                return 0;
            }
        }

        public virtual List<T> QueryList<T>(string commandText, CommandType commandType, SqlParameter[] parameters = null, Func<IDataReader, T> load = null) where T : class, new()
        {
            try
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
                return CreateDbCommondAndExcute(commandText, parameters, commandType, excute);
            }
            catch (Exception ex)
            {
                log.Error("RepositoryBase.QueryAll", ex);
                return null;
            }
        }

        public virtual T Query<T>(string commandText, CommandType commandType, SqlParameter[] parameters = null, Func<IDataReader, T> load = null) where T : class, new()
        {
            try
            {
                Func<SqlCommand, T> excute = (dbCommand) =>
                {

                    var result = default(T);
                    using (IDataReader reader = dbCommand.ExecuteReader())
                    {
                        if (reader.Read())
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
                return CreateDbCommondAndExcute<T>(commandText, parameters, commandType, excute);
            }
            catch (Exception ex)
            {
                log.Error("RepositoryBase.Query", ex);
                return null;
            }
        }

        public virtual DataSet QueryDataSet(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            try
            {
                Func<SqlCommand, DataSet> excute = (dbCommand) =>
                {
                    DataSet result = new DataSet();
                    using (SqlDataAdapter sda = new SqlDataAdapter(dbCommand))
                    {
                        sda.Fill(result);
                        return result;
                    }
                };
                return CreateDbCommondAndExcute(commandText, parameters, commandType, excute);
            }
            catch (Exception ex)
            {
                log.Error("RepositoryBase.QueryDataSet", ex);
                return null;
            }
        }
        public virtual object QueryScalar(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            Func<SqlCommand, object> excute = (commend) =>
            {
                return commend.ExecuteScalar();
            };
            return CreateDbCommondAndExcute(commandText, parameters, commandType, excute);
        }
        private TValue CreateDbCommondAndExcute<TValue>(string commandText,
            SqlParameter[] parameters, CommandType commandType, Func<SqlCommand, TValue> excute)
        {
            if (connection.State == ConnectionState.Closed) { connection.Open(); };
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = commandType;
                command.CommandText = commandText; ;
                command.Connection = connection;
                command.Parameters.AddRange(parameters);
                return excute(command);
            }
        }
    }
}
