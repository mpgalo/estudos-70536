using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BasicCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            array.Add("First");
            array.Add("Second");
            array.Add("Third");
            array.Add("Fourth");

            foreach (object item in array)
            {
                Console.WriteLine(item);
            }

            array.Sort();

            foreach (object item in array)
            {
                Console.WriteLine(item);
            }

            //Atraves do GetRange recuperamos um novo arrayList nos indices especificados
            ArrayList array2 = array.GetRange(0, 3);
            foreach (object item in array2)
            {
                Console.WriteLine(item);
            }

            //Atraves do SetArrange altera determinados itens do arraylisy, com base em array ou classe q implemente ICollection
            string[] carro = new string[]{"Fiat","Palio","Uno"};           
            array2.SetRange(0,carro);
            foreach (object item in array2)
            {
                Console.WriteLine(item);
            }

            
        }
    }
}
