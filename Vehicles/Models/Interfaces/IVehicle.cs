namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        public int TankCapacity { get; }

        public string Drive(double distance);

        public void Refuel(double amount);
    }
}
