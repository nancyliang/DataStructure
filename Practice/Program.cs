using System;
using System.Collections.Generic;

namespace Practice
{
    class Program
    {
        /* static void Main(string[] args)
        {
            int[] i = { 56, 278, 46, 16, 386 };

            Sort s = new Sort(i);

            Console.Write("original list: ");
            foreach (int item in i)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine(";");
            Console.Write("sorted list: ");
            foreach (int item in s.MergeSort(0, i.Length - 1))
            {

                Console.Write(item + ",");
            }

        } */

        static void Main(string[] args)
        {
            int target = 56;
            int[] targetList = { 56, 278, 46, 16, 386 };
            Search search = new Search(target,targetList);
            int result = search.BinarySearch();
            if(result == -1) 
            {Console.WriteLine("找不到哦");}
            else 
            {
                Console.WriteLine("找到啦，是第{0}个数",(result+1).ToString());
            }

        }
    }
}
