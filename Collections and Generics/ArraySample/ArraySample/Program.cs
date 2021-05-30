using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ArraySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Array meuArray = Array.CreateInstance(typeof(string), 4);
            //ou string[] meuArray = new string[4];

            //Altera os valor de acordo com o indice
            meuArray.SetValue("D", 0);
            meuArray.SetValue("B", 1);
            meuArray.SetValue("A", 2);
            meuArray.SetValue("C", 3);


            //Pega item em determino indice
            Console.WriteLine(meuArray.GetValue(0));

            //O numero de dimensoes do array
            Console.WriteLine(meuArray.Rank);

            //Numero de itens em determida dimensao
            Console.WriteLine(meuArray.GetLength(0));            

            Console.WriteLine();

            //Ordena os itens do array
            Array.Sort(meuArray);
            

            foreach (string item in meuArray)
            {
                Console.WriteLine(item);                
            }
            
        }
    }
}
