using System;

namespace Vehicles.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str)
            => Console.WriteLine(str);
    }
}
