using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace QueueSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();

            q.Enqueue("First");
            q.Enqueue("Second");
            q.Enqueue(new object());
            q.Enqueue("Third");
            q.Enqueue("Fourth");

            //Percorrer itens sem removelos da lista
            IEnumerator items = q.GetEnumerator();
            while (items.MoveNext())
            {
                Console.WriteLine(items.Current);
            }

            //Verifica a existencia de um item
            if (q.Contains(null))
            {
                q.Clear();
            }
            
           
            while (q.Count > 0)
            {
                //pega proximo item da lista
                if (q.Peek() is string)
                    Console.WriteLine(q.Dequeue());
                else
                    q.Dequeue();
            }
        }
    }
}
