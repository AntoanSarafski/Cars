using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            throw new System.NotImplementedException();
        }

        public void Refuel(double liters)
        {
            throw new System.NotImplementedException();
        }
    }
}
