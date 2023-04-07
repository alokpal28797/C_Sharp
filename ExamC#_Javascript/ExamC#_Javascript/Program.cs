using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamC__Javascript
{
    public static class Validations
    {
        public static bool EmptyNull(this string str)
        {
            if (!string.IsNullOrEmpty(str) || !string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            return true;
        }


        public static bool IsString(this string str)
        {
            char[] ch = str.ToCharArray();
            bool containsNumbers = true;
            foreach (char ch2 in ch)
            {
                if (Char.IsDigit(ch2))
                {
                    containsNumbers = false;
                    break;
                }

            }
            return containsNumbers;
        }

        public static bool GenderCheck(this string str)
        {
            if (str.ToLower() == "f" || str.ToLower() == "m")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CorrectEmail(this string str)
        {
            Regex emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            bool Correctemail = emailRegex.IsMatch(str);
            if (Correctemail)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool PhoneNumberCheck(this long num)
        {
            Regex phonenumberRegex = new Regex(@"^\+?[1-9][0-9]{9}$");
            bool checkNum = phonenumberRegex.IsMatch(num.ToString());

            if (checkNum == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool SalaryCheck(this long salary)
        {
            if (salary < 10000)
            {
                Console.WriteLine("Salary is Very less ( 10000)");
                return true;
            }
            else if (salary > 50000)
            {
                Console.WriteLine("Salary is Very Much (50000)");
                return true;
            }
            return false;
        }



    }
    internal class Program
    {
        public enum DesignationType
        {
            Developer,
            QA
        }

        class EmployeeData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string EmailAddress { get; set; }
            public long PhoneNumber { get; set; }

            public string Designation { get; set; }

            public int Salary { get; set; }


            public EmployeeData(string firstName, string lastName, string gender, string emailAddress, long phoneNumber, string designation, int salary)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Gender = gender;
                this.EmailAddress = emailAddress;
                this.PhoneNumber = phoneNumber;
                this.Designation = designation;
                this.Salary = salary;

            }

            public static List<EmployeeData> AddEmployees(List<EmployeeData> employeeRecord)
            {
                string firstName = "";
                string lastName = "";
                string gender = "";
                string emailAddress = "";
                long phoneNumber = 0;
                string designation = "";
                int salary = 0;





                //1
                Console.WriteLine("Enter First name:");
                firstName = Console.ReadLine();
                while (Validations.EmptyNull(firstName) == true || Validations.IsString(firstName) == false)
                {
                    if (Validations.EmptyNull(firstName) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.WriteLine("Enter First name:");
                        firstName = Console.ReadLine();

                    }
                    if (Validations.IsString(firstName) == false)
                    {
                        Console.WriteLine("**Integer is not Allowed in Name **");
                        Console.WriteLine("Enter First name:");
                        firstName = Console.ReadLine();
                    }

                }

                //2
                Console.WriteLine("Enter Last name:");
                lastName = Console.ReadLine();
                while (Validations.EmptyNull(lastName) == true || Validations.IsString(lastName) == false)
                {
                    if (Validations.EmptyNull(lastName) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.WriteLine("Enter Last name:");
                        lastName = Console.ReadLine();

                    }
                    if (Validations.IsString(lastName) == false)
                    {
                        Console.WriteLine("**Integer is not Allowed in Name **");
                        Console.WriteLine("Enter Last name:");
                        lastName = Console.ReadLine();
                    }
                }

                //3
                Console.WriteLine("Enter Gender: (F) for Female  &  (M) for Male");
                gender = Console.ReadLine();

                while (Validations.EmptyNull(gender) == true || Validations.IsString(gender) == false || Validations.GenderCheck(gender) == false)
                {
                    if (Validations.EmptyNull(gender) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.WriteLine("Enter Gender: (F) for Female  &  (M) for Male");
                        gender = Console.ReadLine();

                    }
                    if (Validations.IsString(gender) == false)
                    {
                        Console.WriteLine("**Integer is not Allowed in Name **");
                        Console.WriteLine("Enter Gender: (F) for Female  &  (M) for Male");
                        gender = Console.ReadLine();
                    }
                    if (Validations.GenderCheck(gender) == false)
                    {
                        Console.WriteLine("**Please Enter correct Input **");
                        Console.WriteLine("Enter Gender: (F) for Female  &  (M) for Male");
                        gender = Console.ReadLine();
                    }
                }
                //4 
                Console.WriteLine("Enter EmailAddress:");
                emailAddress = Console.ReadLine();


                while (Validations.EmptyNull(emailAddress) == true || Validations.CorrectEmail(emailAddress) == false)
                {
                    if (Validations.EmptyNull(emailAddress) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.WriteLine("Enter Last name:");
                        emailAddress = Console.ReadLine();

                    }
                    if (Validations.EmptyNull(emailAddress) == false)
                    {
                        Console.WriteLine("**This is not Valid**");
                        Console.WriteLine("Enter Email Address:");
                        emailAddress = Console.ReadLine();

                    }

                }



                //5
                Console.WriteLine("Enter Phonenumber:");
                phoneNumber = long.Parse(Console.ReadLine());
                while (Validations.PhoneNumberCheck(phoneNumber) == false)
                {
                    try
                    {
                        if (Validations.PhoneNumberCheck(phoneNumber) == false)
                        {
                            Console.WriteLine("**PhoneNumber Should be of 10 digits**");
                            Console.WriteLine("Enter Phonenumber:");
                            phoneNumber = long.Parse(Console.ReadLine());

                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }

                }

                //6 Enter employee designation ( Developer, QA,)


                bool flag = true;



                while (flag == true)
                {
                    try
                    {
                        Console.WriteLine("Enter employee designation ( Developer, QA,):");
                        designation = Console.ReadLine().ToLower().Trim();

                        if (Validations.EmptyNull(designation) == true)
                        {
                            Console.WriteLine("**This Field is Required**");
                            Console.WriteLine("Enter employee designation ( Developer, QA,):");
                            designation = Console.ReadLine().ToLower().Trim();

                        }
                        if (Validations.IsString(designation) == false)
                        {
                            Console.WriteLine("**Integer is not Allowed in Name **");
                            Console.WriteLine("Enter employee designation ( Developer, QA,):");
                            designation = Console.ReadLine().ToLower().Trim();
                        }

                        if (designation.ToLower().Trim() == "developer")
                        {
                            designation = Convert.ToString(DesignationType.Developer);
                            flag = false;
                        }
                        if (designation.ToLower().Trim() == "qa")
                        {
                            designation = Convert.ToString(DesignationType.QA);
                            flag = false;
                        }



                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        Console.WriteLine(ex.Message);
                    }
                }







                //7
                Console.WriteLine("Enter employee Salary ");
                salary = int.Parse(Console.ReadLine());
                bool salaryFlag = true;
                while (salaryFlag == true)
                {
                    try
                    {
                        if (Validations.SalaryCheck(salary) == true)
                        {
                            Console.WriteLine("Enter employee Salary ");
                            salary = int.Parse(Console.ReadLine());

                        }
                        else
                        {
                            salaryFlag = false;
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }

                }

                EmployeeData employee = new EmployeeData(firstName, lastName, gender, emailAddress, phoneNumber, designation, salary);

                employeeRecord.Add(employee);
                string result = JsonConvert.SerializeObject(employeeRecord);
                //Console.WriteLine(result);

                string filePath = ConfigurationManager.AppSettings["FilePath"];

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(result);
                }

                return employeeRecord;

            }

            public static void DisplayRecord(List<EmployeeData> employeeRecord)
            {
                try
                {
                    string filePath = ConfigurationManager.AppSettings["FilePath"];
                   // string file = @"C:\Users\alokp\source\repos\ EmployeeData_TodayDate.json";
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        Console.WriteLine("\nEmployee Details Areee....");
                        Console.WriteLine(sr.ReadToEnd());


                    }
                }
                catch (Exception ex) { }

                if (employeeRecord.Count > 0)
                {
                    foreach (var employee in employeeRecord)
                    {
                        Console.WriteLine("\nEmployee Details Are....");
                        Console.WriteLine(" FirstName : " + employee.FirstName);
                        Console.WriteLine(" LastName : " + employee.LastName);
                        Console.WriteLine(" LastName : " + employee.EmailAddress);
                        Console.WriteLine(" LastName : " + employee.PhoneNumber);
                        Console.WriteLine(" Degignation : " + employee.Designation);
                        Console.WriteLine(" Salary : " + employee.Salary);
                    }
                }
                else
                {
                    Console.WriteLine("There is no employees");
                }

            }

        }

        static void Main(string[] args)
        {
            {
                List<EmployeeData> employeeRecord = new List<EmployeeData>();

                string filePath = ConfigurationManager.AppSettings["FilePath"];

                string jsonFile = "";
                if (File.Exists(filePath))
                {
                    jsonFile = File.ReadAllText(filePath);

                    var fileArray = JArray.Parse(jsonFile);

                    foreach (var em in fileArray)
                    {
                        try
                        {
                            employeeRecord.Add(em.ToObject<EmployeeData>());

                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    foreach (var employee in employeeRecord)
                    {
                        Console.WriteLine(employee.EmailAddress);
                        Console.WriteLine(employee.Salary);

                    }
                }

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
                            employeeRecord = EmployeeData.AddEmployees(employeeRecord);
                            Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                            inputAddStudents = Console.ReadLine();
                        }
                        if (userInput == 2)
                        {
                            Console.WriteLine("2. Display Employee Record ");
                            EmployeeData.DisplayRecord(employeeRecord);
                            Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                            inputAddStudents = Console.ReadLine();
                        }


                    } while (inputAddStudents == "y");

                }

            }
        }
    }
}
