using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDictionarySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            
            dict[3] = "Three";
            dict[4] = "Four";
            dict[1] = "One";
            dict[2] = "Two";
            

            foreach (KeyValuePair<int, string> i in dict)
            {
                Console.WriteLine("{0} = {1}", i.Key, i.Value);
            }
        }
    }
}
