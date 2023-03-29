using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Weekday
    {
        public int Week()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter the week number");

            int day = int.Parse(Console.ReadLine());
            try
            {

                switch (day)
                {
                    case 1:
                        Console.WriteLine("Monday");
                        break;
                    case 2:
                        Console.WriteLine("Tuesday");
                        break;
                    case 3:
                        Console.WriteLine("Wednesday");
                        break;
                    case 4:
                        Console.WriteLine("Thursday");
                        break;
                    case 5:
                        Console.WriteLine("Friday");
                        break;
                    case 6:
                        Console.WriteLine("Saturday");
                        break;
                    case 7:
                        Console.WriteLine("Sunday");
                        break;

                    default:
                        Console.WriteLine("Week only have Seven days");
                        break;
                }
                return day;
            }
            catch (Exception ex)
            {
                Console.WriteLine("This is not Allowed");
                return day;

            }

        }
    }

    class CheckMinMax
    {
        public double MinMax()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Maximum and Minimum");
            Console.WriteLine("Enter 1st Number");
            double num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter 2st Number");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("What Do You Want Min or Max");
            string minOrMax = Console.ReadLine();

            double output = 0;

            try
            {

                if (minOrMax.ToLower() == "min" || minOrMax.ToLower() == "minimum")
                {
                    output = Math.Min(num1, num2);
                }
                else if (minOrMax.ToLower() == "max" || minOrMax.ToLower() == "maximum")
                {
                    output = Math.Max(num1, num2);

                }
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter the valid integer");
                return output;
            }
        }
    }

    class Temprature
    {
        public string Temp()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Enter the Temprature ");
            double temp = double.Parse(Console.ReadLine());
            string tempOutput = "";


            try
            {

                if (temp < 0)
                {
                    tempOutput = "Freezing weather";
                }
                else if (temp <= 10)
                {
                    tempOutput = "Very Cold weather";
                }
                else if (temp <= 20)
                {
                    tempOutput = "Cold weather";
                }
                else if (temp <= 30)
                {
                    tempOutput = "Normal Weather";
                }
                else if (temp <= 40)
                {
                    tempOutput = "Its  Hot";
                }
                else
                {
                    tempOutput = "Its Very Hot";
                }

                return tempOutput;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Valid Integer");
                return tempOutput;
            }
        }
    }

    class Calculator
    {
        public void Calculate()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Use Calculator");
            Console.WriteLine("Enter First Number");
            double firstNum = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second Number");

            double SecondNum = double.Parse(Console.ReadLine());

            Console.WriteLine("What do you want to do Addition, Substraction, Multiplication, Modulus");
            Console.WriteLine("Enter operator (+, -, *, %):");
            char op = char.Parse(Console.ReadLine());

            double result = 0.0;

            try
            {
                switch (op)
                {
                    case '+':
                        result = firstNum + SecondNum;
                        break;
                    case '-':
                        result = firstNum - SecondNum;
                        break;
                    case '*':
                        result = firstNum * SecondNum;
                        break;
                    case '%':
                        result = firstNum % SecondNum;
                        break;

                }
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter correct character");
            }
        }
    }



    class CheckNumber
    {
        public string PositiveNegative()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Check Whether the number is Positive, negative or Zero");
            Console.WriteLine("Enter a number here");
            string input = Convert.ToString(Console.ReadLine());
            double number;
            string output = "";

            try
            {
                if (double.TryParse(input, out number))
                {
                    Console.WriteLine("You entered: {0}", number);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }

                if (number < 0)
                {
                    output = "Data is Negative";
                }
                else if (number > 0)
                {
                    output = "Data is Positive";
                }
                else
                {
                    output = "Data is Zero";
                }

                // Console.WriteLine(output);
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter the Valid Integer");
                return output;
            }

        }
    }

    // MAIN
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Check whether a number is positive, negative or zero");
                Console.WriteLine("2. Find the weekday for a given week number");
                Console.WriteLine("3. Find the minimum or maximum of two numbers");
                Console.WriteLine("4. Check the temperature range");
                Console.WriteLine("5. Use a calculator");
                Console.WriteLine("6. Exit");
                Console.WriteLine();

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CheckNumber checkNumber = new CheckNumber();
                        Console.WriteLine(checkNumber.PositiveNegative());
                        break;

                    case "2":
                        Weekday weekday = new Weekday();
                        weekday.Week();
                        break;

                    case "3":
                        CheckMinMax checkMinMax = new CheckMinMax();
                        Console.WriteLine(checkMinMax.MinMax());
                        break;

                    case "4":
                        Temprature temprature = new Temprature();
                        Console.WriteLine(temprature.Temp());
                        break;

                    case "5":
                        Calculator calculator = new Calculator();
                        calculator.Calculate();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
