namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption, IncreasedConsumption, tankCapacity)
        {
            
        }

        public override void Refuel(double amount)
            => base.Refuel(amount * 0.95);
    }
}
