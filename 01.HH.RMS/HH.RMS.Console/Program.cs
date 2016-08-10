using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            C[] cs = new C[]{
            new C(11),new C(22),new C(33),
            new C(44),new C(55),new C(66)};
 
            Expression<Func<C, bool>> e1 = x => x.N > 20;
            Expression<Func<C, bool>> e2 = x => x.N < 50;
 
            Expression<Func<C, bool>> e3 = e1.AndAlso(e2);
 
            var re = cs.Where(e3.Compile()).ToArray();
 
            foreach (C c in re)
                Console.WriteLine(c.N);
            //22 33 44
            Console.ReadLine();
        }
    }
 
    //元素类型定义
    class C
    {
        public C(int n) { this.N = n; }
        public int N;
    }
 
    //扩展方法
    public static class Ext
    {
        public static Expression<Func<T, bool>> AndAlso<T>(
  this Expression<Func<T, bool>> a,
  Expression<Func<T, bool>> b)
        {
            var p = Expression.Parameter(typeof(T), "m");
            var bd = Expression.AndAlso(
                    Expression.Invoke(a, p),
                    Expression.Invoke(b, p));
            var ld = Expression.Lambda<Func<T, bool>>(bd, p);
            return ld;
        }
    }        //static void Main(string[] args)
        //{

           
        //   //var s =  new B(1);
        //   //int sss=s.res();
        //   //int sssss = s.res2();
        //    //Test();
        //    //Console.Read();
        //    string url = "https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token=s5Y1otU5eSx-cOUHrdRlpNjf2twIzhw78a5vtORglevLKjDv67IFHhWef2OVPMKp-my7JCVSey09Q1z-9LhFWOEWLbuPbUtXfX33SY3vemBNSUsApzfq4V0DHGjJzluiEYDjAJAZTY";
        //    string data ="{\"type\":\"image\", \"offset\":0, \"count\":20}";
        //    //WebClient wc = new WebClient();
        //    using (WebClient wc = new WebClient())
        //    {
        //        //wc.Proxy = WebProxyHelper.CreateWebProxy();
        //        wc.Encoding = Encoding.UTF8;
        //        //WebProxyHelper.CancelCertificateValidate();
        //        var respones = wc.UploadString(url, "POST", data);
        //    }
        //}

 //       public static void Test()
 //       {
 //           string[] text ={ "Albert was here", "Burke slept late", "Connor is happy" };  

 //           var tokens = text.Select(s => s.Split(' '));

 //foreach (string[] line in tokens)

 //     foreach (string token in line)        

 //     Console.Write("{0}.", token);


 
 //       }
 //       public static void TestB()
 //       {
            
 //       string[] text ={ "Albert was here", "Burke slept late", "Connor is happy" };  
 //       var tokens = text.SelectMany(s => s.Split(' '));  

 //       foreach (string token in tokens)    

 //         Console.Write("{0}.", token);
 //               }
 //               public  class A
 //               {
 //                   public int i;
 //                   public int j;
 //                   public A(int a)
 //                   {
 //                       i = a;
 //                   }
 //                   public virtual int res2()
 //                   {
 //                       return i;
 //                   }
 //       }
 //   }


}
