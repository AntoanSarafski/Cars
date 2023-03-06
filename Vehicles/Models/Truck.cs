namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity,
            double fuelConsumption,
            double increasedConsumption) 
            : base(fuelQuantity, fuelConsumption, increasedConsumption)
        {
        }
    }
}
