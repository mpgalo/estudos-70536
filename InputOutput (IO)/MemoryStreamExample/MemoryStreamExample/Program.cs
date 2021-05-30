using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MemoryStreamExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStream memStrm = new MemoryStream();
            StreamWriter writer = new StreamWriter(memStrm);
            writer.WriteLine("Hello");
            writer.WriteLine("Goodbye");
            // Force the writer to push the data into the
            // underlying stream
            writer.Flush();
            // Create a file stream
            FileStream theFile = File.Create(@"c:\inmemory.txt");
            // Write the entire Memory stream to the file
            memStrm.WriteTo(theFile);
            // Clean up
            writer.Close();
            theFile.Close();
            memStrm.Close();
        }
    }
}
