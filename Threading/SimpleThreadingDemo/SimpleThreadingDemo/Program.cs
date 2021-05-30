using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart starter = new ThreadStart(counting);
            Thread first = new Thread(starter);
            Thread second = new Thread(starter);
            first.Start();           
            second.Start();
            first.Join();
            second.Join();
          
            Console.Read();
        }

        static void counting()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadID: {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }
    }
}
