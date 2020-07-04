namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(double horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;

            this.DefaultFuelConsumption = 1.25;
            this.FuelConsumption = this.DefaultFuelConsumption;
        }

        public double HorsePower { get; private set; }
        public double Fuel { get; private set; }

        public double DefaultFuelConsumption { get; protected set; }
        public virtual double FuelConsumption { get; private set; }
        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
