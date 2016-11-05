using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Console.DesignPattern
{
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();
        private Singleton()
        { 
        }
        public Singleton instance
        {
            get { return _instance; }
        }
    }
    public sealed class Singleton2
    {
        private static Singleton2 _instance = null;
        static object obj = new object();
        Singleton2()
        { }
        public static Singleton2 instance
        {
            get {
                if(_instance==null)
                { 
                    lock (obj)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton2();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
