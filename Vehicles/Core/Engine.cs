using System;
using System.Collections;
using System.Collections.Generic;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;
        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>(); 
        }
        public void Run()
        {
            vehicles.Add(CreateVehicle()); //car
            vehicles.Add(CreateVehicle()); //truck
        }

        private IVehicle CreateVehicle()
        {
            string[] tokens = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // tokens[] = type,fuelQuantity,fuelConsumption

            return vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]));

        }
    }
}
