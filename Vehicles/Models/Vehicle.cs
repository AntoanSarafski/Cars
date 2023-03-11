using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity,
            double fuelConsumption, 
            double increasedConsumption,
            int tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            this.increasedConsumption = increasedConsumption;
        }


        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption { get; private set; }

        public int TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            //To be independent of the environment - Console,File,Stream or Web...
            double totalConsumption = FuelConsumption + increasedConsumption;

            if (FuelQuantity < totalConsumption * distance)
            {
                //(Car/Truck needs refueling) how to know Car or Truck? !!this.GetType().Name!!
                throw new ArgumentException($"{this.GetType().Name} needs refueling");

            }


            FuelQuantity -= totalConsumption * distance;

            return $"{this.GetType().Name} travelled {distance} km";

        }

        public virtual void Refuel(double amount)
        {
            if (amount + FuelQuantity > TankCapacity)
            {
                // TODO Method CanRefuel() ? I don't wanna use Console.WriteLine, cuz i wanna have a good abstraction with IWriter.
            }
            FuelQuantity += amount;
        }

        public override string ToString()
            => $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}
