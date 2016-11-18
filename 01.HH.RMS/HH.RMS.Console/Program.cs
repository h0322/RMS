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

namespace HH.RMS.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1 | 4;
            System.Console.Write(i);
            System.Console.ReadLine();
            new SendMessage();
            return;
            //SendMessage send1 = new SendMessage();
            //SendMessageDefine send1 = new SendMessageDefine();
            new Recursive();

            System.Console.ReadLine();
        }
    }
}
