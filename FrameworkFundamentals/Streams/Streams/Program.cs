using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            // C#
            // Create and write to a text file
            using (StreamWriter sw = new StreamWriter("text.txt"))
            {
                sw.WriteLine("Hello, World!");
                sw.WriteLine(sw.NewLine);
                sw.WriteLine("Hello, World!");
            }

            using (StreamReader sr = new StreamReader("text.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());
                sr.Close();
            }

        }
    }
}
