using System;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main()
        {
            //var whiteChewy = new Dough("White", "Chewy", 100);
            //Console.WriteLine(whiteChewy.WeightGR);
            //Console.WriteLine(whiteChewy.CaloriesPerGR);

            // *************
            //var Tip500Chewy = new Dough("Tip500", "Chewy", 100);
            //Console.WriteLine(Tip500Chewy.WeightGR);
            //Console.WriteLine(Tip500Chewy.CaloriesPerGR);   

            // *************
            //var whiteHard = new Dough("White", "Hard", 100);
            //Console.WriteLine(whiteHard.WeightGR);
            //Console.WriteLine(whiteHard.CaloriesPerGR);

            // *************
            //var whiteChewy1 = new Dough("White", "Chewy", 1000);
            //Console.WriteLine(whiteChewy1.WeightGR);
            //Console.WriteLine(whiteChewy1.CaloriesPerGR);

            // *************
            //var krenvirshi = new Topping("Krenvirshi", 50);
            //Console.WriteLine(krenvirshi.WeightGR);
            //Console.WriteLine(krenvirshi.CaloriesPerGR);

            // *************
            //var meat = new Topping("meat", 500);
            //Console.WriteLine(meat.WeightGR);
            //Console.WriteLine(meat.CaloriesPerGR);

            // *************
            //var topping = new Topping("meat", 30);
            //Console.WriteLine(topping.WeightGR);
            //Console.WriteLine(topping.CaloriesPerGR);

            // *************
            //var topping1 = new Topping("Meat", 30);
            //Console.WriteLine(topping.WeightGR);
            //Console.WriteLine(topping.CaloriesPerGR);

            // *************
            //var pizzaMargarita = new Pizza("Margarita", whiteChewy);
            //Console.WriteLine(pizzaMargarita.Name);
            //Console.WriteLine(pizzaMargarita.TotalCalories);

            // *************
            //var pizza1 = new Pizza(string.Empty, whiteChewy);
            //Console.WriteLine(pizza1.Name);
            //Console.WriteLine(pizza1.TotalCalories);

            // *************
            //var pizza2 = new Pizza("VeryLongPizzaName", whiteChewy);
            //Console.WriteLine(pizza2.Name);
            //Console.WriteLine(pizza2.TotalCalories);

            // *************
            //var pizza3 = new Pizza("Polo", whiteChewy);
            //pizza3.AddTopping(topping);
            //Console.WriteLine(pizza3.Name);
            //Console.WriteLine(pizza3.TotalCalories);

            // *************
            //var pizza4 = new Pizza("Polo", whiteChewy);
            //Console.WriteLine(pizza4.Toppings.Count);
            //for (int i = 0; i < 10 /*11*/; i++)
            //{
            //    pizza4.AddTopping(topping);
            //}
            //Console.WriteLine(pizza4.Toppings.Count);
            //Console.WriteLine(pizza4.Name);
            //Console.WriteLine(pizza4.TotalCalories);

            // *************
            try
            {
                string pizzaName = Console.ReadLine().Split(' ')[1];

                string[] doughArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Dough pizzaDough = new Dough(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3]));

                var pizza = new Pizza(pizzaName, pizzaDough);
                while (true)
                {
                    string cmd = Console.ReadLine();
                    if (cmd == "END")
                    {
                        Console.WriteLine(pizza);
                        break;
                    }

                    string[] toppingArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Topping someTopping = new Topping(toppingArgs[1], double.Parse(toppingArgs[2]));
                    pizza.AddTopping(someTopping);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}