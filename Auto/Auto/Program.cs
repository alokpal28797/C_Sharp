using AutoMapper;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static C__training_Day9.StudentViewModal;

namespace C__training_Day9
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
    public class StudentEntity
    {
        
        public enum Genderenum
        {
            MALE = 1,
            FEMALE = 2
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public int StudentID { get; set; }

        public StudentEntity()
        {

        }
        public StudentEntity(string firstName, string lastName, string fullName, string gender, string email, string phonenumber, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            Phonenumber = phonenumber;
            FullName = fullName;
            StudentID = id;

        }

        public static List<StudentEntity> AddStudent(List<StudentEntity> Students)
        {
            string firstName = "";
            string lastName = "";
            string fullname = "";
            string gender = "";
            string email = "";
            string phonenumber = "";


            Console.WriteLine("Please Enter Student Details");
            //bool checkFirstNameNull = true;
            //while (checkFirstNameNull)
            //{
            //    Console.Write("Please Enter First Name : ");
            //    firstName = Console.ReadLine();
            //    checkFirstNameNull = firstName.CheckingNull();
            //    if (checkFirstNameNull == false)
            //    {
            //        checkFirstNameNull = firstName.CheckingOnlyAlphabet();
            //    }
            //}
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
            fullname = firstName + " " + lastName;

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
            email = Console.ReadLine();


            while (Validations.EmptyNull(email) == true || Validations.CorrectEmail(email) == false)
            {
                if (Validations.EmptyNull(email) == true)
                {
                    Console.WriteLine("**This Field is Required**");
                    Console.WriteLine("Enter Email Address:");
                    email = Console.ReadLine();

                }
                if (Validations.EmptyNull(email) == false)
                {
                    Console.WriteLine("**This is not Valid**");
                    Console.WriteLine("Enter Email Address:");
                    email = Console.ReadLine();

                }

            }

            //5
            Console.WriteLine("Enter Phonenumber:");
            phonenumber = (Console.ReadLine());
            while (Validations.EmptyNull(phonenumber) == true || Validations.IsString(phonenumber) == false == false)
            {
                if (Validations.EmptyNull(phonenumber) == true)
                {
                    Console.WriteLine("**This Field is Required**");
                    Console.WriteLine("Enter Phonenumber:");
                    phonenumber = Console.ReadLine();

                }
                //if (Validations.EmptyNull(phonenumber) == false)
                //{
                //    Console.WriteLine("**This is not Valid**");
                //    Console.WriteLine("Enter Phonenumber:");
                //    phonenumber = Console.ReadLine();

                //}

            }
            int id = 0;
            bool checkStudentID = true;
            while (checkStudentID)
            {
                try
                {
                    Console.Write("Please Enter Student id : ");
                    id = Convert.ToInt32(Console.ReadLine());
                    // checkPhonenumberNull = phonenumber.CheckingNull();
                    //checkStudentID = phonenumber.CheckingPhonenumber();

                    //if(Students.Count!=0)
                    bool present = false;
                    foreach (var item in Students)
                    {
                        if (id == item.StudentID)
                        {
                            Console.WriteLine("Student Id is already present");
                            checkStudentID = true;
                            present = true;
                            break;
                        }
                    }
                    if (present == false)
                    {
                        checkStudentID = false;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            StudentEntity student = new StudentEntity(firstName, lastName, fullname, gender, email, phonenumber, id);
            Students.Add(student);



            XmlSerializer Serializer = new XmlSerializer(typeof(List<StudentEntity>));
            var filename = ConfigurationManager.AppSettings["file"];
            TextWriter txtWriter = new StreamWriter(filename);

            Serializer.Serialize(txtWriter, Students);
            txtWriter.Close();



            return Students;







        }
        public static List<StudentEntity> DeleteStudent(List<StudentEntity> students)
        {
            try
            {
                Console.WriteLine("Please Enter Student id you want to delete");
                int studentsIdToRemove = Convert.ToInt32(Console.ReadLine());
                if (students.Count != 0)
                {
                    bool present = false;
                    foreach (var student in students)
                    {
                        if (student.StudentID == studentsIdToRemove)
                        {
                            students.Remove(student);
                            present = true;
                            Console.WriteLine("Student Remove Successfully");
                        }
                    }
                    if (present == false)
                    {
                        Console.WriteLine("No student Present With this id");
                    }
                }
                else
                {
                    Console.WriteLine("No student is Present");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return students;
        }
        public static string EnryptString(string strEncrypted)
        {

            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }



    }
    public class StudentViewModal
    {
        public enum gender
        {
            MALE = 1,
            FEMALE = 2
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public int StudentID { get; set; }

        public static void DisplayStudents(List<StudentEntity> students)
        {
            List<StudentViewModal> studentViewModalslist = new List<StudentViewModal>();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentEntity, StudentViewModal>();
                //Employeee e = cfg.Map<Employeee>(objEmployee);
            });
            var mapper = new Mapper(configuration);


            //Console.WriteLine(students[0].FirstName);
            foreach (var student in students)
            {
                StudentViewModal studentViewmodalobj = mapper.Map<StudentViewModal>(student);
                studentViewModalslist.Add(studentViewmodalobj);
            }

            foreach (var student in studentViewModalslist)
            {
                Console.WriteLine("\nDisplaying student details");
                Console.WriteLine("Student FullName : " + student.FullName);
                Console.WriteLine("Student Grnder : " + student.Gender);

                Console.WriteLine("Student Phone Number : " + DecryptString(student.Phonenumber));
                Console.WriteLine("Student id is  : " + student.StudentID);
                // student.Phonenumber
            }



        }


        public static string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<StudentEntity> students = new List<StudentEntity>();

            var filename = ConfigurationManager.AppSettings["file"];
            string XMLFormatData;
            if (File.Exists(filename))
            {
                
                XmlSerializer xmlserializer = new System.Xml.Serialization.XmlSerializer(typeof(List<StudentEntity>));

                //Use using so that streamReader object will be cleaned up properly after use. 
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    students = (List<StudentEntity>)xmlserializer.Deserialize(streamReader);
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

                    Console.WriteLine("Select 1, 2,3");
                    int userInput = int.Parse(Console.ReadLine());

                    if (userInput == 1)
                    {
                        Console.WriteLine("1. Add Employee Record ");
                        students = StudentEntity.AddStudent(students);
                        Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                        inputAddStudents = Console.ReadLine();
                    }
                    if (userInput == 2)
                    {
                        Console.WriteLine("2. Display Employee Record ");
                        StudentViewModal.DisplayStudents(students);
                        Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                        inputAddStudents = Console.ReadLine();
                    }
                    if (userInput == 3)
                    {
                        Console.WriteLine("2. Display Employee Record ");
                        students = StudentEntity.DeleteStudent(students);
                        Console.WriteLine("You want to do someting else. If Yes then type y else n for No;");
                        inputAddStudents = Console.ReadLine();
                    }


                } while (inputAddStudents == "y");

            }
        }
    }
 
   
}

