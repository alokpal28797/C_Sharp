using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
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

        public static bool ZipCheck(this string num)
        {
            Regex zipRegex = new Regex("^[1-9][0-9]{5}$");
            bool checkNum = zipRegex.IsMatch(num.ToString());

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


        public static string ToFormattedString(this DateTime date)
        {
            return date.ToString("dd-MMM-yyyy");
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

            public string Department { get; set; }

            public string Designation { get; set; }

            public int Salary { get; set; }

            public string State { get; set; }
            public string City { get; set; }
            public string Postalcode { get; set; }
            public string DateOfJoining { get; set; }
            public int Experience
            {
                get
                {
                    //// Calculate the difference between the current date and the date of joining
                    TimeSpan span = DateTime.Today - DateTime.Parse( DateOfJoining);
                    string yrs = "years";
                    //// Return the number of years as an integer
                    return (int)((span.TotalDays / 365.25));
               }
            }
            public string Remarks { get; set; }

            public int EmployeeID { get; set; } 


            public EmployeeData(string fullName, string gender, string emailAddress, string phoneNumber, string department, string designation, int salary, string state ,string city , string postalcode , string dateOfJoining , string remarks, int employeeID)
            {
                this.FullName = fullName;
                this.Gender = gender;
                this.EmailAddress = emailAddress;
                this.PhoneNumber = phoneNumber;
                this.Department = department;
                this.Designation = designation;
                this.Salary = salary;
                this.State = state;
                this.City = city;
                this.Postalcode = postalcode; 
                this.DateOfJoining = dateOfJoining; 
                this.Remarks = remarks;
                this.EmployeeID = employeeID;
            }

            public static List<EmployeeData> AddEmployees(List<EmployeeData> employeeRecord)
            {
                string fullName = "";
                string gender = "";
                string emailAddress = "";
                string phoneNumber = "";
                string department = "";
                string designation = "";
                int salary = 0;
                string state = "";
                string city = "";
                string postalcode = "";
                string dateTime = "";
                string remarks = "";
                int employeeID = 0;



                //1 ID

                bool checkStudentID = true;
                while (checkStudentID)
                {
                    try
                    {
                        Console.Write("Please Enter Student id : ");
                        employeeID = Convert.ToInt32(Console.ReadLine());
                        if (CheckDuplicates(employeeID) == true)
                        {
                            checkStudentID = true;
                        }
                        else
                        {
                            break;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }






                //2 name
                Console.Write("Enter Full name : ");
                fullName = Console.ReadLine();
                while (Validations.EmptyNull(fullName) == true || Validations.IsString(fullName) == false)
                {
                    if (Validations.EmptyNull(fullName) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.Write("Enter fullName name: ");
                        fullName = Console.ReadLine();

                    }
                    if (Validations.IsString(fullName) == false)
                    {
                        Console.WriteLine("**Integer is not Allowed in Name **");
                        Console.Write("Enter fullName name: ");
                        fullName = Console.ReadLine();
                    }

                }



                //3 Gender
                Console.Write("Enter Gender: (F) for Female  &  (M) for Male : ");
                gender = Console.ReadLine();

                while (Validations.EmptyNull(gender) == true || Validations.IsString(gender) == false || Validations.GenderCheck(gender) == false)
                {
                    if (Validations.EmptyNull(gender) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.Write("Enter Gender: (F) for Female  &  (M) for Male : ");
                        gender = Console.ReadLine();

                    }
                    if (Validations.IsString(gender) == false)
                    {
                        Console.WriteLine("**Integer is not Allowed in Name **");
                        Console.Write("Enter Gender: (F) for Female  &  (M) for Male : ");
                        gender = Console.ReadLine();
                    }
                    if (Validations.GenderCheck(gender) == false)
                    {
                        Console.WriteLine("**Please Enter correct Input **");
                        Console.Write("Enter Gender: (F) for Female  &  (M) for Male : ");
                        gender = Console.ReadLine();
                    }
                }




                //4 Gender 
                Console.Write("Enter EmailAddress : ");
                emailAddress = Console.ReadLine();

                //CheckDuplicate(emailAddress)

                while (Validations.EmptyNull(emailAddress) == true || Validations.CorrectEmail(emailAddress) == false)
                {
                    if (Validations.EmptyNull(emailAddress) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.Write("Enter Last name : ");
                        emailAddress = Console.ReadLine();

                    }
                    if (Validations.CorrectEmail(emailAddress) == false)
                    {
                        Console.WriteLine("**This is not Valid**");
                        Console.Write("Enter Email Address : ");
                        emailAddress = Console.ReadLine();

                    }

                }



                //5 Phone 
                Console.Write("Enter Phonenumber : ");

                phoneNumber = (Console.ReadLine());
                while (Validations.PhoneNumberCheck(phoneNumber) == false || Validations.EmptyNull(phoneNumber) == true)
                {
                    if (Validations.EmptyNull(phoneNumber) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.Write("Enter phoneNumber : ");
                        phoneNumber = Console.ReadLine();

                    }
                    if (Validations.PhoneNumberCheck(phoneNumber) == false)
                    {
                        Console.WriteLine("**Please Enter Valid (10 digits) PhoneNumber **");
                        Console.Write("Enter phoneNumber : ");
                        phoneNumber = Console.ReadLine();

                    }

                }





                //6 Enter employee designation ( Developer, QA,)
                bool flag = true;
                while (flag == true)
                {
                    Console.Write("Enter employee Department ( Developer, QA, Marketing, SEO, HR, Sales) : ");
                    try
                    {
                        department = Console.ReadLine().ToLower().Trim();

                        if (Validations.EmptyNull(department) == true)
                        {
                            Console.WriteLine("**This Field is Required**");
                            Console.Write("Enter employee Department ( Developer, QA, Marketing, SEO, HR, Sales) : ");
                            department = Console.ReadLine().ToLower().Trim();

                        }
                        if (Validations.IsString(department) == false)
                        {
                            Console.WriteLine("**Integer is not Allowed in Name **");
                            Console.Write("Enter employee Department ( Developer, QA, Marketing, SEO, HR, Sales) : ");
                            department = Console.ReadLine().ToLower().Trim();
                        }

                        if (department.ToLower().Trim() == "development")
                        {
                            department = Convert.ToString(DesignationType.Development);
                            flag = false;
                        }
                        if (department.ToLower().Trim() == "sales")
                        {
                            department = Convert.ToString(DesignationType.Sales);
                            flag = false;
                        }
                        if (department.ToLower().Trim() == "hr")
                        {
                            department = Convert.ToString(DesignationType.HR);
                            flag = false;
                        }
                        if (department.ToLower().Trim() == "seo")
                        {
                            department = Convert.ToString(DesignationType.SEO);
                            flag = false;
                        }
                        if (department.ToLower().Trim() == "qa")
                        {
                            department = Convert.ToString(DesignationType.QA);
                            flag = false;
                        }
                        if (department.ToLower().Trim() == "marketing")
                        {
                            department = Convert.ToString(DesignationType.Marketing);
                            flag = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        Console.WriteLine(ex.Message);
                    }
                }


                //7 Designation
                Console.Write("Enter designation : ");
                designation = Console.ReadLine();
                while (Validations.EmptyNull(designation) == true || Validations.IsString(designation) == false)
                {
                    if (Validations.EmptyNull(designation) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.Write("Enter designation : ");
                        designation = Console.ReadLine();

                    }
                    if (Validations.IsString(designation) == false)
                    {
                        Console.WriteLine("**Integer is not Allowed in Name **");
                        Console.Write("Enter designation : ");
                        designation = Console.ReadLine();
                    }

                }





                //8 salary
               
                bool salaryFlag = true;
                while (salaryFlag == true)
                {
                    try
                    {
                        Console.Write("Enter your salary: ");
                        string salaryInput = Console.ReadLine();

                        if (int.TryParse(salaryInput, out salary))
                        {
                           Console.WriteLine(salary);
                            if ( salary < 10000 || salary > 500000)
                            {
                                salaryFlag = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer number.");
                            salaryFlag = true;
                        }


                       
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }

                }


                //9 state
                Console.Write("Enter State name : ");
                state = Console.ReadLine();
                while (Validations.EmptyNull(state) == true || Validations.IsString(state) == false)
                {
                    if (Validations.EmptyNull(state) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.Write("Enter State name: ");
                        state = Console.ReadLine();

                    }
                    if (Validations.IsString(state) == false)
                    {
                        Console.WriteLine("**Integer is not Allowed in Name **");
                        Console.Write("Enter State name: ");
                        state = Console.ReadLine();
                    }

                }



                //10 city
                Console.Write("Enter City name : ");
                city = Console.ReadLine();
                while (Validations.EmptyNull(city) == true || Validations.IsString(city) == false)
                {
                    if (Validations.EmptyNull(city) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.Write("Enter City name: ");
                        city = Console.ReadLine();

                    }
                    if (Validations.IsString(city) == false)
                    {
                        Console.WriteLine("**Integer is not Allowed in Name **");
                        Console.Write("Enter City name: ");
                        city = Console.ReadLine();
                    }

                }





                // 11 date
                
                string dateFormat = "dd/MM/yyyy";
                while (true)
                {
                    Console.Write("Enter date of joining (dd/MM/yyyy): ");
                    string dateStr = Console.ReadLine();

                    // Parse the date string using the TryParseExact method and validate the format
                    DateTime date;
                    if (DateTime.TryParseExact(dateStr, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        // If the parse succeeds, create a new EmployeeData object and set its properties
                        dateTime = date.ToFormattedString();
                        Console.WriteLine(dateTime);
                        break; // Exit the loop since a valid date has been entered
                    }
                    else
                    {
                        // If the parse fails or the format is invalid, print an error message and continue the loop
                        Console.WriteLine($"Invalid date format! Please enter the date in the format: {dateFormat}");
                    }
                }


                //12 postal
                Console.Write("Enter Postalcode : ");
                postalcode = (Console.ReadLine());
                while (Validations.ZipCheck(postalcode) == false || Validations.EmptyNull(postalcode) == true)
                {
                    if (Validations.EmptyNull(postalcode) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.Write("Enter Postalcode : ");
                        postalcode = Console.ReadLine();

                    }
                    if (Validations.ZipCheck(postalcode) == false)
                    {
                        Console.WriteLine("**Please Enter Valid (6 digits) Postal code **");
                        Console.Write("Enter Postalcode : ");
                        postalcode = Console.ReadLine();

                    }

                }


                //13 remarks

                Console.Write("Enter Remarks here : ");
                remarks = Console.ReadLine();
                while (Validations.EmptyNull(remarks) == true )
                {
                    if (Validations.EmptyNull(remarks) == true)
                    {
                        Console.WriteLine("**This Field is Required**");
                        Console.Write("Enter Remarks here : ");
                        remarks = Console.ReadLine();

                    }


                }


               
              


                // Add Data

                EmployeeData employee = new EmployeeData(fullName, gender, emailAddress, phoneNumber, department, designation, salary, state, city, postalcode, dateTime , remarks, employeeID);

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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //if (employeeRecord.Count > 0)
                //{
                //    foreach (var employee in employeeRecord)
                //    {
                //        Console.WriteLine("\nEmployee Details Are....");
                //        Console.WriteLine(" FirstName : " + employee.FullName);
                //        Console.WriteLine(" LastName : " + employee.EmailAddress);
                //        Console.WriteLine(" LastName : " + employee.PhoneNumber);
                //        Console.WriteLine(" Degignation : " + employee.Designation);
                //        Console.WriteLine(" Salary : " + employee.Salary);
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("There is no employees");
                //}

            }

            //public static bool CheckDuplictes(int id)
            //{
            //    string filePath = ConfigurationManager.AppSettings["FilePath"];


            //    string jsonFile = "";
            //    if (File.Exists(filePath))
            //    {
            //        jsonFile = File.ReadAllText(filePath);

            //        var fileArray = JArray.Parse(jsonFile);

            //        foreach (var em in fileArray)
            //        {
            //            try
            //            {
            //                Console.WriteLine(em["EmployeeID"]);

            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }




            //        //List<JObject> objects = JArray.Parse(jsonFile).Cast<JObject>().ToList();

            //        //// Sort the list based on the "id" element
            //        //objects = objects.OrderByDescending(o => o["Salary"]).ToList();

            //        //foreach (JObject obj in objects)
            //        //{
            //        //    Console.WriteLine($"id: {obj["Salary"]}, age: {obj["age"]}");
            //        //}

            //    }
            //    return true;
            //}


            public static bool CheckDuplicates(int id)
            {
                string filePath = ConfigurationManager.AppSettings["FilePath"];

                string jsonFile = "";
                if (File.Exists(filePath))
                {
                    jsonFile = File.ReadAllText(filePath);

                    var people = JsonConvert.DeserializeObject<List<EmployeeData>>(jsonFile);

                    // Check if the given id already exists in the list of employees
                    bool idExists = people.Any(p => p.EmployeeID == id);

                    if (idExists)
                    {
                        Console.WriteLine($"Employee with ID {id} already exists.");
                        return true;
                    }
                }

                return false;
            }

        }

        static void Main(string[] args)
        {
            {
                
                List<EmployeeData> employeeRecord = new List<EmployeeData>();
                List<EmployeeData> people = new List<EmployeeData>();
                string filePath = ConfigurationManager.AppSettings["FilePath"];

                List<string> Email = new List<string>();

                string jsonFile = "";
                if (File.Exists(filePath))
                {
                    jsonFile = File.ReadAllText(filePath);

                    var filearray = JArray.Parse(jsonFile);

                    string jsonData = File.ReadAllText(filePath);
                    people = JsonConvert.DeserializeObject<List<EmployeeData>>(jsonData);

                    foreach (var em in filearray)
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

                    var sortedList = people.OrderByDescending(p => p.Salary);

                    // Serialize the sorted list back to JSON
                    string sortedJsonData = JsonConvert.SerializeObject(sortedList, Formatting.Indented);

                    // Write the sorted data back to the file
                    File.WriteAllText(filePath, sortedJsonData);
                }

                



                Console.WriteLine("Choose options");
                Console.WriteLine("1 --> **Create a C# Console application which creates Employee record and store in json file.** ");

                bool exitProgram = false;
                while (!exitProgram)
                {
                    Console.WriteLine();
                    Console.WriteLine("**Create a C# Console application which creates Employee record and store in json file.**");

                    string inputAddStudents = "n";

                    do
                    {

                        Console.WriteLine("Select 1, 2 ,3 ,4");
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
                        if (userInput == 3)
                        {
                            jsonFile = "";
                            if (File.Exists(filePath))
                            {
                                jsonFile = File.ReadAllText(filePath);

                                var filearray = JArray.Parse(jsonFile);

                                string jsonData = File.ReadAllText(filePath);
                                people = JsonConvert.DeserializeObject<List<EmployeeData>>(jsonData);

                                var sortedList = people.OrderByDescending(p => p.Salary);

                                // Serialize the sorted list back to JSON
                                string sortedJsonData = JsonConvert.SerializeObject(sortedList, Formatting.Indented);

                                // Write the sorted data back to the file
                                File.WriteAllText(filePath, sortedJsonData);
                                Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                                inputAddStudents = Console.ReadLine();
                                exitProgram = true;
                            }
                        }

                    } while (inputAddStudents == "y");

                }
                Environment.Exit(0);

            }
        }
    }
}
