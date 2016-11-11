using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Console.Algorithm
{
    public class Orders
    {
        public int i = 0;
        public string result = "";
        public Orders()
        {
            int[] arrayInt = new int[] { 2, 9, 7, 3, 5, 1, 4, 0, 8, 6 };
            string str = "a,b,c,d,e,f,g";
            string[] arrayStr = str.Split(',');
            OrderDesc(arrayStr);
        }

        public void InsertionSort(int[] arrayInt)
        {

        }
        public void OrderDesc(string[] arrayStr)
        {

            //result+=arrayStr[]

        }
    }
}
