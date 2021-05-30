using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex oneMutex = null;
            const string mutexName = "RUNMEONCE";

            try
            {
                oneMutex = Mutex.OpenExisting(mutexName);
            }
            catch(WaitHandleCannotBeOpenedException)
            {
            }

            if (oneMutex == null)
            {
                oneMutex = new Mutex(false, mutexName);
            }
            else
            {
                oneMutex.Close();
                return;
            }

            Console.WriteLine("Our Application");
            Console.Read();
        }
    }
}
