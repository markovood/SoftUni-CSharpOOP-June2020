namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double AIRCON_FUEL = 1.6;
        private const double FUEL_TO_KEEP = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) : 
            base(fuelQuantity, fuelConsumption + AIRCON_FUEL)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * FUEL_TO_KEEP);
        }
    }
}