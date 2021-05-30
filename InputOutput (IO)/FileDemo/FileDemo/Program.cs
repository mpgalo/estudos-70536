using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = File.CreateText(@"c:\newfile.txt");
            writer.WriteLine("This is my new file");
            writer.WriteLine("Do you like its format?");
            writer.Close();

            StreamReader reader = File.OpenText(@"c:\newfile.txt");
            string content = reader.ReadToEnd();            
            reader.Close();
            Console.Write(content);
           
        }
    }
}
