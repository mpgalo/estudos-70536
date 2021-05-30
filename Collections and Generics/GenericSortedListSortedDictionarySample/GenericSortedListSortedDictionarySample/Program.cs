using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSortedListSortedDictionarySample
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, int> sortList = new SortedList<string, int>();
            sortList["Two"] = 2;
            sortList["Three"] = 3;
            sortList["One"] = 1;

            foreach (KeyValuePair<string, int> i in sortList)
            {
                Console.WriteLine(i);
            }

            
            SortedDictionary<string, int> sortedDict = new SortedDictionary<string, int>();
            sortedDict["One"] = 1;
            sortedDict["Two"] = 2;
            sortedDict["Three"] = 3;
            
            foreach (KeyValuePair<string, int> i in sortedDict)
            {
                Console.WriteLine(i);
            }
        }
    }
}
