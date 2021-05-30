using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Collections;

namespace StringDictionarySample
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDictionary dict = new StringDictionary();
                        
            dict["First"] = "1st";
            dict["Second"] = "2nd";
            dict["Third"] = "3rd";
            dict["Fourth"] = "4th";
            dict["fourth"] = "fourth";
            // dict[50] = "fifty"; <-Won’t compile...not a string
            string converted = dict["Second"];
            // No casting needed

            foreach (DictionaryEntry item in dict)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            Console.WriteLine(converted);

            
            Hashtable dicitionary = new Hashtable();
        }
    }
}
