namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double AIRCON_FUEL = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) :
            base(fuelQuantity, fuelConsumption + AIRCON_FUEL, tankCapacity)
        {
        }

        public bool DriveEmpty(double distance)
        {
            this.FuelConsumption -= AIRCON_FUEL;
            bool success = this.Drive(distance);
            this.FuelConsumption += AIRCON_FUEL;
            return success;
        }
    }
}