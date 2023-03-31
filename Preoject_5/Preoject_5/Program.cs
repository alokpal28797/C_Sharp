using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Preoject_5
{
    public class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public City CityInfo { get; set; }

            public Person()
            {
                CityInfo = new City();
            }

  
            public class City
            {
                public string CityName { get; set; }

                public int Population { get; set; }
            }

            public override string ToString()
            {
                return $"Name: {Name}, Age: {Age}, City: {CityInfo.CityName}, Population: {CityInfo.Population} ";
            }
        }

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("1 ---> JsonConvert object's serializer to save the data in a .json file an Deserialize them");
                    Console.WriteLine("2 ---> XML Conversion");
                    Console.WriteLine();
                    Console.WriteLine("Choose Options ");

                    string options = Console.ReadLine();

                    switch (options)
                    {
                        case "1":
                            Console.WriteLine("JsonConvert object's serializer to save the data in a .json file an Deserialize them");
                            Console.WriteLine(" ");
                            Person person = new Person();
                            Console.WriteLine("Enter Your Name");

                            string inputName = Console.ReadLine();

                            char[] ch = inputName.ToCharArray();

                            foreach (char c in ch)
                            {
                                if (!char.IsDigit(c))
                                {
                                    person.Name = inputName;
                                }
                                else
                                {
                                    Console.WriteLine("Please Enter the Correct Value");
                                    break;
                                }
                            }

                            Console.WriteLine("Enter Your Age");
                            person.Age = int.Parse(Console.ReadLine());

                            //Person.City city = new Person.City();
                            Console.WriteLine("Enter Your City Name ");
                            person.CityInfo.CityName = Console.ReadLine();
                            Console.WriteLine("Enter the population of the City");
                            person.CityInfo.Population = int.Parse(Console.ReadLine());

                           // person.CityInfo = city; // set the City object in the Person object



                            // serialize JSON to a string and then write string to a file
                            File.WriteAllText(@"C:\Users\chint\source\repos\Jake.json", JsonConvert.SerializeObject(person));

                            // serialize JSON directly to a file
                            using (StreamWriter file = File.AppendText(@"C:\Users\chint\source\repos\Jake.json"))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(file, person);
                                Console.WriteLine("File is Serialized");

                            }
                            
                            Console.WriteLine(person.ToString());

                            // read file into a string and deserialize JSON to a type
                            Person person1 = JsonConvert.DeserializeObject<Person>(File.ReadAllText(@"C:\Users\chint\source\repos\Jake.json"));

                            // deserialize JSON directly from a file
                            using (StreamReader file = File.OpenText(@"C:\Users\chint\source\repos\Jake.json"))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                Person person3 = (Person)serializer.Deserialize(file, typeof(Person));
                                Console.WriteLine(person3.Name);
                                Console.WriteLine(person3.Age);
                                Console.WriteLine(person3.CityInfo.CityName);
                                Console.WriteLine(person3.CityInfo.Population);

                            }
                            Console.WriteLine();

                            break;

                        case "2":
                            Console.WriteLine(" ");
                            Person person2 = new Person();
                            Console.WriteLine("Enter Your Name");

                            string inputName1 = Console.ReadLine();

                            char[] ch1 = inputName1.ToCharArray();

                            foreach (char c in ch1)
                            {
                                if (!char.IsDigit(c))
                                {
                                    person2.Name = inputName1;
                                }
                                else
                                {
                                    Console.WriteLine("Please Enter the Correct Value");
                                    break;
                                }
                            }

                            Console.WriteLine("Enter Your Age");
                            person2.Age = int.Parse(Console.ReadLine());

                            Person.City city1 = new Person.City();
                            Console.WriteLine("Enter Your City Name ");
                            city1.CityName = Console.ReadLine();
                            Console.WriteLine("Enter the population of the City");
                            city1.Population = int.Parse(Console.ReadLine());

                            person2.CityInfo = city1; // set the City object in the Person object



                            // create a new XmlSerializer instance
                            var serializer1 = new XmlSerializer(typeof(Person));

                            // serialize the person object to XML
                            using (var stream = new StreamWriter(@"C:\Users\chint\source\repos\JakeXML.xml"))
                            {
                                serializer1.Serialize(stream, person2);
                                Console.WriteLine("XML Searialized is done");
                            }

                            Console.WriteLine(person2.ToString());

                            // create a new XmlSerializer instance
                            var serializer4 = new XmlSerializer(typeof(Person));

                            // deserialize the XML file back into a Person object
                            using (var stream = new StreamReader(@"C:\Users\chint\source\repos\JakeXML.xml"))
                            {
                                var person4 = (Person)serializer4.Deserialize(stream);
                                
                                // do something with the deserialized person object
                            }
                            Console.WriteLine();

                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Enter Options between 1-2");
                            break;

                    }






                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
    }
}
