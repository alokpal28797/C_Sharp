using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_4
{
    internal class Program
    {

        // 1
        class Calculator
        {
            public string Calc()
            {
                Console.WriteLine("Calculator");
                Console.WriteLine(" ");

                Console.WriteLine("Enter First Number");
                double num1 = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Second Number");
                double num2 = double.Parse(Console.ReadLine());

                Console.WriteLine("What do you want ? Add, Subtract, MultiPly, Division ");

                string userInput = Console.ReadLine();

                string output = "";
                try
                {
                    if (userInput.ToLower() == "add" || userInput.ToLower() == "addition")
                    {
                        output = Convert.ToString(num1 + num2);
                    }
                    else if (userInput.ToLower() == "subtract" || userInput.ToLower() == "subtraction")
                    {
                        output = Convert.ToString(num1 - num2);
                    }
                    else if (userInput.ToLower() == "multiply" || userInput.ToLower() == "multiplication")
                    {
                        output = Convert.ToString(num1 * num2);
                    }
                    else if (userInput.ToLower() == "division" || userInput.ToLower() == "divide")
                    {
                        output = Convert.ToString(num1 / num2);
                    }
                    else
                    {
                        Console.WriteLine("***Please Enter Valid Input***");
                    }
                    return output;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("***Please Enter Valid Integers Only***");
                    return output;
                }
            }

        }

        // 
        class StudentData
        {
            private int studentID;
            private string studentName;
            private DateTime studentDOB;
            private string studentRollNo;
            private string studentEmail;
            private double[] studentGPA;
            private bool isMale;

            public int StudentID   // property
            {
                get { return studentID; }   // get method
                set { studentID = value; }  // set method
            }


            public string StudentName
            {
                get => studentName;
                set => studentName = value;
            }
            public DateTime StudentDOB
            {
                get => studentDOB;
                set => studentDOB = value;
            }
            public string StudentRollNo
            {
                get => studentRollNo;
                set => studentRollNo = value;
            }
            public string StudentEmail
            {
                get => studentEmail;
                set => studentEmail = value;
            }
            public double[] StudentGPA
            {
                get => studentGPA;
                set => studentGPA = value;
            }
            public bool IsMale
            {
                get => isMale;
                set => isMale = value;
            }

            public StudentData()
            {

            }


            public StudentData(int studentID, string studentName, DateTime studentDOB, string studentRollNo, string studentEmail, bool isMale, double[] StudentGPA)
            {
                this.studentID = studentID;
                this.studentName = studentName;
                this.studentDOB = studentDOB;
                this.studentRollNo = studentRollNo;
                this.studentEmail = studentEmail;
                this.IsMale = isMale;

                // Initialize studentGPA array with default value of 3.0
                this.studentGPA = StudentGPA;
                for (int i = 0; i < studentGPA.Length; i++)
                {
                    Console.WriteLine(studentGPA[i]);
                }
            }


            // Copy constructor
            public StudentData(StudentData other)
            {
                studentID = other.studentID;
                studentName = other.studentName;
                studentDOB = other.studentDOB;
                studentRollNo = other.studentRollNo;
                studentEmail = other.studentEmail;
                Array.Copy(other.studentGPA, studentGPA, 5);
            }

            //
            //// Operator overloading  
            //public static StudentData operator +(StudentData s1, StudentData s2)
            //{

            //}


        }
        // Operator loading
        class Counter
        {
            private int count = 10;

            public int Value
            {
                get { return count; }
                set { count = value; }
            }

            public static Counter operator ++(Counter c)
            {
                c.count++;
                return c;
            }

            public static Counter operator --(Counter c)
            {
                c.count--;
                return c;
            }
        }
        class StudentInput
        {
            public dynamic studentInput()
            {
                Console.WriteLine("How many students are there");
                int length = int.Parse(Console.ReadLine());
                StudentData[] students = new StudentData[length];
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine("Enter details for student " + (i + 1));
                    int id = (i + 1);
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Date of Birth (YYYY-MM-DD): ");
                    DateTime dob = DateTime.Parse(Console.ReadLine());
                    Console.Write("Roll No.: ");
                    string rollNo = (Console.ReadLine());
                   
                    Console.Write("Email: ");
                    bool count = false;
                    string email = Console.ReadLine();
                   
                    while (count != true)
                    {
                        var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                        bool isValid = Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
                        Console.WriteLine(isValid);
                        if (isValid == false)
                        {
                            //console.writeline($"the email is invalid");
                            Console.WriteLine($"the email is invalid");
                            Console.Write("Email: ");
                            email = Console.ReadLine();
                            
                        }
                        else
                        {
                            count = true;
                        }

                       
                    }
                    Console.Write("Gender: ");
                    bool gender = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("Enter GPA for last 5 semesters:");
                    double[] gpa = new double[5];
                    for (int j = 0; j < 5; j++)
                    {
                        Console.WriteLine("Enter " + j + " index");
                        gpa[j] = double.Parse(Console.ReadLine());

                    }
                    students[i] = new StudentData(id, name, dob, rollNo, email, gender, gpa);
                }

                //Console.WriteLine("aaa", students);
                find(students);

                return students;
            }

            public void find(StudentData[] students)
            {
                double num = 0;
                string CR = "";
                for (int i = 0; i < students.Length; i++)
                {
                    double sum = 0;
                    //Console.WriteLine(students[i].StudentID);
                    for (int j = 0; j < 5; j++)
                    {
                        sum += students[i].StudentGPA[j];

                    }
                    Console.WriteLine("Sum " + sum);

                    if (sum > num)
                    {
                        num = sum;
                        CR = students[i].StudentName;
                    }
                    else if (num == sum)
                    {
                        CR += " " + students[i].StudentName;
                    }
                }

                Console.WriteLine("The CR of the class is :" + CR);
            }


            


            static void Main(string[] args)
            {
                Console.WriteLine("Choose options 1 - 12");
                Console.WriteLine("1 --> A program that calculate add, subtract, multiply and division");
                Console.WriteLine("2 --> Create a class of student that stores characteristics of a student, like studentID, studentName, studentDOB, studentRollNo, studentEmail, studentGPA of the last 5 semesters and other related information of the student.");
                Console.WriteLine("3 --> Operator OverLoading");




                try
                {
                    while (true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Choose Option");
                        string option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                Calculator calculator = new Calculator();
                                Console.WriteLine(calculator.Calc());
                                break;
                            case "2":
                                Console.WriteLine(" ");
                                StudentInput student = new StudentInput();
                                student.studentInput();

                                break;

                            case "3":
                                Counter counter = new Counter();
                                counter++;
                                Console.WriteLine("After increment: " + counter.Value);

                                counter--;
                                Console.WriteLine("After decrement: " + counter.Value);
                                break;
                            case "4":
                                return;
                            default:
                                Console.WriteLine("Enter options between 1-2");
                                break;

                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

