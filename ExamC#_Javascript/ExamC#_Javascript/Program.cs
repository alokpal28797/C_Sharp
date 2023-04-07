using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
        public static bool PhoneNumberCheck(this string num)
        {
            Regex phonenumberRegex = new Regex(@"^(\+?\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$");
            bool checkNum = phonenumberRegex.IsMatch(num.ToString());

            try
            {
                if (checkNum == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("**Please enter correct value**");
                return false;
            }
           
            
        }
    



    }
    internal class Program
    {
        public enum DesignationType
        {
            QA,
            Sales,
            Marketing,
            Development,
            HR,
            SEO,

        }

        class EmployeeData
        {
            public string FullName { get; set; }
         
            public string Gender { get; set; }
            public string EmailAddress { get; set; }
            public string PhoneNumber { get; set; }

            public string Designation { get; set; }

            public int Salary { get; set; }


            public EmployeeData( string fullName, string gender, string emailAddress, string phoneNumber, string designation, int salary)
            {
                this.FullName = fullName;
                
                this.Gender = gender;
                this.EmailAddress = emailAddress;
                this.PhoneNumber = phoneNumber;
                this.Designation = designation;
                this.Salary = salary;

            }

            public static List<EmployeeData> AddEmployees(List<EmployeeData> employeeRecord)
            {
                string fullName = "";
                string gender = "";
                string emailAddress = "";
                string  phoneNumber = "";
                string designation = "";
                int salary = 0;


               Console.WriteLine( CheckDuplictes());


                //1
                Console.WriteLine("Enter Full name:");
                fullName = Console.ReadLine();
                while (Validations.EmptyNull(fullName) == true || Validations.IsString(fullName) == false)
                {
                    if (Validations.EmptyNull(fullName) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.WriteLine("Enter fullName name:");
                        fullName = Console.ReadLine();

                    }
                    if (Validations.IsString(fullName) == false)
                    {
                        Console.WriteLine("**Integer is not Allowed in Name **");
                        Console.WriteLine("Enter fullName name:");
                        fullName = Console.ReadLine();
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

                //CheckDuplicate(emailAddress)

                while (Validations.EmptyNull(emailAddress) == true || Validations.CorrectEmail(emailAddress) == false)
                {
                    if (Validations.EmptyNull(emailAddress) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.WriteLine("Enter Last name:");
                        emailAddress = Console.ReadLine();

                    }
                    if (Validations.CorrectEmail(emailAddress) == false)
                    {
                        Console.WriteLine("**This is not Valid**");
                        Console.WriteLine("Enter Email Address:");
                        emailAddress = Console.ReadLine();

                    }

                }



                //5
                Console.WriteLine("Enter Phonenumber:");

                phoneNumber = (Console.ReadLine());
                while (Validations.PhoneNumberCheck(phoneNumber) == false  || Validations.EmptyNull(phoneNumber)== true)
                {
                    if (Validations.EmptyNull(phoneNumber) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.WriteLine("Enter phoneNumber:");
                        phoneNumber = Console.ReadLine();

                    }
                    if (Validations.PhoneNumberCheck(phoneNumber) == false)
                    {
                        Console.WriteLine("**Please Enter Valid (10 digits) PhoneNumber **");
                        Console.WriteLine("Enter phoneNumber:");
                        phoneNumber = Console.ReadLine();

                    }

                }





                //6 Enter employee designation ( Developer, QA,)


                bool flag = true;


                while (flag == true)
                {
                    Console.WriteLine("Enter employee designation ( Developer, QA,Marketing,SEO,HR,Sales):");
                    try
                    {
                        //Console.WriteLine("Enter employee designation ( Developer, QA,Marketing,SEO,HR,Sales):");
                        designation = Console.ReadLine().ToLower().Trim();

                        if (Validations.EmptyNull(designation) == true)
                        {
                            Console.WriteLine("**This Field is Required**");
                            Console.WriteLine("Enter employee designation ( Developer, QA,Marketing,SEO,HR,Sales):");
                            designation = Console.ReadLine().ToLower().Trim();

                        }
                        if (Validations.IsString(designation) == false)
                        {
                            Console.WriteLine("**Integer is not Allowed in Name **");
                            Console.WriteLine("Enter employee designation ( Developer, QA,Marketing,SEO,HR,Sales):");
                            designation = Console.ReadLine().ToLower().Trim();
                        }

                        if (designation.ToLower().Trim() == "development")
                        {
                            designation = Convert.ToString(DesignationType.Development);
                            flag = false;
                        }
                        if (designation.ToLower().Trim() == "sales")
                        {
                            designation = Convert.ToString(DesignationType.Sales);
                            flag = false;
                        }
                        if (designation.ToLower().Trim() == "hr")
                        {
                            designation = Convert.ToString(DesignationType.HR);
                            flag = false;
                        }
                        if (designation.ToLower().Trim() == "seo")
                        {
                            designation = Convert.ToString(DesignationType.SEO);
                            flag = false;
                        }
                        if (designation.ToLower().Trim() == "qa")
                        {
                            designation = Convert.ToString(DesignationType.QA);
                            flag = false;
                        }
                        if (designation.ToLower().Trim() == "marketing")
                        {
                            designation = Convert.ToString(DesignationType.Marketing);
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
               

                EmployeeData employee = new EmployeeData(fullName, gender, emailAddress, phoneNumber, designation, salary);

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
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        Console.WriteLine("\nEmployee Details Areee....");
                        Console.WriteLine(sr.ReadToEnd());


                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }

                if (employeeRecord.Count > 0)
                {
                    foreach (var employee in employeeRecord)
                    {
                        Console.WriteLine("\nEmployee Details Are....");
                        Console.WriteLine(" FirstName : " + employee.FullName);
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

            public static bool CheckDuplictes()
            {
                string filePath = ConfigurationManager.AppSettings["FilePath"];

                List<string> Email = new List<string>();

                string jsonFile = "";
                if (File.Exists(filePath))
                {
                    jsonFile = File.ReadAllText(filePath);

                    var fileArray = JArray.Parse(jsonFile);

                    foreach (var em in fileArray)
                    {
                        try
                        {
                            Console.WriteLine(em["FullName"]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
            {
                List<EmployeeData> employeeRecord = new List<EmployeeData>();

                string filePath = ConfigurationManager.AppSettings["FilePath"];

                List<string> Email  = new List<string>();

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
                        Email.Add(employee.EmailAddress);

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

                        Console.WriteLine("Select 1, 2 ,4");
                        int userInput = int.Parse(Console.ReadLine());

                        if (userInput == 1)
                        {
                            Console.WriteLine("1. Add Employee Record ");
                            employeeRecord = EmployeeData.AddEmployees(employeeRecord);
                            Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                            inputAddStudents = Console.ReadLine();
                        }
                        if (userInput == 4)
                        {
                            Console.WriteLine("4. Display Employee Record ");
                            EmployeeData.DisplayRecord(employeeRecord);
                            Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                            inputAddStudents = Console.ReadLine();
                        }
                        if (userInput == 2)
                        {
                            Console.WriteLine("2. Delete Data");
                            Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                            inputAddStudents = Console.ReadLine();
                        }


                    } while (inputAddStudents == "y");

                }

            }
        }
    }
}
