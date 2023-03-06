using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;

        protected Vehicle(double fuelQuantity,
            double fuelConsumption, 
            double increasedConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.increasedConsumption = increasedConsumption;
        }


        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            //To be independent of the environment - Console,File,Stream or Web...
            double totalConsumption = FuelConsumption + increasedConsumption;

            if (FuelQuantity < FuelConsumption * distance)
            {
                //(Car/Truck needs refueling) how to know Car or Truck? !!this.GetType().Name!!
                throw new ArgumentException($"{this.GetType().Name} needs refueling");

            }

            return $"{this.GetType().Name} travelled {distance} km";

        }

        public void Refuel(double amount)
            => FuelQuantity += amount;

        public override string ToString()
            => $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}
