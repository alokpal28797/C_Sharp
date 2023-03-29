using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
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
            Console.WriteLine(arr2.Capacity);
            arr.Capacity = 10;

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


            Console.WriteLine("//--------------------------------------------");
            int[] arrl = new int[5];
            arrl[0] = 1;
            arrl[1] = 2;
            arrl[2] = 3;
            arrl[3] = 4;
            arrl[4] = 5;
            List<int> l1 = new List<int>(arrl);


            foreach (var i in l1)
            {
                Console.WriteLine(i);
            }

            var students = new List<Student>() {
                new Student(){ Id = 1, Name="Bill"},
                new Student(){ Id = 2, Name="Steve"},
                new Student(){ Id = 3, Name="Ram"},
                new Student(){ Id = 4, Name="Abdul"}
            };

            //get all students whose name is Bill
            var result = from s in students
                         where s.Name == "Steve"
                         select s;
            foreach(var s in result)
            {
                Console.WriteLine(s.Id +" " + s.Name);
            }

            SortedList<int, string> st = new SortedList<int, string>()
            {
                { 2,"alok" },
                {3,"Amit" }
            };
            st.Add(1, "Ajjet");

            st[2] = "Alok PAl";
            Console.WriteLine(st.ContainsKey(2));
            Console.WriteLine(st.Count());

            for ( int i = 0; i<st.Count(); i++ ) 
            {
                Console.WriteLine(st.Values[i]);
            }

            st.Remove(1);
            

            foreach (KeyValuePair<int, string> kvp in st)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }
            
            Dictionary<string , string> aa = new Dictionary<string , string>();
            aa.Add("Alo", "AA");
            var alo = new Hashtable()
            {
                {2,"ALok" }
            }; 
            foreach(DictionaryEntry de  in alo)
            {
                Console.WriteLine(de.Value);
            }

            Queue<int> A = new Queue<int>();
            A.Enqueue(1);
            A.Enqueue(11);
            A.Peek();
            A.Dequeue();
            foreach (var r in A)
            {
                Console.WriteLine(r);
            }
        }
    }
}
