﻿namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double IncreasedConsumption = 0.9;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, IncreasedConsumption, tankCapacity)
        {
        }

        
    }
}