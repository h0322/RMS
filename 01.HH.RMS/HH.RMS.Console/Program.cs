using HH.RMS.Common.Utilities;
using HH.RMS.Console.Algorithm;
using HH.RMS.Console.DesignPattern;
using HH.RMS.Console.Wechat;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace HH.RMS.Consoles
{
    class Program
    {
        const int aa =2;
        static void Main(string[] args)
        {
            decimal dd = 1;
            int result = 0;
            for (int i = 0; i < 100000; i++)
            {
                if (dd > decimal.MaxValue / 4)
                {
                    break;
                }
                result++;
                dd = 2 * dd;

            }
            System.Console.WriteLine(result);
            System.Console.Read();
            return;
            CacheHelper.SetCache("cache", "123");
            CacheHelper.SetCache("cache", "456");
            System.Console.Write(CacheHelper.GetCache("cache").ToString());
            //System.Console.Write(aa);
            //System.Console.Read();
            //string aa = null;
            //var ss = aa ?? "";
            //System.Console.Write(ss);
            //return;
            //int i = 1 | 2;
            //System.Console.Write(i);
            //System.Console.ReadLine();
            //new SendMessage();
            //return;
            //SendMessage send1 = new SendMessage();
            //SendMessageDefine send1 = new SendMessageDefine();
            //new Recursive();

            System.Console.ReadLine();
        }
    }
}
