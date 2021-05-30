using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EscreverEmAqruivo
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream theFile = File.Open(@"c:\somefile.txt", FileMode.OpenOrCreate);
            theFile.Position = theFile.Length;
            StreamWriter writer = new StreamWriter(theFile);
            writer.WriteLine("Marcus");
            writer.Close();
            theFile.Close();

            writer = File.CreateText(@"c:\teste.txt");
            writer.WriteLine("Marcus");
            writer.Close();

            File.WriteAllText(@"c:\teste2.txt", "Hello");

            theFile = null;
            theFile = File.OpenWrite(@"c:\teste3.txt");
            writer = new StreamWriter(theFile);
            writer.WriteLine("Marcus");
            writer.Close();
            theFile.Close();



        }
    }
}
