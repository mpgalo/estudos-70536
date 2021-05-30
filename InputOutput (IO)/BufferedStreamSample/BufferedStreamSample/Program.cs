using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BufferedStreamSample
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream newFile = File.Create(@"c:\teste.txt");
            BufferedStream buffered = new BufferedStream(newFile);            
            StreamWriter writer = new StreamWriter(buffered);
            writer.WriteLine("Some data");
            writer.Close();
        }
    }
}
