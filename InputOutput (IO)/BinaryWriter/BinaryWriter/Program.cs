using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BinaryWriterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream newFile = File.Create(@"c:\somefile.bin");
            BinaryWriter writer = new BinaryWriter(newFile);
            long number = 100;
            byte[] bytes = new byte[] { 10, 20, 50, 100 };
            string s = "hunger";
            writer.Write(number);
            writer.Write(bytes);
            writer.Write(s);
            writer.Close();           

            newFile = File.Open(@"c:\somefile.bin", FileMode.Open);
            BinaryReader reader = new BinaryReader(newFile);
            number = reader.ReadInt64();
            bytes = reader.ReadBytes(4);
            s = reader.ReadString();
            reader.Close();
            Console.WriteLine(number);
            foreach (byte b in bytes)
            {
                Console.Write("[{0}]", b);
            }
            Console.WriteLine();
            Console.WriteLine(s);
        }
    }
}
