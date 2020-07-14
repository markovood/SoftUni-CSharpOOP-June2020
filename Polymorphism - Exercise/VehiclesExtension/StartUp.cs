using System;
using System.Collections.Generic;
using System.Linq;

namespace VehiclesExtension
{
    public class StartUp
    {
        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            for (int i = 0; i < 3; i++)
            {
                string[] vehicleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                double fuelQuantity = double.Parse(vehicleInfo[1]);
                double fuelConsumption = double.Parse(vehicleInfo[2]);
                double tankCapacity = double.Parse(vehicleInfo[3]);
                switch (vehicleInfo[0])
                {
                    case "Car":
                        vehicles.Add(new Car(fuelQuantity, fuelConsumption, tankCapacity));
                        break;
                    case "Truck":
                        vehicles.Add(new Truck(fuelQuantity, fuelConsumption, tankCapacity));
                        break;
                    case "Bus":
                        vehicles.Add(new Bus(fuelQuantity, fuelConsumption, tankCapacity));
                        break;
                }
            }

            double N = double.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                bool success;
                switch (cmdArgs[0])
                {
                    case "Drive":
                        double distance = double.Parse(cmdArgs[2]);
                        switch (cmdArgs[1])
                        {
                            case "Car":
                                success = vehicles.FirstOrDefault(v => v.GetType().Name == "Car").Drive(distance);
                                if (success)
                                {
                                    Console.WriteLine($"Car travelled {distance} km");
                                }
                                else
                                {
                                    Console.WriteLine("Car needs refueling");
                                }

                                break;
                            case "Truck":
                                success = vehicles.FirstOrDefault(v => v.GetType().Name == "Truck").Drive(distance);
                                if (success)
                                {
                                    Console.WriteLine($"Truck travelled {distance} km");
                                }
                                else
                                {
                                    Console.WriteLine("Truck needs refueling");
                                }

                                break;
                            case "Bus":
                                success = vehicles.FirstOrDefault(v => v.GetType().Name == "Bus").Drive(distance);
                                if (success)
                                {
                                    Console.WriteLine($"Bus travelled {distance} km");
                                }
                                else
                                {
                                    Console.WriteLine("Bus needs refueling");
                                }

                                break;
                        }

                        break;
                    case "DriveEmpty":
                        distance = double.Parse(cmdArgs[2]);
                        success = (vehicles.FirstOrDefault(v => v.GetType().Name == "Bus") as Bus).DriveEmpty(distance);
                        if (success)
                        {
                            Console.WriteLine($"Bus travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }

                        break;
                    case "Refuel":
                        try
                        {
                            double liters = double.Parse(cmdArgs[2]);
                            switch (cmdArgs[1])
                            {
                                case "Car":
                                    if (!vehicles.FirstOrDefault(v => v.GetType().Name == "Car").Refuel(liters))
                                    {
                                        Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                                    }

                                    break;
                                case "Truck":
                                    if (!vehicles.FirstOrDefault(v => v.GetType().Name == "Truck").Refuel(liters))
                                    {
                                        Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                                    }

                                    break;
                                case "Bus":
                                    if (!vehicles.FirstOrDefault(v => v.GetType().Name == "Bus").Refuel(liters))
                                    {
                                        Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                                    }

                                    break;
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                }
            }

            vehicles.ForEach(v => Console.WriteLine($"{v.GetType().Name}: {v.FuelQuantity:F2}"));
        }
    }
}