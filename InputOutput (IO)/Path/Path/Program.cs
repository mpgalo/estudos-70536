using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PathTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string ourPath = @"c:\teste.txt";
            Console.WriteLine(ourPath);
            Console.WriteLine("Ext: {0}", Path.GetExtension(ourPath));
            Console.WriteLine("Change Path: {0}",
            Path.ChangeExtension(ourPath, "bak"));
        }
    }
}
