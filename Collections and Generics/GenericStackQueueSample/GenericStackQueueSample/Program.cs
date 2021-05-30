using System;
using System.Collections.Generic;
using System.Text;

namespace GenericStackQueueSample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Queue<String> que = new Queue<String>();
            que.Enqueue("Hello");
            Console.WriteLine(que.Dequeue());

            Stack<int> serials = new Stack<int>();
            serials.Push(1);
            serials.Push(2);
            Console.WriteLine(serials.Pop());
        }
    }
}
