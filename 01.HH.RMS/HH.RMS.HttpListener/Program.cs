using HH.RMS.HttpServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.HttpListener
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpSearch httpSearch = new HttpSearch();
            httpSearch.Start();
            Console.WriteLine("开始监听...");
            Console.Read();
            return;
        }
    }
}
