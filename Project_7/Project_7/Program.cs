using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_7
{
    internal class Program
    {
        // 1
        class IntegerAdd
        {
            public void CreateList()
            {
                try
                {
                    //Console.BackgroundColor = ConsoleColor.White;
                    //Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("How many Integers you want to add in a List ?");
                    int listLength = int.Parse(Console.ReadLine());
                    List<double> list = new List<double>();

                    for (int i = 0; i < listLength; i++)
                    {
                        int index = (i + 1);
                        Console.WriteLine("Enter the " + index + " number");
                        double userInput = double.Parse(Console.ReadLine());


                        list.Add((userInput + 2) * 5);
                    }

                    Console.WriteLine("The new Updated list");
                    foreach (double i in list)
                    {
                        Console.WriteLine(i);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

        //2
        class DocumnetIndex
        {
            public void IndexDocumnet()
            {
                try
                {
                    Console.WriteLine("How many Integers you want to add in a List ?");
                    int listLength = int.Parse(Console.ReadLine());
                    List<int> list = new List<int>();

                    for (int i = 0; i < listLength; i++)
                    {
                        int index = (i + 1);
                        Console.WriteLine("Enter the " + index + " number");
                        int userInput = int.Parse(Console.ReadLine());


                        list.Add(userInput);
                    }

                    list.Sort();

               

                    List<string> ranges = new List<string>();
                    int start = list[0];




                    for (int i = 1; i < list.Count; i++)
                    {
                        if (list[i] != list[i - 1] + 1)
                        {
                            if (start != list[i - 1])
                            {
                                ranges.Add(start.ToString() + "-" + list[i - 1].ToString());
                            }
                            else
                            {
                                ranges.Add(start.ToString());
                            }
                            start = list[i];
                        }
                    }

                    if (start != list[list.Count - 1])
                    {
                        ranges.Add(start.ToString() + "-" + list[list.Count - 1].ToString());
                    }
                    else
                    {
                        ranges.Add(start.ToString());
                    }

                    Console.WriteLine("New List");

                    string result = string.Join(",", ranges);
                    Console.WriteLine(result);




                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // 3
        class StudentAdmission
        {
            public void Addmission()
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("What do you want 1.Student Addmission  2.Leave the College  3.Students Who get Award  4. Total Students. ");

                        SortedList<string, string[]> StudentList = new SortedList<string, string[]>();
                        string [] value = new string[4];
                        string RollNokey = " ";
                        string inputAddStudents = "n";
                        
                        do
                        {
                            Console.WriteLine("Select 1, 2, 3, 4");
                            int userInput = int.Parse(Console.ReadLine());

                            

                            if (userInput == 1)
                            {

                                Console.WriteLine("Enter Student Name : ");
                                value[0] = Console.ReadLine();

                                Console.WriteLine("Enter Student RollNumber : ");
                                RollNokey = Console.ReadLine();

                                
                                StudentAdmission studentAdmission = new StudentAdmission();


                                Console.WriteLine("Enter Student PhoneNumber : ");
                                value[1] = (Console.ReadLine());

                                Console.WriteLine("Enter Student Email : ");
                                value[2] = Console.ReadLine();

                                Console.WriteLine("Enter Student Age : ");
                                value[3] = (Console.ReadLine());


                                StudentList.Add(RollNokey, value);

                                Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                                inputAddStudents = Console.ReadLine();
                            }

                            if (userInput == 2)
                            {
                                Console.WriteLine("Enter Student RollNumber To Remove them from College : ");
                                RollNokey = Console.ReadLine();
                               
                                if(StudentList.ContainsKey(RollNokey))
                                {
                                    StudentList.Remove(RollNokey);
                                }
                                else
                                {
                                    Console.WriteLine("This Roll no. is not existed");
                                }

                                Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                                inputAddStudents = Console.ReadLine();
                            }

                            if (userInput == 3)
                            {
                                Console.WriteLine("Enter the no. of Students whom You want to give award. : ");

                                int awardedStudent = int.Parse(Console.ReadLine());


                                for (int i = 0; i < awardedStudent; i++)
                                {
                                    Console.WriteLine("Enter their Roll no. : ");
                                    RollNokey = Console.ReadLine();

                                    if (StudentList.ContainsKey(RollNokey))
                                    {
                                        Console.WriteLine(StudentList[RollNokey] + " Is Awarded !!!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("This Roll no. is not existed");
                                    }
                                }



                               
                                Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                                inputAddStudents = Console.ReadLine();
                            }



                            if (userInput == 4)
                            {

                                foreach (KeyValuePair<string, string[]> kvp in StudentList)
                                {
                                    Console.WriteLine("* The Name of Student is: " + kvp.Value[0] + "  Roll Number : " + kvp.Key + " Email : " + kvp.Value[2]  + " PhoneNumber : " + kvp.Value[1] + " Age : " + value[3]);
                                }

                                Console.WriteLine();
                                Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                                inputAddStudents = Console.ReadLine();
                            }


                        } while (inputAddStudents == "y");




                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Choose options");
            Console.WriteLine("1 --> C# Sharp program to create a new list from a given list of integers where each integer value is added to 2 and the result value is multiplied by 5.");
            Console.WriteLine("2 --> If you have a large set of numbers that are used as references, it can be useful to group them into a series of smaller ranges,  This approach is commonly seen each containing the adjacent numbers. in document indexes. It is also used in document editing software when specifying that you wish to print a specific set of pages.\r\n");
            Console.WriteLine("3 --> Write C# program for admission of students in college. After admission is done, print a simple message and total number of students. Now some of the students are leaving college due to  some reason so remove them from college. Some of the students are getting awards for best students so print them as well.\r\n");





            while (true)
            {

                try
                {
                    Console.WriteLine();
                    Console.WriteLine("**Choose options**");

                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("1. C# Sharp program to create a new list from a given list of integers where each integer value is added to 2 and the result value is multiplied by 5.");
                            IntegerAdd integerAdd = new IntegerAdd();
                            integerAdd.CreateList();
                            break;
                        case "2":
                            Console.WriteLine("2. If you have a large set of numbers that are used as references, it can be useful to group them into a series of smaller ranges,  This approach is commonly seen each containing the adjacent numbers. in document indexes. It is also used in document editing software when specifying that you wish to print a specific set of pages.\r\n");
                            DocumnetIndex documnetIndex = new DocumnetIndex();
                            documnetIndex.IndexDocumnet();
                            break;
                        case "3":
                            Console.WriteLine("3. Write C# program for admission of students in college. After admission is done, print a simple message and total number of students. Now some of the students are leaving college due to  some reason so remove them from college. Some of the students are getting awards for best students so print them as well.\r\n");
                            StudentAdmission studentAdmission = new StudentAdmission();
                            studentAdmission.Addmission();


                            break;


                        case "4":
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
