using HH.RMS.Common.Models;
using HH.RMS.Repository.ADONet.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HH.RMS.Repository.ADONet
{
    public class ADOUnit:IADOUnit
    {
              /// <summary>
        /// 注入对象
        /// </summary>
        private IADOContext _context;

        /// <summary>
        /// 维护一个Sql语句的命令列表
        /// </summary>
        private List<CommandModel> _commands;

        public ADOUnit(IADOContext context)
        {
            _commands = new List<CommandModel>();
            this._context = context;
        }

        /// <summary>
        /// 增、删、改命令 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int Command(string commandText, IDictionary<string, object> parameters)
        {
            IsCommited = false;
            _commands.Add(new CommandModel(commandText, parameters));
            return 1;
        }

        /// <summary>
        /// 提交状态
        /// </summary>
        public bool IsCommited{ get; set; }

        /// <summary>
        /// 提交方法
        /// </summary>
        /// <returns></returns>
        public void Commit()
        {
            if (IsCommited) { return ; }
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var comm in _commands)
                {
                    _context.ExecuteNonQuery(comm.commandText,comm.commandType, comm.parameters);
                }
                scope.Complete();
                IsCommited = true;
            }
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollBack()
        {
            IsCommited = false;
        }
    }
}
