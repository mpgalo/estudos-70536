using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Globalization;
using System.Collections;

namespace LookupCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDictionary list = new ListDictionary(new CaseInsensitiveComparer(CultureInfo.InvariantCulture));
            

            list["Estados Unidos"] = "United States of America";
            list["Canadá"] = "Canada";
            list["España"] = "Spain";
            // Show the results
            Console.WriteLine(list["españa"]);
            Console.WriteLine(list["CANADÁ"]);
            Console.Read();
        }
    }
}
