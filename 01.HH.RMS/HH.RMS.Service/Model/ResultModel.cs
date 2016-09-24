using HH.RMS.Common.Constant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service.Model
{
    public class ResultModel<T>
    {
        public ResultType resultType { get; set; }
        public string resultMsg { get; set; }
        public T resultObj { get; set; }
        public string remark { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public ResultModel()
        { }
        public ResultModel(ResultType type,T obj,string msg="",string remark="")
        {
            resultObj = obj;
            resultType = type;
            if (string.IsNullOrEmpty(msg))
            {
                resultMsg = type.ToString();
            }
            else
            {
                resultMsg = msg;
            }
            this.remark = remark;
        }
        public ResultModel(ResultType type, string msg = "", string remark = "")
        {
            resultType = type;
            if (string.IsNullOrEmpty(msg))
            {
                resultMsg = type.ToString();
            }
            else
            {
                resultMsg = msg;
            }
            this.remark = remark;
        }

    }
}
