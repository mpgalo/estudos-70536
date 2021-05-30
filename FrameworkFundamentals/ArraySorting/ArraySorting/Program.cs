using System;
using System.Collections.Generic;
using System.Text;

namespace ArraySorting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and initialize an array.
            int[] ar = { 3, 1, 2 };
            // Call a shared/static array method.
            Array.Sort(ar);
            // Display the result.
            Console.WriteLine("{0}, {1}, {2}", ar[0], ar[1], ar[2]);

            string[] strAr = { "Zenaide", "Alex", "Tiago", "George","Marcus" };
            Array.Sort(strAr);
            Console.WriteLine("{0},{1},{2},{3},{4}", strAr[0], strAr[1], strAr[2], strAr[3], strAr[4]);

            Array.Reverse(strAr);
            Console.WriteLine("{0},{1},{2},{3},{4}", strAr[0], strAr[1], strAr[2], strAr[3], strAr[4]);

            Console.WriteLine(Array.IndexOf(strAr, "George"));

            
            


        }
    }
}
