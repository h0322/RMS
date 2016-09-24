using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using HH.RMS.Repository.ADONet.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Transactions;
using System.ComponentModel.DataAnnotations;
using HH.RMS.Entity;
using System.ComponentModel.DataAnnotations.Schema;
namespace HH.RMS.Repository.ADONet
{
    public class ADORepositoryBase<T> : IADORepository<T> where T : EntityBase, new()
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
        public string tableName
        {
            get
            {
                MappingTableAttribute attr = (MappingTableAttribute)typeof(T).GetCustomAttribute(typeof(MappingTableAttribute));
                return attr.tableName;
            }
        }

        public int Insert(T entity)
        {
            entity.isActive = true;
            entity.createBy = 0;
            entity.createTime = DateTime.Now;
            entity.updateBy = 0;
            entity.updateTime = DateTime.Now;
            Func<PropertyInfo[], string, IDictionary<string, object>, int> excute = (propertys, condition, parameters) =>
            {
                List<string> values = new List<string>();
                List<string> fields = new List<string>();
                foreach (PropertyInfo property in propertys)
                {
                    if (!IsDataField(property))
                    {
                        continue;
                    }
                    string attrName = property.Name;
                    object value = property.GetValue(entity);
                    fields.Add(attrName);
                    values.Add(string.Format("@{0}", attrName));
                    parameters.Add(attrName, value);
                }
                string sql = "Insert into {0} ({1}) values({2})";
                string commandText = string.Format(sql, tableName,string.Join(",",fields), string.Join(",", values));
                return ExecuteNonQuery(commandText, CommandType.Text, parameters);
            };
            return CreateExcute<int>(excute);
        }

        public int Update(T entity, Expression<Func<T, bool>> express)
        {
            entity.updateTime = DateTime.Now;
            if(!entity.updateBy.HasValue)
                entity.updateBy = 0;
            Func<PropertyInfo[], string, IDictionary<string, object>, int> excute = (propertys, condition, parameters) =>
            {
                List<string> names = new List<string>();
                SqlParameter[] para = new SqlParameter[3];
                foreach (PropertyInfo property in propertys)
                {
                    if (!IsDataField(property))
                    {
                        continue;
                    }
                    string attrName = property.Name;
                    object value = property.GetValue(entity);
                    names.Add(string.Format("{0}=@{1}", attrName, attrName));
                    parameters.Add(attrName, value);

                }
                string sql = "update {0} set  {1} where {2}";
                string commandText = string.Format(sql, tableName, string.Join(",", names),condition);
                return ExecuteNonQuery(commandText, CommandType.Text, parameters);
            };
            return CreateExcute<int>(excute,express);
        }

        public int Delete(Expression<Func<T, bool>> express = null)
        {
             Func<PropertyInfo[], string, IDictionary<string, object>, int> excute = (propertys, condition, parameters) =>
             {
                 string sql = "delete from {0} {1}";
                 string commandText = string.Format(sql, tableName, condition);
                 return ExecuteNonQuery(commandText, CommandType.Text, parameters);
              };
             return CreateExcute<int>(excute, express);
        }

        public List<T> QueryAll(Expression<Func<T, bool>> express = null)
        {
            Func<PropertyInfo[], string, IDictionary<string, object>, List<T>> excute = (propertys, condition, parameters) =>
            {
                string sql = "select {0} from {1} {2}";
                string commadText = string.Format(sql, string.Join(",", propertys.Select(x => x.Name)), tableName, condition);
                return ExecuteReaderList<T>(commadText, parameters);
            };
            return CreateExcute(excute, express);
        }

        //public List<T> QueryByPager(int index, int pagesize, List<SortConditionModel> orderFields, Expression<Func<T, bool>> express = null)
        //{
        //    Func<PropertyInfo[], string, IDictionary<string, object>, List<T>> excute = (propertys, condition, parameters) =>
        //    {
        //        string sql = "select {0} from {1} {2}";
        //        string commadText = string.Format(sql, string.Join(",", propertys.Select(x => x.Name)), tableName, condition);
        //        return ExecuteReaderList<T>(commadText, parameters, CommandType.Text);
        //    };
        //    return CreateExcute(excute, express);
        //}

        public List<object> QueryAll(string commandText, List<Type> typeList, IDictionary<string, object> parameters, CommandType commandType, Expression<Func<T, bool>> express = null)
        {
            return ExecuteReaderList(commandText, typeList, parameters, commandType);
        }

        public List<object> QueryAll(string commandText, Type type, IDictionary<string, object> parameters, CommandType commandType = CommandType.Text, Expression<Func<T, bool>> express = null)
        {
            return ExecuteReaderList(commandText, type, parameters, commandType);
        }

        public List<T> QueryAll(string commandText, IDictionary<string, object> parameters, CommandType commandType, Expression<Func<T, bool>> express = null)
        {
            return ExecuteReaderList<T>(commandText, parameters, commandType);
        }
        public T Query(Expression<Func<T, bool>> express)
        {
             Func<PropertyInfo[], string, IDictionary<string, object>, T> excute = (propertys, condition, parameters) =>
             {
                 string sql = "select {0} from {1} {2}";
                 string commadText = string.Format(sql, string.Join(",", propertys.Select(x => x.Name)), tableName, condition);
                 return ExecuteReader<T>(commadText, parameters);
             };
             return CreateExcute<T>(excute, express);
        }

