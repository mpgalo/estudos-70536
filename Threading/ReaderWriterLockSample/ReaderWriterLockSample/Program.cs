using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ReaderWriterLockSample
{


    class Program
    {

        private static ReaderWriterLock _lock;

        static void Main(string[] args)
        {
            _lock = new ReaderWriterLock();
            ThreadStart readerStart = new ThreadStart(ReaderLockTest);
            ThreadStart writerStart = new ThreadStart(WriteLockTest);
            Thread[] threads = new Thread[10];
            Thread writerThread = new Thread(writerStart);
            writerThread.Start();
            for (int x = 0; x < 10; ++x)
            {
                threads[x] = new Thread(readerStart);
                threads[x].Start();
            }    
          

        }

        static void ReaderLockTest()
        {
            try
            {
                _lock.AcquireReaderLock(100);
                try
                {
                    //Muda para writer para que consiga incrementar em 1 mantendo o lock entre as threads
                    //Sem isto as threads mudariam os valores uma das outras
                    LockCookie cookie = _lock.UpgradeToWriterLock(1000);
                    Counter.Count++;
                    Counter.EvenCount++;

                    //Muda novamente para reader 
                    _lock.DowngradeFromWriterLock(ref cookie);

                    Console.WriteLine(Counter.Count.ToString() + " " + Counter.EvenCount.ToString());
                }
                catch (ApplicationException)
                {
                    Console.WriteLine("Failed to get a upgrade reader lock to writer Lock");
                }
                finally
                {
                    _lock.ReleaseReaderLock();
                }
            }
            catch (ApplicationException)
            {
                Console.WriteLine("Failed to get a Reader Lock");
            }
        }

        //Feito desta forma os primeiros valores viriam descrepantes
        //Visto que as threads de leitura só podem ser executadas após a thread de escrita
        //static void ReaderLockTest()
        //{
        //    Console.WriteLine(Counter.Count.ToString() + " " + Counter.EvenCount.ToString());
        //}

        static void WriteLockTest()
        {
            try
            {
                _lock.AcquireWriterLock(1000);
                try
                {
                    for (int i = 0; i < 10000; i++)
                    {

                        Interlocked.Increment(ref Counter.Count);

                        if (Counter.Count % 2 == 0) // An even number
                        {
                            Interlocked.Increment(ref Counter.EvenCount);
                        }
                    }

                }
                finally
                {
                    _lock.ReleaseWriterLock();
                }
            }
            catch (ApplicationException)
            {
                Console.WriteLine("Failed to get a Writer Lock");
            }
        }

        public class Counter
        {
            public static int Count = 0;
            public static int EvenCount = 0;
        }
    }
}
