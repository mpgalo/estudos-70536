using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CreatingThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart mainOperation = new ThreadStart(DoWork);
            Thread theThread = new Thread(mainOperation);
            //Altera a prioridade de execução das threads
            //theThread.Priority = ThreadPriority.Lowest;
            theThread.Start();
            //as outras threads so serao executadas depois da conclusao desta
            theThread.Join();
            Console.WriteLine("Esperado");

            ParameterizedThreadStart operation = new ParameterizedThreadStart(WorkWithParameter);
            Thread[] theThreads = new Thread[5];
            
            for (int x = 0; x < 5; ++x)
            {

                // Creates, but does not start, a new thread
                theThreads[x] = new Thread(operation);
                // Starts the work on a new thread
                theThreads[x].Start("Thread" + x.ToString());
            }

            Thread abortThread = new Thread(new ThreadStart(MethodToBeAborted));
            abortThread.Start();
            abortThread.Abort();
        }

        static void DoWork()
        {
            for (int x = 0; x <= 10; ++x)
            {
                Console.WriteLine("Thread Principal: {0}",
                Thread.CurrentThread.ManagedThreadId);
                // Slow down thread and let other threads work 
                Thread.Sleep(10);
            }
        }

        static void WorkWithParameter(object o)
        {
            //O parametro deve ser validado
            //Para nao causar problemas na execução da thread
            string info = (string)o;
            if (info == null) { throw new ArgumentException("Parameter for thread must be a string"); }

            for (int x = 0; x < 10; ++x)
            {
                Console.WriteLine("{0}: {1}", info,
                Thread.CurrentThread.ManagedThreadId);
                // Slow down thread and let other threads work
                Thread.Sleep(10);
            }
        }

        static void MethodToBeAborted()
        {
            //Ao utilizar o bloco BeginCriticalRegion e EndCriticalRegion
            //o que está dentro do bloco é executado por completo
            //mesmo que o metodo de abort tenha sido chamado
            Thread.BeginCriticalRegion();

            for (int x = 0; x < 10; ++x)
            {
                Console.WriteLine("Tread ainda nao foi abortada-" + x);
                // Slow down thread and let other threads work
                Thread.Sleep(10);
            }

            Thread.EndCriticalRegion();
          

        }
    }
}
