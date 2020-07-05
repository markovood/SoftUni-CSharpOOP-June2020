using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                List<Person> persons = new List<Person>();
                GetAllPeople(persons);

                List<Product> products = new List<Product>();
                GetAllProducts(products);

                while (true)
                {
                    string cmd = Console.ReadLine();
                    if (cmd == "END")
                    {
                        break;
                    }

                    string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var person = persons.Find(p => p.Name == cmdArgs[0]);
                    var product = products.Find(pr => pr.Name == cmdArgs[1]);

                    if (person.Buy(product))
                    {
                        Console.WriteLine($"{person} bought {product}");
                    }
                    else
                    {
                        Console.WriteLine($"{person} can't afford {product}");
                    }
                }

                foreach (var person in persons)
                {
                    if (person.Bag.Count > 0)
                    {
                        string bagContents = string.Join(", ", person.Bag);
                        Console.WriteLine($"{person} - {bagContents}");
                    }
                    else
                    {
                        Console.WriteLine($"{person} - Nothing bought");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetAllProducts(List<Product> products)
        {
            string[] allProductsArgs = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allProductsArgs.Length; i += 2)
            {
                var product = new Product(allProductsArgs[i], decimal.Parse(allProductsArgs[i + 1]));
                products.Add(product);
            }
        }

        private static void GetAllPeople(List<Person> persons)
        {
            string[] allPeopleArgs = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allPeopleArgs.Length; i += 2)
            {
                var person = new Person(allPeopleArgs[i], decimal.Parse(allPeopleArgs[i + 1]));
                persons.Add(person);
            }
        }
    }
}