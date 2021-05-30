using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StackSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();

            //Inclui itens na pilha
            s.Push("First");
            s.Push("Second");
            s.Push("Third");
            s.Push("Fourth");

            //Item no topo da pilha
            Console.WriteLine(s.Peek());

            while (s.Count > 0)
            {
                //Remove item da pilha (Ultimo a entrar)
                Console.WriteLine(s.Pop());
            }
        }
    }
}
