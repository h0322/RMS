using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Repository.ADONet
{
    public static class SqlServerExtension
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="parameters"></param>
        public static void SetParameters(this IDbCommand dbCommand, IDictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                return;
            }
            foreach (var parameter in parameters)
            {
                if (parameter.Value != null)
                {
                    dbCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                }
                else
                {
                    dbCommand.Parameters.Add(new SqlParameter(parameter.Key, DBNull.Value));
                }
            }
        }

        /// <summary>
        ///  获取对应的实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="TEntity"></param>
        /// <returns></returns>
        public static T GetReaderData<T>(this IDataReader reader) where T : class, new()
        {
            var item = new T();
            var filedList = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                filedList.Add(reader.GetName(i));
            }
            //映射数据库中的字段到实体属性
            IEnumerable<PropertyInfo> propertys = typeof(T).GetProperties().Where(s => filedList.Contains(s.Name));
            foreach (var property in propertys)
            {
                //对实体属性进行设值
                if (reader[property.Name]!=DBNull.Value)
                    property.SetValue(item, reader[property.Name]);
            }
            return item;
        }

        public static List<T> GetDataTable<T>(this DataTable dt) where T : class,new()
        {
            var list = new List<T>();
            var filedList = new List<string>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                filedList.Add(dt.Columns[i].ColumnName);
            }
            IEnumerable<PropertyInfo> propertys = typeof(T).GetProperties().Where(s => filedList.Contains(s.Name));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var t = new T();
                foreach (var property in propertys)
                {
                    if (dt.Rows[i][property.Name] != DBNull.Value)
                    {
                        property.SetValue(t, dt.Rows[i][property.Name]);
                    }
                }
                list.Add(t);
            }
            return list;
        }

        /// <summary>
        /// 根据列名获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static T GetValue<T>(this IDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(index))
            {
                return default(T);
            }
            return (T)reader[index];
        }

        /// <summary>
        /// 获取对应的实体
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object GetReaderData(this IDataReader reader, Type type)
        {
            var item = Activator.CreateInstance(type);
            var filedList = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                filedList.Add(reader.GetName(i).ToLower());
            }
            //var properties = (from s in type.GetProperties()
            //                  let name = s.Name.ToLower().Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault()
            //                  where filedList.Contains(s.Name)
            //                  select new
            //                  {
            //                      Name = s.Name,
            //                      Property = s
            //                  }).ToList();
            var properties = type.GetProperties().Where(m => filedList.Contains(m.Name.ToLower()));
            //var properties = from s in type.GetProperties()
            //                 where filedList.Contains(s.Name)
            //                 select 

            foreach (var property in properties)
            {
                if (reader[property.Name] != DBNull.Value)
                {
                    property.SetValue(item, reader[property.Name]);
                }
            }
            return item;
        }
        public static IDataReader GetReaderCount(this IDataReader reader)
        {
            while (reader.NextResult())
            {
                return reader;
            }
            return reader;
        }
    }
}
