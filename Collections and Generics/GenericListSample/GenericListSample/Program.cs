using System;
using System.Collections.Generic;
using System.Text;

namespace GenericListSample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>();
            intList.Add(3);
            intList.Add(1);
            intList.Add(2);

            //intList.Sort(); Ordena Normalmente
            intList.Sort(ReverseIntComparison);//Passa o metodo de Ordenação para o Delegate Comparison
            
            int number = intList[0];
            foreach (int i in intList)
            {
                Console.WriteLine(i);
            }
        }
        static int ReverseIntComparison(int x, int y)
        {
            return y-x;
        }
    }
}
