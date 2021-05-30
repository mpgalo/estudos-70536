using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DirectoryInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo ourDir = new DirectoryInfo(@"c:\windows");
            Console.WriteLine("Directory: {0}", ourDir.FullName);
            foreach (FileInfo file in ourDir.GetFiles())
            {
                Console.WriteLine("File: {0}", file.Name);
            }
        }
    }
}
