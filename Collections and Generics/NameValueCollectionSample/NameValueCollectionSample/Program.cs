using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Collections;

namespace NameValueCollectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            NameValueCollection nv = new NameValueCollection();
            nv.Add("Key", "Some Text");
            nv.Add("Key", "More Text");
                     
            foreach (string s in nv.GetValues("Key"))
            {
                Console.WriteLine(s);
            }

            nv.Add("First", "1st");
            nv.Add("Second", "2nd");
            nv.Add("Second", "Not First");
            for (int x = 0; x < nv.Count; ++x)
            {
                Console.WriteLine(nv[x]);
            }
        }
    }
}
