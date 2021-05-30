using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace StringCollectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            StringCollection coll = new StringCollection();
            coll.Add("First");
            coll.Add("Second");
            coll.Add("Third");
            coll.Add("Fourth");
            coll.Add("fourth");
            

            foreach (string col in coll)
            {
                Console.WriteLine(col);
            }

            
        }
    }
}
