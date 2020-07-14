namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double AIRCON_FUEL = 1.6;
        private const double FUEL_TO_KEEP = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) :
            base(fuelQuantity, fuelConsumption + AIRCON_FUEL, tankCapacity)
        {
        }

        public override bool Refuel(double liters)
        {
            return base.Refuel(liters * FUEL_TO_KEEP);
        }
    }
}