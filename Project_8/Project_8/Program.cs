using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Project_8.Program;

namespace Project_8
{
    //Enum
    public enum DesignationType
    {
        Developer,
        QA,

    }

    // addRecord
    class EmployeeRecord
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string EmailAddress { get; set; }

        public int PhoneNumber { get; set; }

        public DesignationType Designation
        {
            get;
            set;
        }


        public string Salary { get; set; }

    }


    //
    public class EmployeeAdd
    {
        SortedList<int, EmployeeRecord> employeeRecord = new SortedList<int, EmployeeRecord>();
        public void AddEmployee()
        {

            EmployeeRecord employee = new EmployeeRecord();

            //1
            Console.WriteLine("Enter First name:");
            string firstName = Console.ReadLine();

            //2
            Console.WriteLine("Enter Last name:");
            string lastName = Console.ReadLine();

            //3
            Console.WriteLine("Enter Gender:");
            string Gender = Console.ReadLine();

            //4 
            Console.WriteLine("Enter EmailAddress:");
            string EmailAddress = Console.ReadLine();

            //5
            Console.WriteLine("Enter Phonenumber:");
            int Phonenumber = int.Parse(Console.ReadLine());

            //6
            Console.WriteLine("Enter employee designation ( Developer, QA,):");
            string userInput = Console.ReadLine();

            DesignationType designationType;
            if (Enum.TryParse(userInput, out designationType))
            {
                employee.Designation = designationType;
                // Do something with the employee object, such as add it to a list or display its properties
            }
            else
            {
                Console.WriteLine("Invalid designation entered.");
            }

            //7 
            Console.WriteLine("Enter Salary:");
            string Salary = Console.ReadLine();

            // 8
            Console.WriteLine("Enter EmployeeId:");
            int EmployeeId =int.Parse( Console.ReadLine());

            EmployeeRecord newElement = new EmployeeRecord { FirstName = firstName, LastName = lastName, Gender = Gender, PhoneNumber = Phonenumber, EmailAddress = EmailAddress, Designation = employee.Designation, Salary = Salary };

            employeeRecord.Add(EmployeeId, newElement);

            // serialize JSON to a string and then write string to a file
         //   File.WriteAllText(@"C:\Users\chint\source\repos\EmployeeRecord.json", JsonConvert.SerializeObject(newElement));

            // serialize JSON directly to a file
            using (StreamWriter file = File.AppendText(@"C:\Users\chint\source\repos\EmployeeRecord.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, newElement);
                Console.WriteLine("File is Serialized");

            }
          


        }


        public void DisplayRecord()
        {
           

            using (StreamReader file = File.OpenText(@"C:\Users\chint\source\repos\EmployeeRecord.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                EmployeeRecord employee = (EmployeeRecord)serializer.Deserialize(file, typeof(EmployeeRecord));
              
                Console.WriteLine($" FirstName: {employee.FirstName} , LastName : {employee.LastName}, Gender :{employee.Gender}   PhoneNumber : {employee.PhoneNumber}  EmailAddress : {employee.EmailAddress}  Designation : {employee.Designation}  Salary : {employee.Salary}");
            }

            
        }

    }

    // 



    internal class Program
    {

        static void Main(string[] args)
        {
            SortedList<string, string[]> employeeRecord = new SortedList<string, string[]>();





            Console.WriteLine("Choose options");
            Console.WriteLine("1 --> **Create a C# Console application which creates Employee record and store in json file.** ");







            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("**Create a C# Console application which creates Employee record and store in json file.**");

                string inputAddStudents = "n";

                do
                {
                  
                    Console.WriteLine("Select 1, 2");
                    int userInput = int.Parse(Console.ReadLine());

                    if (userInput == 1)
                    {
                        Console.WriteLine("1. Add Employee Record ");
                        EmployeeAdd employeeAdd = new EmployeeAdd();
                        employeeAdd.AddEmployee();
                        Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                        inputAddStudents = Console.ReadLine();
                    }
                    if (userInput == 2)
                    {
                        Console.WriteLine("2. Display Employee Record ");
                        EmployeeAdd employeeAdd = new EmployeeAdd();
                        employeeAdd.DisplayRecord();
                        Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                        inputAddStudents = Console.ReadLine();
                    }
                   

                } while (inputAddStudents == "y");



            }




        }
    }
}

