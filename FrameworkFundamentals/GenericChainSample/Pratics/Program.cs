using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace GenericChainSample
{
    class Program
    {
        static void Main(string[] args)
        {            
            double momentoInicial = DateTime.Now.Ticks;
            GenericList<string> stringList = new GenericList<string>(1000000);
            for (int i = 0; i < 1000000; i++)
            {                
                stringList.Add("TESTE1");
            }

            double momentoFinal = DateTime.Now.Ticks;

            Console.WriteLine(momentoFinal - momentoInicial);
        }

    }

    class GenericList<T> : IEnumerable
    {
        private T[] linkedList;
        private int position = 0;

        public GenericList(int length)
        {
            linkedList = new T[length];
        }

        public void Add(T linkItem)
        {
            linkedList[position] = linkItem;
            position++;
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return linkedList.GetEnumerator();
        }

        #endregion
    }

    class GeneralizedList: IEnumerable
    {
        private object[] linkedList;
        private int position = 0;

        public GeneralizedList(int length)
        {
            linkedList = new object[length];
        }

        public void Add(object linkItem)
        {
            linkedList[position] = linkItem;
            position++;
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return linkedList.GetEnumerator();
        }

        #endregion
    }
}