        public int QueryCount(Expression<Func<T, bool>> express = null)
        {
            Func<PropertyInfo[], string, IDictionary<string, object>, int> excute = (propertys, condition, parameters) =>
            {
                string sql = "select count(1) from {1} {2}";
                string commadText = string.Format(sql, string.Join(",", propertys.Select(x => x.Name)), tableName, condition);
                return ExecuteScalar(commadText,CommandType.Text,parameters);
            };
            return CreateExcute<int>(excute, express);
        }

        private TValue CreateCommand<TValue>(string commandText,
    IDictionary<string, object> parameters, CommandType commandType, Func<SqlCommand, TValue> excute)
        {
            if (connection.State == ConnectionState.Closed) { connection.Open(); };
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = commandType;
                command.CommandText = commandText; ;
                command.Connection = connection;
                if (parameters!=null)
                { 
                    foreach(var data in parameters)
                    {
                        var value = data.Value == null ? DBNull.Value : data.Value;
                        command.Parameters.Add(data.Key,value);
                    }
                }
                return excute(command);
            }
        }

        private TValue CreateExcute<TValue>(Func<PropertyInfo[], string, IDictionary<string, object>, TValue> excute, Expression<Func<T, bool>> express = null)
        {
           
            PropertyInfo[] propertys = typeof(T).GetProperties();
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            string condition = "";
            return excute(propertys, condition, parameters);
        }

        private int ExecuteNonQuery(string commandText, CommandType commandType, IDictionary<string, object> parameters)
        {
            Func<SqlCommand, int> excute = (dbCommand) =>
            {
                return dbCommand.ExecuteNonQuery();
            };
            return CreateCommand<int>(commandText, parameters, CommandType.Text, excute);
        }
        private int ExecuteScalar(string commandText, CommandType commandType, IDictionary<string, object> parameters)
        {
            Func<SqlCommand, int> excute = (dbCommand) =>
            {
                return (int)dbCommand.ExecuteScalar();
            };
            return CreateCommand<int>(commandText, parameters, CommandType.Text, excute);
        }

        private T ExecuteReader<T>(string commandText, IDictionary<string, object> parameters = null, Func<IDataReader, T> load = null) where T : class,new()
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
             return CreateCommand<T>(commandText, parameters,CommandType.Text, excute);
        }

        private List<object> ExecuteReaderList(string commandText, Type type, IDictionary<string, object> parameters = null, CommandType commandType=CommandType.Text, Func<IDataReader, T> load = null)
        {
            Func<SqlCommand, List<object>> excute = (dbCommand) =>
            {
                var result = new List<object>();
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = reader.GetReaderData(type);
                        result.Add(item);
                    }
                }
                return result;
            };
            return CreateCommand<List<object>>(commandText, parameters, commandType, excute);
        }

        private List<object> ExecuteReaderList(string commandText, List<Type> typeList, IDictionary<string, object> parameters = null, CommandType commandType=CommandType.Text, Func<IDataReader, T> load = null)
        {
            Func<SqlCommand, List<object>> excute = (dbCommand) =>
            {
                var result = new List<object>();
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    int i = 0;
                    while (i>=0)
                    {
                        while (reader.Read())
                        {
                            Type t = typeList[i];
                            var item = reader.GetReaderData(t);
                            result.Add(item);
                        }
                        if(reader.NextResult())
                        {
                            i++;
                        }
                        else
                        {
                            i = -1;
                        }
                    }
                }
                return result;
            };
            return CreateCommand<List<object>>(commandText, parameters, commandType, excute);
        }

        private List<T> ExecuteReaderList<T>(string commandText, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, Func<IDataReader, T> load = null) where T : class,new()
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
                        result.Add(load(reader));
                    }
                    return result;
                }
            };
            return CreateCommand(commandText, parameters, commandType, excute);
        }
        private List<T> ExecuteDataSet<T>(string commandText, IDictionary<string, object> parameters = null) where T : class,new()
        {
            Func<SqlCommand, List<T>> excute = (dbCommand) =>
            {
                List<T> result = new List<T>();

                using (SqlDataAdapter sdr = new SqlDataAdapter(commandText,connection))
                {
                    DataSet ds =new DataSet();
                    sdr.Fill(ds);
                    foreach (DataTable dt in ds.Tables)
                    {
                        List<string> filedList = new List<string>();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            filedList.Add(dt.Columns[i].ColumnName);
                        }
                        IEnumerable<PropertyInfo> propertys = typeof(T).GetProperties().Where(s => filedList.Contains(s.Name));

                    }
                    return result;
                }
            };
            return CreateCommand(commandText, parameters, CommandType.Text, excute);
        }

        private bool IsDataField(PropertyInfo property)
        {
            if (property.GetCustomAttribute(typeof(KeyAttribute)) != null)
            {
                return false;
            }
            //ForeignKey
            if (property.GetCustomAttribute(typeof(ForeignKeyAttribute)) != null)
            {
                return false;
            }
            if (property.GetCustomAttribute(typeof(EntityObjectAttribute)) != null)
            {
                return false;
            }
            return true;
        }

    }
}
