using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vehicles.IO
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string str)
        {
            using StreamWriter writer = new StreamWriter
                ("C:\\Users\\User\\Desktop\\Softuni\\FileWriterTest\\test.txt", true);
            writer.WriteLine(str);
        }
    }
}
