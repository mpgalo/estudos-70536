using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adicionando Items ao ArrayLisy (AddRange / Add)
            //Metodo add e addrange adiciona itens ao final da lista
            ArrayList coll = new ArrayList();
            string[] anArray =  new string[] { "More", "or", "less" };
            Array.Sort(anArray);
            coll.AddRange(anArray);
            coll.Add("more one");
            object[] anotherArray = new object[] { new object(), new ArrayList() };
            coll.AddRange(anotherArray);
            
            //Metodo Insert e InsertRange insere item em determinada posição da lista/reordenando as demais

            string[] moreStrings = new string[] { "goodnight", "See ya" };
            coll.InsertRange(4, moreStrings);
            coll.Insert(6, "bye");

            //Pode-se ainda atribuir valor a determinada posição através de seu indexador, o indice deve estar no limite dos itens adicionados
            coll[8] = "Hey All";
            for (int i = 0; i < coll.Count; i++)
            {
                Console.WriteLine(coll[i]);
            }

            //Metodo Remove remove o item com base em seu conteudo redimensionando a lista / não retorna erro se nao achar o elemento
            coll.Remove("or");
            //Metodo RemoveAt, remove item com base em seu indice, o indice deve estar no limite dos itens adicionados
            coll.RemoveAt(2);
            //Metodo RemoveRange remove um range de itens com base em indice inicial e numero de items a ser removido,o indice deve estar no limite dos itens adicionados
            coll.RemoveRange(4,2);
            for (int i = 0; i < coll.Count; i++)
            {
                Console.WriteLine(coll[i]);
            }

            string myString = "My String";
            coll.Add(myString);
            coll.Add(myString);
            //Verifica se determinao objeto existe na lista
            if (coll.Contains(myString))
            {
                Console.WriteLine(myString + " será removido");
                //Verifica o indice  da primeira ocorrencia de determinado objeto na lista
                int index = coll.IndexOf(myString);
                coll.RemoveAt(index);
                //Verifica o indice  da ultima ocorrencia de determinado objeto na lista
                index = coll.LastIndexOf(myString);
                coll.RemoveAt(index);
                
               
            }
            else
            {
                //Limpa todoos os itens do arrayList
                coll.Clear();
            }

            //Ordena os itens no ArrayList definindo que não será vista maiusculas e minuscula (CaseInsensitiveComparer)
            //Pode-se implementar ainda seu próprio Comparer atraves de IComparer
            //coll.Sort();
            coll.Sort(new DescendingComparer());
            foreach (object obj in coll)
            {
                Console.WriteLine(obj);
            }

            //Reverte a ordem dos itens no arrayList
            coll.Reverse();
            foreach (string obj in coll)
            {
                Console.WriteLine(obj);
            }


            //Atraves do GetEnumerator  Também podemos percorrer
            IEnumerator enumerator = coll.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
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
