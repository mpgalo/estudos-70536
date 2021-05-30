using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DriveInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Drive: {0}", drive.Name);
                Console.WriteLine("Type: {0}", drive.DriveType);
                
               
            }
        }
    }
}
