using HH.RMS.Common.Constant;
using HH.RMS.Common.Models;
using HH.RMS.Repository.ADONet.Interface;
using HH.RMS.Repository.EntityFramework.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;
using HH.RMS.Common.Attributes;

namespace HH.RMS.Repository.ADONet
{
    public class ADORepositoryBase<T> : IADORepository<T> where T:class,new()
    {
        private IADOUnit _adoUnit;

        private IADOContext _context;

        public ADORepositoryBase(IADOUnit adoUnit,IADOContext context)
        {
            _adoUnit = adoUnit;
            _context = context;
        }

        //Lazy<ConditionBuilder> builder = new Lazy<ConditionBuilder>();
        public string tableName
        {
            get { 
                MappingTableAttribute attr = (MappingTableAttribute)typeof(T).GetCustomAttribute(typeof(MappingTableAttribute));
                return attr.tableName;
            }
        }
        public virtual int Insert(T entity)
        {
            
            Func<PropertyInfo[], string, IDictionary<string, object>, int> excute = (propertys, condition, parameters) =>
            {
                List<string> names = new List<string>();
                foreach (PropertyInfo property in propertys)
                {
                    //if (property.GetCustomAttribute(typeof(IncrementAttribute)) == null)
                    //{
                        string attrName = property.Name;
                        object value = property.GetValue(entity);
                        names.Add(string.Format("@{0}", attrName));
                        parameters.Add(attrName, value);
                    //}
                }
                string sql = "Insert into {0} values({1})";
                string combineSql = string.Format(sql, tableName, string.Join(",", names));
                return _adoUnit.Command(combineSql, parameters);
            };
            return CreateExcute<int>(null, excute);
        }

        public virtual int Update(T entity, Expression<Func<T, bool>> express)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(Expression<Func<T, bool>> express = null)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> QueryAll(Expression<Func<T, bool>> express = null)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> QueryAll(int index, int pagesize, List<SortConditionModel> orderFields, Expression<Func<T, bool>> express = null)
        {
            throw new NotImplementedException();
        }

        public virtual List<object> QueryAll(Type type, Expression<Func<T, bool>> express = null)
        {
            throw new NotImplementedException();
        }

        public virtual T Query(Expression<Func<T, bool>> express)
        {
            throw new NotImplementedException();
        }

        public virtual object QueryScalar(Expression<Func<T, bool>> express = null)
        {
            throw new NotImplementedException();
        }

        private TValue CreateExcute<TValue>(Expression<Func<T, bool>> express, Func<PropertyInfo[], string, IDictionary<string, object>, TValue> excute)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            PropertyInfo[] propertys = typeof(T).GetProperties();
            string condition = "";
            //if (express != null)
            //{
            //    builder.Value.Build(express, tableName);
            //    condition = string.Format("where {0} ", builder.Value.Condition);
            //    for (int i = 0; i < builder.Value.Arguments.Length; i++)
            //    {
            //        parameters.Add(string.Format("Param{0}", i), builder.Value.Arguments[i]);
            //    }
            //}
            return excute(propertys, condition, parameters);
        }
    }
}
