using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    // 1.
    class RepeatNames
    {
        public void NameRepeat()
        {
            Console.WriteLine("Enter Your Name");
            var inputName = Console.ReadLine();
            Console.WriteLine();

            char[] inputChars = inputName.ToCharArray();

            bool hasNumber = false;

            foreach (char c in inputChars)
            {
                if (char.IsDigit(c))
                {
                    Console.WriteLine("PLease Enter valid Name");
                    hasNumber = true;
                    break;
                }
            }

            if (hasNumber == false)
            {

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(inputName);
                }

            }
        }
    }

    //2.

    class PrintEvenNumbers
    {
        public string EvenNum()
        {
            // int output = 0;
            // int[] num = new int[20];
            List<int> num = new List<int>();

            for (int i = 2; i < 50; i += 2)
            {
                if (i != 2 && i != 12 && i != 22 && i != 32 && i != 42)
                {
                    // num[output] = i;
                    // output++;
                    num.Add(i);
                }
            }
            string result = string.Join(" ", num);
            return result;
        }
    }

    // 3
    class CountNegative
    {
        public int NegativeValue()
        {
            Console.WriteLine("Enter the length of the Array");
            int arrLength = int.Parse(Console.ReadLine());
            double[] arr = new double[arrLength];
            int count = 0;

            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("Enter" + " " + i + " " + "index of Array");
                    arr[i] = double.Parse(Console.ReadLine());
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < 0)
                    {
                        count++;
                    }
                    
                }
                Console.WriteLine("Number of Negative Elements are:");
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter Valid Integer");
                Console.WriteLine("");
                Console.WriteLine("Choose options");
                return count;
            }
        }
    }

    //4

    class MinMAx
    {
        public string MinMaxValue()
        {
            Console.WriteLine("Enter the length of the Array");
            int arrLength = int.Parse(Console.ReadLine());
            double[] arr = new double[arrLength];
            double min = Int32.MaxValue;
            double max = Int32.MinValue;
            string result = "";

            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("Enter" + " " + i + " " + "index of Array");
                    arr[i] = double.Parse(Console.ReadLine());
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                    }
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("Answer is");
                result = "Minimum = " + min + " Maximum = " + max;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Valid Integer");
                Console.WriteLine("");
                Console.WriteLine("Choose options");
                return result;

            }
        }
    }


    //5
    class CheckEvenOdd
    {
        public string EvenAndOdd()
        {
            Console.WriteLine("Enter the length of the Array");
            int arrLength = int.Parse(Console.ReadLine());
            int[] arr = new int[arrLength];
            int EvenCount = 0;
            int OddCount = 0;
            string result = "";

            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("Enter" + " " + i + " " + "index of Array");
                    arr[i] = int.Parse(Console.ReadLine());
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        EvenCount++;
                    }
                    else
                    {
                        OddCount++;
                    }
                }

                result = "Even Elements = " + EvenCount + " Odd Elements = " + OddCount;

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Valid Integer");
                Console.WriteLine("");
                Console.WriteLine("Choose options");
                return result;

            }

        }
    }

    //6

    class MethodOverloading
    {
        public void Print(int age )
        {
            Console.WriteLine( "Ram" + " is " + age + " years old");
        }
        public void Print(int age, string name)
        {
            Console.WriteLine( "Ram & " + name +" both of them are " + age + " years old");
        }
        public void Print(int age, string name, string name1)
        {
            Console.WriteLine("Ram & " + name + " both of them are " + age + " years old and they have " + name1 + " as a sister");

        }
    }

   // 7
   class Overloadingmethod
    {
        public void Add(int x, int y)
        {
            Console.WriteLine("Answer is "+ (x + y));
        }
        public void Add(int x, int y ,int z)
        {
            Console.WriteLine("Answer is " +( x + y +z));
        }
        public void Add(double x, double y)
        {
            Console.WriteLine("Answer is " +( x + y));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose options");
            Console.WriteLine("1 --> Write a Names 5 times");
            Console.WriteLine("2 --> Print Even Numbers");
            Console.WriteLine("3 --> Count negative elements in array");
            Console.WriteLine("4 --> Maximum and Minimum element in array");
            Console.WriteLine("5 --> Count even and odd elements in array");
            Console.WriteLine("6 --> Function overloading");
            Console.WriteLine("7 --> Function overloading with double");





            while (true)
            {

                try
                {
                    Console.WriteLine();
                    Console.WriteLine("What is your choice");

                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("1. Write a Names 5 times");
                            RepeatNames repeatNames = new RepeatNames();
                            repeatNames.NameRepeat();
                            ; break;
                        case "2":
                            Console.WriteLine("2. Print Even Numbers");
                            PrintEvenNumbers printEvenNumbers = new PrintEvenNumbers();
                            Console.WriteLine(printEvenNumbers.EvenNum());
                            break;
                        case "3":
                            CountNegative countNegative = new CountNegative();
                            int num = countNegative.NegativeValue();
                            if(num !=0)
                            {
                            Console.WriteLine(num);
                            }
                            
                            break;
                        case "4":
                            MinMAx min = new MinMAx();
                            Console.WriteLine(min.MinMaxValue());
                            break;
                        case "5":
                            CheckEvenOdd checkEvenOdd = new CheckEvenOdd();
                           Console.WriteLine( checkEvenOdd.EvenAndOdd());
                            break;
                        case "6":
                            MethodOverloading methodOverloading = new MethodOverloading();
                            Console.WriteLine("Enter Age");

                            int  age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Name");

                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Sis Name");

                            string Sisname = Console.ReadLine();
                            methodOverloading.Print(age);
                            methodOverloading.Print(age, name);
                            methodOverloading.Print(age, name, Sisname);
                            break;
                        case "7":
                            Overloadingmethod overloadingmethod = new Overloadingmethod();
                            overloadingmethod.Add(1212, 13);
                            overloadingmethod.Add(13412, 1343);
                            overloadingmethod.Add(134.2312, 13.2343);
                            break;


                        case "8":
                            return;
                        default:
                            Console.WriteLine("Please select 1 to 7 values");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please Enter correct value");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Choose Options");



                }

            }

        }
    }
}
