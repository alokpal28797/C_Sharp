using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList()
            {
               22, "Alok", "Amit",23,
            };

            arr.Remove(22);

            ArrayList arr2 = new ArrayList()
            {
                2002,2323,"qweqw",
            };

            arr.InsertRange(0,arr2);
            Console.WriteLine( arr.Contains(2022));


            foreach (var i in arr)
            {
                Console.WriteLine(i);
            }

            ArrayList arr3 = new ArrayList()
            {
                1,22323,2334,45675,87,
            };
            arr3.Sort();

            foreach (var i in arr3)
            {
                Console.WriteLine(i);
            }


            List<int> list = new List<int>() { 1, 2, 3, };
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
