using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
        List<ResultModel> Orderlist = new List<ResultModel>();
        List<ResultModel> Resultlist = new List<ResultModel>();
        public Recursive()
        {
            //System.Console.Write(GetNumber(8));
            //return;

            Orderlist.Add(new ResultModel(1, 0));
            Orderlist.Add(new ResultModel(2, 0));
            Orderlist.Add(new ResultModel(3, 1));
            Orderlist.Add(new ResultModel(4, 2));
            Orderlist.Add(new ResultModel(5, 1));
            Orderlist.Add(new ResultModel(6, 2));
            Orderlist.Add(new ResultModel(7, 1));
            Orderlist.Add(new ResultModel(8, 2));
            Orderlist.Add(new ResultModel(9, 2));
            Orderlist.Add(new ResultModel(10, 3));
            Orderlist.Add(new ResultModel(11, 3));
            Orderlist.Add(new ResultModel(12, 4));
            Orderlist.Add(new ResultModel(13, 5));
            Orderlist.Add(new ResultModel(14, 0));
            Orderlist.Add(new ResultModel(15, 1));
            ChildrenOrder(0);
            //ParentOrder(Orderlist, 0);
            //011235813
            //System.Console.Write(GetNumber(6));

            
            //int[] intArray = new int[6] { 1, 2, 3, 4, 5, 6 };
            //System.Console.Write(DescOrder(intArray,0));
        }
        private List<int> GetParentList()
        {
            return Orderlist.Select(m => m.parentId).Distinct().ToList();
        }
        private int IsParentId(int pid)
        {
            var item = Orderlist.Where(m => m.parentId == pid).FirstOrDefault();
            if (item == null)
            {
                return -1;
            }
            return item.id;
        }

        public List<ResultModel> ParentOrder(List<ResultModel> list, int pid)
        {
            foreach(var item in list)
            {

                var tempList = Orderlist.Where(m => m.parentId == pid).ToList();
                    if (tempList.Count == 0)
                    {
                        return null;
                    }
                    ParentOrder(list, pid);
                    Resultlist.Add(item);
                //}
                //else
                //{
                //    Resultlist.Add(item);
                //}
            }
            return Resultlist;
        }

        private void ChildrenOrder(int pid)
        {
            var oList = Orderlist.Where(m => m.parentId == pid).ToList();
            foreach (var item in oList)
            {
                Resultlist.Add(item);
                ChildrenOrder(item.id);
            }
        }

        //public List<ResultModel> ParentOrder(List<int> parentList, int firstId)
        //{

        //    if (list.Where(m=>m.id>firstId).Count()==0)
        //    {
        //        return null;
        //    }
            
        //    var _list = list.Where(m => m.parentId == firstId).OrderBy(m=>m.id).ToList();
        //    int tempId = 0;
        //    foreach (var item in _list)
        //    {
        //        var newItem = list.Where(m => m.parentId == firstId).OrderBy(m => m.id).FirstOrDefault();
        //        if (newItem !=null)
        //        {
        //            ParentOrder(parentList, newItem.id);
        //        }
        //        Resultlist.Add(new ResultModel(item.id, firstId));
        //        tempId = firstId;
        //    }
        //    int nextId = list.Where(m => m.id > tempId).Select(m => m.id).FirstOrDefault();
        //    return Resultlist;
        //}
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
                int nnn = n + nn;
                return nnn;
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
        public  int FOrder(int f)
        {
            if (f == 1|| f == 2)
            {
                arrayList.Add(1);
                return 1;
            }
            int res = FOrder(f-1) + FOrder(f - 2);
            arrayList.Add(res);
            return res;

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
