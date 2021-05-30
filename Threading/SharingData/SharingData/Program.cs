using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SharingData
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter count = new Counter();

            ParameterizedThreadStart starter = new ParameterizedThreadStart(UpdateCount);
            Thread[] threads = new Thread[10];

            for (int x = 0; x < 10; ++x)
            {
                threads[x] = new Thread(starter);
                threads[x].Start(count);

                //Resolveria o problema visto que as threads seguintes so executariam depois desta
                //Mas perderia a execucao concorrente das threads
                //threads[x].Join();
            }
            // Wait for them to complete
            for (int x = 0; x < 10; ++x)
            {
                //Só o daqui pra frente que será executado depois das threads
                threads[x].Join();
            }

            Console.WriteLine("Total: {0} - EvenCount: {1}", count.Count, count.EvenCount);
        }

        static void UpdateCount(object param)
        {
            Counter count = (Counter)param;
            for (int x = 1; x <= 10000; ++x)
            {
                // Add two to the count
                count.UpdateCount();
            }
        }



        public class Counter
        {
            int _count = 0;
            int _evenCount = 0;

            public int Count
            {
                get { return _count; }
            }

            public int EvenCount
            {
                get { return _evenCount; }
            }

            public void UpdateCount()
            {
                Monitor.Enter(this);
                try
                {
                    //Possui o mesma função do Monitor.Enter porém no monitor você possui um controle maior do lock
                    //lock (this)
                    //{

                    //A operação seria thread - safe mas o conjunto não
                    //Interlocked.Increment(ref _count);

                    //O valor ficaria diferente caso nao utilizasse o lock visto que o valor da variavel count é acessada simultaneamente por varia threads
                    _count = _count + 1;

                    //Daria erro pois duas threads iriam atualizar o valor de _count uma apos a outra e ao acessar a variavel aqui
                    //estaria com o valor incorreto

                    if (Count % 2 == 0) // An even number
                    {
                        _evenCount = _evenCount + 1;
                    }
                }
                finally
                {
                    Monitor.Exit(this);
                }
                //}
            }
        }
    }
}
