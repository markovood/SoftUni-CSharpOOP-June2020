namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(double horsePower, double fuel) : 
            base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = this.FuelConsumption;
        }

        public override double FuelConsumption => 10.0;
    }
}
