using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileInformoation
{
    class Program
    {
        static void Main(string[] args)
        {            
            FileInfo ourFile = new FileInfo(@"c:\teste.txt ");
            if (ourFile.Exists)
            {
                Console.WriteLine("Filename : {0}", ourFile.Name);
                Console.WriteLine("Path : {0}", ourFile.FullName);
                ourFile.CopyTo(@"c:\testecopia.txt");
            }
            
        }
    }
}
