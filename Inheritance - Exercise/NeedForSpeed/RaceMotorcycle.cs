namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(double horsePower, double fuel) : 
            base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = this.FuelConsumption;
        }

        public override double FuelConsumption => 8.0;
    }
}
