using System;
using Vehicles.Core.Interfaces;
using Vehicles.IO;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new IEngine(reader, writer)
        }
    }
}
