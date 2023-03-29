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

            double output;

            if (minOrMax.ToLower() == "min" || minOrMax.ToLower() == "minimum")
            {
                output = Math.Min(num1, num2);
            }
            else 
            {
                output = Math.Max(num1, num2);

            }
            return output;
        }
    }

    class Temprature
    {
        public string Temp()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter the Temprature ");
            int temp = int.Parse(Console.ReadLine());
            string tempOutput = "";

            if (temp < 0)
            {
                tempOutput = "Freezing weather";
            }
            else if (temp >= 0 && temp <= 10)
            {
                tempOutput = "Very Cold weather";
            }
            else if (temp > 10 && temp <= 20)
            {
                tempOutput = "Cold weather";
            }
            else if (temp > 20 && temp <= 30)
            {
                tempOutput = "Normal Weather";
            }
            else if (temp > 30 && temp <= 40)
            {
                tempOutput = "Its  Hot";
            }
            else if (temp >= 40)
            {
                tempOutput = "Its Very Hot";
            }

            return tempOutput;
        }
    }

    class Calculator
    {
        public void Calculate()
        {
            Console.WriteLine("Use Calculator");
            Console.WriteLine("Enter First Number");
            int firstNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second Number");

            int SecondNum = int.Parse(Console.ReadLine());

            Console.WriteLine("What do you want to do Addition, Substraction, Multiplication, Modulus");
            Console.WriteLine("Enter operator (+, -, *, %):");
            char op = char.Parse(Console.ReadLine());

            double result = 0.0;


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
    }





    // MAIN
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check Whether the number is Positive, negative or Zero");
            Console.WriteLine("Enter a number here");
            string input =Convert.ToString( Console.ReadLine());
            double number;

            if (double.TryParse(input, out number))
            {
                Console.WriteLine("You entered: {0}", number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }

            string output;
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

            Console.WriteLine(output);




            // For Weekday Finding
            Weekday weekday = new Weekday();
            weekday.Week();

            // For MinMax Finding

            CheckMinMax checkMinMax = new CheckMinMax();
            Console.WriteLine(checkMinMax.MinMax());

            // For Temprature Finding
            Temprature temprature = new Temprature();
            Console.WriteLine(temprature.Temp());

            // For calculator Finding
            Calculator calculator = new Calculator();
            calculator.Calculate();
        }
    }
}
