using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Console.Algorithm
{
    public class Recursive
    {
        int n = 0;
        int nn = 0;
        string descOrderResult = "";
        ArrayList arrayList = new ArrayList();
        List<ResultModel> list = new List<ResultModel>();
        List<ResultModel> Resultlist = new List<ResultModel>();
        public Recursive()
        {

            list.Add(new ResultModel(1, 0));
            list.Add(new ResultModel(2, 0));
            list.Add(new ResultModel(3, 1));
            list.Add(new ResultModel(4, 2));
            list.Add(new ResultModel(5, 1));
            list.Add(new ResultModel(6, 2));
            list.Add(new ResultModel(7, 1));
            list.Add(new ResultModel(8, 2));
            list.Add(new ResultModel(9, 2));
            list.Add(new ResultModel(10, 3));
            list.Add(new ResultModel(11, 3));
            list.Add(new ResultModel(12, 4));
            list.Add(new ResultModel(13, 5));
            ParentOrder(GetParentList(), 0);
            //011235813
            System.Console.Write(GetNumber(6));

            
            //int[] intArray = new int[6] { 1, 2, 3, 4, 5, 6 };
            //System.Console.Write(DescOrder(intArray,0));
        }
        private List<int> GetParentList()
        {
            return list.Select(m=>m.parentId).Distinct().ToList();
        }
        public List<ResultModel> ParentOrder(List<int> parentList, int firstId)
        {

            if (list.Where(m=>m.parentId==firstId).Count()==0)
            {
                return null;
            }
            
            var _list = list.Where(m => m.parentId == firstId).OrderBy(m=>m.id).ToList();
            int tempId = 0;
            foreach (var item in _list)
            {
                Resultlist.Add(new ResultModel(item.id, firstId));
                tempId = item.id;
            }
            int nextId = list.Where(m => m.id > tempId).Select(m => m.id).FirstOrDefault();
            ParentOrder(parentList, nextId);
            return Resultlist;
        }
        public int  GetNumber(int i)
        {
            if (i == 1 || i == 2)
            {
                return 1;
            }
            else
            {
                n = GetNumber(i - 1);
                nn = GetNumber(i - 2);
                return n;
            }
        }
        public string DescOrder(int[] intArray,int m)
        {
            //descOrderResult += intArray[m].ToString();
            if (intArray.Length == m)
            {
                return "";
            }
            DescOrder(intArray, m+1);
            descOrderResult+=intArray[m].ToString();
            return descOrderResult;
        }
    }
    public class ResultModel
    {
        public int id { get; set; }
        public int parentId { get; set; }
        public ResultModel(int id,int parentId)
        {
            this.id=id;
            this.parentId = parentId;
 
        }
        
    }
}
