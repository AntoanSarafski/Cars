using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            vehicles.Add(CreateVehicle()); //truck

            int commandsCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] tokens = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string type = tokens[0];
            double fuelQuantity = double.Parse(tokens[1]);
            double fuelConsumption = double.Parse(tokens[2]);
            int tankCapacity = int.Parse(tokens[3]);

            // tokens[] = type,fuelQuantity,fuelConsumption
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
                return vehicleFactory.Create(type, fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                return vehicleFactory.Create(type, fuelQuantity, fuelConsumption, tankCapacity);
            }

        }

        private void ProcessCommand()
        {
            string[] commandTokens = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = commandTokens[0];
            string vehicleType = commandTokens[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }
            else if (command == "Drive")
            {
                double distance = double.Parse(commandTokens[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double amount = double.Parse(commandTokens[2]);

                vehicle.Refuel(amount);
            }
        }
    }
}
