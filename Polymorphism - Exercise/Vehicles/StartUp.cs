using System;
using System.Collections.Generic;

namespace VehiclesExtension
{
    public class StartUp
    {
        public static void Main()
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            List<Vehicle> vehicles = new List<Vehicle>() { car, truck };
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                bool canDrive;
                double distance = double.Parse(cmdArgs[2]);
                switch (cmdArgs[0])
                {
                    case "Drive":
                        switch (cmdArgs[1])
                        {
                            case "Car":
                                canDrive = vehicles[0].Drive(distance);
                                if (canDrive)
                                {
                                    Console.WriteLine($"{vehicles[0].GetType().Name} travelled {distance} km");
                                }
                                else
                                {
                                    Console.WriteLine($"{vehicles[0].GetType().Name} needs refueling");
                                }

                                break;
                            case "Truck":
                                canDrive = vehicles[1].Drive(distance);
                                if (canDrive)
                                {
                                    Console.WriteLine($"{vehicles[1].GetType().Name} travelled {distance} km");
                                }
                                else
                                {
                                    Console.WriteLine($"{vehicles[1].GetType().Name} needs refueling");
                                }

                                break;
                        }

                        break;
                    case "Refuel":
                        switch (cmdArgs[1])
                        {
                            case "Car":
                                vehicles[0].Refuel(double.Parse(cmdArgs[2]));
                                break;
                            case "Truck":
                                vehicles[1].Refuel(double.Parse(cmdArgs[2]));
                                break;
                        }

                        break;
                }
            }

            Console.WriteLine($"Car: {vehicles[0].FuelQuantity:F2}");
            Console.WriteLine($"Truck: {vehicles[1].FuelQuantity:F2}");
        }
    }
}