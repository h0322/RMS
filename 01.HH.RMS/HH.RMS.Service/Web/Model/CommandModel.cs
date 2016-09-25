using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Web.Model
{
    public class CommandModel
    {
        public string commandText { get; set; }
        public IDictionary<string, object> parameters { get; set; }
        public CommandType commandType { get; set; }
        public CommandModel(string commandText,IDictionary<string, object> parameters)
        {
            this.commandText = commandText;
            this.parameters = parameters;
        }
        public CommandModel(string commandText, IDictionary<string, object> parameters, CommandType commandType)
        {
            this.commandText = commandText;
            this.parameters = parameters;
            this.commandType = commandType;
        }
    }
}
