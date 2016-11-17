using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Console.Algorithm
{
    public class Search
    {
        public Search()
        {
            int[] intArray = new int[] { 1, 2, 4, 7, 8, 9, 11, 33, 65, 87, 99 };
            int start=0;
            int end = intArray.Length-1;
            Middle(intArray, start, end, 3);
 
        }
        public int Middle(int[] _intArray,int _start,int _end,int key)
        {

            if (_start > _end)
            {
                return -1;
            }
            int location = (_start + _end) / 2;
            if (_intArray[location] > key)
            {
                _end = location-1;
                Middle(_intArray, _start, _end, key);
            }
            else if(_intArray[location] < key)
            {
                _start = location+1;
                Middle(_intArray, _start, _end, key);
            }
            else
            {
                return location;
            }
            return -1;
        }
    }

}
