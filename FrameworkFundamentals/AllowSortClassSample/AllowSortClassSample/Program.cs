using System;
using System.Collections;
using System.Text;

namespace AllowSortClassSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayString = { "UVA","AMORA", "MORANGO", "MAÇA", "AMEIXA", "PERA" };
            Array.Sort(arrayString, new DecendingComparer());

            foreach (string item in arrayString)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class DecendingComparer:IComparer
    {       

        int IComparer.Compare(object x, object y)
        {
            return String.Compare(y.ToString(), x.ToString());
        }
        
    }
}
