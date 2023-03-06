namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, 
            double fuelConsumption, 
            double increasedConsumption) 
            : base(fuelQuantity, fuelConsumption, increasedConsumption)
        {
        }
    }
}
