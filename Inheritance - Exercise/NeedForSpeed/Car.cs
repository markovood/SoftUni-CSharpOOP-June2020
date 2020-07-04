namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(double horsePower, double fuel) :
            base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = this.FuelConsumption;
        }

        public override double FuelConsumption => 3.0;
    }
}
