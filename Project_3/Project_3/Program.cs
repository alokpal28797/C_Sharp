using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    // 9
    public static class DateTimeExtensions
    {
        public static string DateFormate(this DateTime date, string format)
        {
            try
            {
                string result = "";
                if (format == "MM/dd/yyyy" || format == "dddd, dd MMMM yyyy" || format == "dd ,MMMM yyyy HH:mm:ss" || format == "yyyy MMMM" || format == "yyyy/dd/MM" || format == "yyyy/MM/dd" || format == "dd/MM/yyyy" || format == "dd/mm/yyyy")
                {
                    result = date.ToString(format);
                }
                else
                {
                    Console.WriteLine("Please Write correct format");
                }
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return date.ToString(format);
            }
        }

    }
    internal class Program
    {

        // 1
        class CreateFile
        {
            public void FileCreated()
            {
                try
                {
                    // Specify the path and filename for the new file
                    string path = @"C:\Users\chint\source\repos\newFile.txt";

                    //user Input
                    Console.WriteLine("You Can Write What You Want...");

                    // Create a new file using StreamWriter
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        // Write some text to the file
                        string input = Console.ReadLine();
                        sw.WriteLine(input);
                        sw.WriteLine("This is a new file created using C#.");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        //2
        class ReadFile
        {
            public void Read()
            {
                string path = @"C:\Users\chint\source\repos\newFile.txt";
                // Open the file for reading using StreamReader
                using (StreamReader reader = new StreamReader(path))
                {
                    // Read the entire contents of the file
                    string contents = reader.ReadToEnd();

                    // Display the contents to the console
                    Console.WriteLine(contents);
                }
            }
            public void FileReading()
            {
                try
                {
                    Console.WriteLine("** Data Written in the First File");
                    Read();

                    // Class is called to make a new file
                    CreateFile createFile = new CreateFile();
                    createFile.FileCreated();

                    Console.WriteLine("");
                    Console.WriteLine("**File is updated");
                    Read();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        //3

        class CreateArrayfile
        {
            public void ReadAppendData()
            {
                try
                {
                    string path = @"C:\Users\chint\source\repos\File.txt";
                    Console.WriteLine();
                    Console.WriteLine("The Value of the files are... ");
                    // Open the file for reading using StreamReader
                    using (StreamReader reader = new StreamReader(path))
                    {
                        // Read the entire contents of the file
                        string contents = reader.ReadToEnd();

                        // Display the contents to the console
                        Console.WriteLine(contents);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            public void ArrayfileRead()
            {
                try
                {
                    Arrayfile();
                    // Readding tht data
                    ReadAppendData();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            public void Arrayfile()
            {
                try
                {
                    Console.WriteLine("Array Length...");
                    int arrLength = int.Parse(Console.ReadLine());

                    string[] arr = new string[arrLength];
                    for (int i = 0; i < arrLength; i++)
                    {
                        Console.WriteLine("Enter value at Index " + i);
                        arr[i] = Console.ReadLine();
                    }

                    string path = @"C:\Users\chint\source\repos\File.txt";

                    //user Input

                    // Create a new file using StreamWriter
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        foreach (string s in arr)
                        {
                            sw.WriteLine(s);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }



        //4
        class AppendData
        {
            public void FileAppendData()
            {
                try
                {
                    // useer input
                    Console.WriteLine("You Can Write What You Want...");
                    //path
                    string path = @"C:\Users\chint\source\repos\AppendDataFile.txt";

                    using (StreamWriter sw = File.AppendText(path))
                    {
                        // Write some text to the file
                        string input = Console.ReadLine();
                        sw.WriteLine(input);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Value of from the file.....");

                    using (StreamReader sr = File.OpenText(path))
                    {
                        string constents = sr.ReadToEnd();
                        Console.Write(constents);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }


        // 5

        class ReadFirstLine
        {
            public void ArrayRead()
            {
                CreateArrayfile createArrayfile = new CreateArrayfile();
                createArrayfile.Arrayfile();
                Console.WriteLine();
                Console.WriteLine("The First Value of the file is");

                FileReadFirstLine();

            }
            public void FileReadFirstLine()
            {
                try
                {
                    string path = @"C:\Users\chint\source\repos\File.txt";
                    Console.WriteLine();
                    Console.WriteLine("The Value of the files are... ");
                    // Open the file for reading using StreamReader
                    using (StreamReader reader = new StreamReader(path))
                    {
                        // Read the entire contents of the file
                        string contents = reader.ReadLine();

                        // Display the contents to the console
                        Console.WriteLine(contents);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }


        // 6

        class CountLines
        {
            public void FileCountLines()
            {
                Console.WriteLine("The Number of Lines in the Append File are...");
                string path = @"C:\Users\chint\source\repos\AppendDataFile.txt";

                int lineCount = File.ReadAllLines(path).Length;
                Console.WriteLine(lineCount);

            }
        }

        // 7
        class ThrowException
        {
            public void Exception()
            {
                try
                {
                    Console.WriteLine("Enter Integer..");
                    double exception = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please Enter Correct Integeer");
                }
            }
        }

        // 8

        class Division
        {
            public void Divide()
            {
                try
                {
                    Console.WriteLine("Enter First Number ");
                    decimal firstNum = decimal.Parse(Console.ReadLine());
                    Console.WriteLine(" ");
                    Console.WriteLine("Enter Second Number ");
                    decimal secondNum = decimal.Parse(Console.ReadLine());

                    decimal result = (firstNum / secondNum);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(("Exception caught: {0}", ex.Message.ToString()));
                }


            }
        }

        // 10
        class NullException
        {
            public void ExceptionNull()
            {


                string input = null;

                try
                {
                    if (input == null)
                    {
                        throw new ArgumentNullException(nameof(input));
                    }

                    Console.WriteLine("The input is: " + input);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }




            }
        }

        // 11
        class EncryptDecrypt
        {
            public void Encrypt()
            {
                {
                    {
                        string fileName = @"C:\Users\chint\source\repos\EmailFile.txt";
                        string email = "user@example.com";
                        string key = "1234567890123456";
                        string iv = "abcdefghijklmnop";

                        // encrypt email address
                        byte[] keyBytes = Encoding.ASCII.GetBytes(key);
                        byte[] ivBytes = Encoding.ASCII.GetBytes(iv);
                        byte[] inputBytes = Encoding.ASCII.GetBytes(email);

                        using (Aes aes = Aes.Create())
                        {
                            aes.Key = keyBytes;
                            aes.IV = ivBytes;

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

                                cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                                cryptoStream.FlushFinalBlock();

                                byte[] cipherTextBytes = memoryStream.ToArray();
                                string cipherText = Convert.ToBase64String(cipherTextBytes);

                                // write encrypted email to file
                                File.WriteAllText(fileName, cipherText);

                                Console.WriteLine("Email address written to file: " + fileName);
                            }
                        }

                        // read encrypted email from file
                        string encryptedEmail = File.ReadAllText(fileName);

                        // decrypt email address
                        byte[] encryptedBytes = Convert.FromBase64String(encryptedEmail);

                        using (Aes aes = Aes.Create())
                        {
                            aes.Key = keyBytes;
                            aes.IV = ivBytes;

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

                                cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                                cryptoStream.FlushFinalBlock();

                                byte[] plainTextBytes = memoryStream.ToArray();
                                string plainText = Encoding.ASCII.GetString(plainTextBytes);

                                Console.WriteLine("Original email address: " + plainText);
                            }
                        }
                    }
                }
            }
        }
        //12

        /* class configuration

         {
             static void AppConfig()
             {
                 // Get the user password from the App.config file
                 string password = ConfigurationManager.AppSettings["UserPassword"];

                 // Encrypt the password using AES
                 byte[] key = Encoding.UTF8.GetBytes("mySecretKey12345");
                 byte[] iv = Encoding.UTF8.GetBytes("mySecretIV67890");
                 byte[] encrypted = EncryptStringToBytes_Aes(password, key, iv);

                 // Save the encrypted password to a file
                 File.WriteAllBytes("encrypted_password.bin", encrypted);

                 Console.WriteLine("Password encrypted and saved to file.");
             }

             static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
             {
                 // Check arguments
                 if (string.IsNullOrEmpty(plainText))
                     throw new ArgumentNullException(nameof(plainText));
                 if (key == null || key.Length <= 0)
                     throw new ArgumentNullException(nameof(key));
                 if (iv == null || iv.Length <= 0)
                     throw new ArgumentNullException(nameof(iv));

                 byte[] encrypted;

                 using (Aes aesAlg = Aes.Create())
                 {
                     aesAlg.Key = key;
                     aesAlg.IV = iv;

                     // Create an encryptor to perform the stream transform
                     ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                     // Create the streams used for encryption
                     using (MemoryStream msEncrypt = new MemoryStream())
                     {
                         using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                         {
                             using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                             {
                                 // Write all data to the stream
                                 swEncrypt.Write(plainText);
                             }
                             encrypted = msEncrypt.ToArray();
                         }
                     }
                 }

                 return encrypted;
             }
         }*/
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Choose options 1 - 12");
        Console.WriteLine("1 --> Create a file and add some text.");
        Console.WriteLine("2 --> Create a file, add some text and Read it");
        Console.WriteLine("3 --> Create a file and write an array of strings to the file");
        Console.WriteLine("4 --> Append some text to an existing file.");
        Console.WriteLine("5 --> To read the first line from a file..");
        Console.WriteLine("6 --> To count the number of lines in a file.");
        Console.WriteLine("7 --> Throw a Simple Exception and handle it.");
        Console.WriteLine("8 --> Division by two no. and handle DivideByZeroException.");
        Console.WriteLine("9 --> Create one extension method called DateFormate() which returns today's date.");
        Console.WriteLine("10--> Throw ArgumentNullException and handle it.");
        Console.WriteLine("11--> Create one File and store User Email Address in encrypted format and read it.");
        Console.WriteLine("12--> Write a program to retrieve the user password from the Configuration file and encrypt it and store it in file");




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
                        Console.WriteLine(" ");
                        Console.WriteLine("1. Create a file and add some text");
                        CreateFile createFile = new CreateFile();
                        createFile.FileCreated();
                        Console.WriteLine("File is Created");
                        break;
                    case "2":
                        Console.WriteLine(" ");
                        Console.WriteLine("2. Create a file, add some text and Read it");
                        Console.WriteLine(" ");
                        ReadFile readFile = new ReadFile();
                        readFile.FileReading();
                        break;

                    case "3":
                        Console.WriteLine(" ");
                        Console.WriteLine("3. Create a file and write an array of strings to the file");
                        Console.WriteLine(" ");
                        CreateArrayfile createArrayfile = new CreateArrayfile();
                        createArrayfile.ArrayfileRead();
                        break;

                    case "4":
                        Console.WriteLine(" ");
                        Console.WriteLine("4. append some text to an existing file.");
                        Console.WriteLine(" ");
                        AppendData appendData = new AppendData();
                        appendData.FileAppendData();
                        break;
                    case "5":
                        Console.WriteLine(" ");
                        Console.WriteLine("5.  to read the first line from a file.");
                        Console.WriteLine(" ");
                        ReadFirstLine readFirstLine = new ReadFirstLine();
                        readFirstLine.ArrayRead();
                        break;
                    case "6":
                        Console.WriteLine(" ");
                        Console.WriteLine("6.   to count the number of lines in a file.");
                        Console.WriteLine(" ");
                        CountLines countLines = new CountLines();
                        countLines.FileCountLines();
                        break;
                    case "7":
                        Console.WriteLine(" ");
                        Console.WriteLine("7.   Throw a Simple Exception and handle it.");
                        Console.WriteLine(" ");
                        ThrowException throwException = new ThrowException();
                        throwException.Exception();
                        break;
                    case "8":
                        Console.WriteLine(" ");
                        Console.WriteLine("8.   Division by two no. and handle DivideByZeroException.");
                        Console.WriteLine(" ");
                        Division division = new Division();
                        division.Divide();
                        break;
                    case "9":
                        Console.WriteLine(" ");
                        Console.WriteLine("9.   Create one extension method called DateFormate() which returns today's date.");
                        Console.WriteLine("");
                        DateTime today = DateTime.Today;

                        Console.WriteLine("Enter Your format");
                        string dateF = Console.ReadLine();
                        try
                        {
                            // string formattedDate = today.ToString($"{dateF}", System.Globalization.CultureInfo.InvariantCulture);
                            string formattedDate = today.DateFormate($"{dateF}");
                            Console.WriteLine(formattedDate);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                        break;
                    case "10":
                        Console.WriteLine(" ");
                        Console.WriteLine("10.   Throw ArgumentNullException and handle it.");
                        Console.WriteLine("");
                        NullException nullException = new NullException();
                        nullException.ExceptionNull();
                        break;
                    case "11":
                        Console.WriteLine(" ");
                        Console.WriteLine("11.   Create one File and store User Email Address in encrypted format and read it.");
                        Console.WriteLine("");
                        EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
                        encryptDecrypt.Encrypt();
                        break;
                    case "12":
                        Console.WriteLine(" ");
                        Console.WriteLine("12.   Write a program to retrieve the user password from the Configuration file and encrypt it and store it in file\".");
                        Console.WriteLine("");
                        break;
                    case "13":
                        return;
                    default:
                        Console.WriteLine("Enter options between 1-12");
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






