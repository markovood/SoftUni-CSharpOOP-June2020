﻿namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double AIRCON_FUEL = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) :
            base(fuelQuantity, fuelConsumption + AIRCON_FUEL, tankCapacity)
        {
        }
    }
}