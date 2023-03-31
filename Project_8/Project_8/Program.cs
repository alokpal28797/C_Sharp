using System;
using System.Collections;
using System.Collections.Generic;
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
        public void AddEmployee()
        {

            // 
            SortedList<int, EmployeeRecord>  employeeRecord = new SortedList<int, EmployeeRecord>();

           

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
            int Phonenumber = int.Parse( Console.ReadLine());

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

            EmployeeRecord newElement = new EmployeeRecord { FirstName = firstName , LastName = lastName , Gender = Gender , PhoneNumber = Phonenumber , EmailAddress = EmailAddress, Designation = employee.Designation };

            employeeRecord.Add(1, newElement);

            foreach (KeyValuePair<int, EmployeeRecord> kvp in employeeRecord)
            {
                Console.WriteLine($"Key: {kvp.Key}, FirstName: {kvp.Value.FirstName} , LastName : {kvp.Value.LastName}, Gender :{kvp.Value.Gender}   PhoneNumber : {kvp.Value.PhoneNumber}  EmailAddress : {kvp.Value.EmailAddress}  Designation : {kvp.Value.FirstName} ");
            }
        }
    }


    internal class Program
    {
       
        static void Main(string[] args)
        {
            SortedList<string, string[]> employeeRecord = new SortedList<string, string[]>();


            EmployeeAdd employeeAdd = new EmployeeAdd();
            employeeAdd.AddEmployee();


        }
    }
}
