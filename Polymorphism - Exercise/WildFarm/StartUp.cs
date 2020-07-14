using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();
            List<Food> foods = new List<Food>();

            int lineNum = 0;
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                Animal animal = null;
                Food food = null;
                if (lineNum % 2 == 0)
                {
                    string[] animalArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    lineNum++;

                    string type = animalArgs[0];
                    string name = animalArgs[1];
                    double weight = double.Parse(animalArgs[2]);
                    switch (type)
                    {
                        // {LivingRegion} {Breed}
                        case "Cat":
                            string livingRegion = animalArgs[3];
                            string breed = animalArgs[4];

                            animal = new Cat(name, weight, livingRegion, breed);
                            break;
                        case "Tiger":
                            livingRegion = animalArgs[3];
                            breed = animalArgs[4];

                            animal = new Tiger(name, weight, livingRegion, breed);
                            break;
                        case "Owl":
                            double wingSize = double.Parse(animalArgs[3]);

                            animal = new Owl(name, weight, wingSize);
                            break;
                        case "Hen":
                            wingSize = double.Parse(animalArgs[3]);

                            animal = new Hen(name, weight, wingSize);
                            break;
                        case "Mouse":
                            livingRegion = animalArgs[3];

                            animal = new Mouse(name, weight, livingRegion);
                            break;
                        case "Dog":
                            livingRegion = animalArgs[3];

                            animal = new Dog(name, weight, livingRegion);
                            break;
                    }

                    animals.Add(animal);
                }
                else
                {
                    string[] foodArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    lineNum++;

                    string foodType = foodArgs[0];
                    int quantity = int.Parse(foodArgs[1]);
                    switch (foodType)
                    {
                        case "Vegetable":
                            food = new Vegetable(quantity);
                            break;
                        case "Fruit":
                            food = new Fruit(quantity);
                            break;
                        case "Meat":
                            food = new Meat(quantity);
                            break;
                        case "Seeds":
                            food = new Seeds(quantity);
                            break;
                    }

                    foods.Add(food);
                }
            }

            for (int i = 0; i < animals.Count; i++)
            {
                try
                {
                    Console.WriteLine(animals[i].AskForFood());
                    animals[i].Eat(foods[i]);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            animals.ForEach(Console.WriteLine);
        }
    }
}