using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Throw_and_Catch_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader sr = new StreamReader(@"C:\boote.ini");
                try
                {
                    Console.WriteLine(sr.ReadToEnd());
                }               
                catch (Exception ex)
                {
                    // If there are any problems reading the file, display an error message
                    Console.WriteLine("Error reading file: " + ex.Message);
                }
                finally
                {
                    // Close the StreamReader, whether or not an exception occurred
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file could not be found.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have sufficient permissions.");
            }
            
            
        }
    }
}
