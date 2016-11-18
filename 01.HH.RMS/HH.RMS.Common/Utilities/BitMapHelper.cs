using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Common.Utilities
{
    public class BitMapHelper
    {
        public static long[] GetAllBitMap()
        {
            long[] longArray = new long[62];
            long n = 1;
            int i = 0;
            while(true)
            {
                if (n>0 && Math.Abs(n) < long.MaxValue && i<=longArray.Length-1)
                {
                    longArray[i] = n;
                    n = n * 2;
                }
                else
                {
                    break;
                }
                i++;
            }
            return longArray;
        }
        public static long GetBitMap(long[] bitMapArray)
        {
            foreach (long bitMap in GetAllBitMap())
            {
                if (!bitMapArray.Contains(bitMap))
                {
                    return bitMap;
                }
            }
            return 0;
        }
    }
}
