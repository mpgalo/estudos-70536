using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace HashTableSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //O HashTable é organizado pelo Hash Code da chaves
            Hashtable hash = new Hashtable();
            hash.Add("B", "Marcus");
            hash.Add("A", "Janus");
            hash["B"] = "Marcus Paulo"; //atribuindo valor através do indexador (nesta caso a chave)


            foreach (DictionaryEntry item in hash)
            {
                Console.WriteLine(item.Value);
            }

            if (hash.ContainsValue("Marcus"))
            {
                foreach (object item in hash.Values)
                {
                    Console.WriteLine(item);
                }
            }

            


            //Apesar da string ser igual não ocorre erro ao adicionar as chaves, pois o hashtable nao verifica o conteudo e sim a instancia (hash code)
            //Mesmo sobreescrevendo o metodo GetHashCode para retornar o mesmo codigo, após isso o hash table utiliza o metodo Equals, para comparar
            //o valor das instancias
            //Para compara instancas sobre o valor de uma variavel devemor sobrescrever GetHashCode e Equals
            Hashtable duplicates = new Hashtable();
            Fish key1 = new Fish("Herring");
            Fish key2 = new Fish("Herring"); 
            duplicates.Add(key1,"Hello");
            //duplicates.Add(key2, "Hello");//Geraria erro, pois os metodos de comparacao foram sobrescritos
            Console.WriteLine(duplicates.Count);


            //Utilizo a classe InsensitiveComparer que herda de IEqualityComparer para definir os metodos de comparacao entre as 
            //chaves do dicionario
            Hashtable duplicates2 = new Hashtable(new InsensitiveComparer());
            string strKey1 = "Herring";
            string strKey2 = "herring";
            duplicates2.Add(strKey1, "Hello");
            //duplicates2.Add(strKey2, "Hello");//Geraria erro, pois os metodos de comparacao foram sobreescritos para tratarem case insensitive
            Console.WriteLine(duplicates2.Count);

            DictionaryEntry[] strArray = new DictionaryEntry[duplicates2.Count];
            duplicates2.CopyTo(strArray, 0);
            foreach (DictionaryEntry item in strArray)
            {
                Console.WriteLine(item.Value);
            }
            
            
        }
    }

    public class Fish
    {
        string name;
        public Fish(string theName)
        {
            name = theName;
        }        
        
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }       
        public override bool Equals(object obj)
        {
            Fish otherFish = obj as Fish;
            if (otherFish == null) return false;
            return otherFish.name == name;
        }
    }


    //Podemos usar uma classe que herda de IEqualityComparer para definirmos os metodos de comparação em dicionarios
    public class InsensitiveComparer : IEqualityComparer
    {
        CaseInsensitiveComparer _comparer = new CaseInsensitiveComparer();
        public int GetHashCode(object obj)
        {
            return obj.ToString().ToLowerInvariant().GetHashCode();
        }
        public new bool Equals(object x, object y)
        {
            if (_comparer.Compare(x, y) == 0)            
                return true;            
            else
                return false;
        }
    }
}
