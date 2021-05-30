using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace SortedListSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ao usar o CaseInsensitiveComparer não irá deferenciar maiuscuas e minusculas na chave
            // se usasasse DescendingComparer seria ordenado ao contrarário
            SortedList sort = new SortedList(new CaseInsensitiveComparer());
            sort["First"] = "1";
            sort["Second"] = "2nd";
            sort["Third"] = "3rd";
            sort["Fourth"] = "4th";
            sort["fourth"] = "4th";

            //Pega o valor em determinado indice apos ordenação
            Console.WriteLine(sort.GetByIndex(3));
            //Pega a chave em determinado indice apos ordenação
            Console.WriteLine(sort.GetKey(3));

            //Remove item em indice especifico
            sort.RemoveAt(1);

            //Altera item em determinado indice especificado
            sort.SetByIndex(0, "1st");
            
            Console.WriteLine();

            //Capacidade de items atual
            Console.WriteLine(sort.Capacity);

            //A capacidade de items será igual ao numero de items adicionados
            sort.TrimToSize();
            Console.WriteLine(sort.Capacity);
            sort.Add("Fift", "5th");
            Console.WriteLine(sort.Capacity);

            //Quantidade de itens alocados na coleção
            Console.WriteLine(sort.Count);

            Console.WriteLine();

            //Pega as chaves existentes e joga num objeto do tipo IList
            IList array = sort.GetKeyList(); //GetValueList retorna um IList com base nos valores não nas cheves
            foreach (object item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            foreach (DictionaryEntry entry in sort)
            {
                Console.WriteLine("{0} = {1}, Index: {2}", entry.Key, entry.Value, sort.IndexOfKey(entry.Key));//IndexOfValue pega o indice do item com base no valor, não na chave
            }


        }

    }

    public class DescendingComparer : IComparer
    {
        CaseInsensitiveComparer _comparer = new CaseInsensitiveComparer();
        public int Compare(object x, object y)
        {
            // Reversing the compared objects to
            // get descending comparisons
            return _comparer.Compare(y, x);
        }

    }
}
