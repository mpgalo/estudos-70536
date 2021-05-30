using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace CollectionUtilSample
{
    class Program
    {
        static void Main(string[] args)
        {            
            Hashtable inTable = CollectionsUtil.CreateCaseInsensitiveHashtable();
            inTable["hello"] = "Hi";
            inTable["HELLO"] = "Heya";
            Console.WriteLine(inTable.Count); // 1
            SortedList inList = CollectionsUtil.CreateCaseInsensitiveSortedList();
            inList["hello"] = "Hi";
            inList["HELLO"] = "Heya";
            Console.WriteLine(inList.Count); // 1
            
            Hashtable hash = new Hashtable(StringComparer.InvariantCulture);
            SortedList list = new SortedList(StringComparer.InvariantCulture);
        }
    }
}
