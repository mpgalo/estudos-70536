using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace AsynchronousProgramming
{
    class Program
    {
        static byte[] buffer = new byte[100];
        static void Main(string[] args)
        {           
            TestWaitUntilAPM();
            TestPollingAPM();
            TestCallbackAPM();
            Console.Read();
        }

      
        private static void TestWaitUntilAPM()
        {
            //byte[] buffer = new byte[100];
            string filename = @"C:\WINDOWS\DtcInstall.log";
            FileStream strm = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);
            // Make the asynchronous call strm.Read(buffer, 0, buffer.Length);
            IAsyncResult result = strm.BeginRead(buffer, 0, buffer.Length, null, null);

            // Do some work here while you wait

            // Calling EndRead will block until the Async work is complete
            int numBytes = strm.EndRead(result);
            // Don't forget to close the stream 
            strm.Close();
            Console.WriteLine("Read {0} Bytes", numBytes); 
            Console.WriteLine(BitConverter.ToString(buffer));
        }

        private static void TestPollingAPM()
        {
            //byte[] buffer = new byte[100];
            string filename = @"C:\WINDOWS\DtcInstall.log";
            FileStream strm = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);
            // Make the asynchronous call strm.Read(buffer, 0, buffer.Length);
            IAsyncResult result = strm.BeginRead(buffer, 0, buffer.Length, null, null);

            while (!result.IsCompleted)
            {
                // Do more work here if the call isn't complete
                Thread.Sleep(100);
            }


            // Calling EndRead will block until the Async work is complete
            int numBytes = strm.EndRead(result);
            // Don't forget to close the stream 
            strm.Close();
            Console.WriteLine("Read {0} Bytes", numBytes);
            Console.WriteLine(BitConverter.ToString(buffer));
        }

        static void TestCallbackAPM()
        {            
            string filename = @"C:\WINDOWS\DtcInstall.log";
            FileStream strm = new FileStream(filename,
            FileMode.Open, FileAccess.Read, FileShare.Read, 1024,
            FileOptions.Asynchronous);

            // Make the asynchronous call 
            IAsyncResult result = strm.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(CompleteRead), strm);
        }

        static void CompleteRead(IAsyncResult result)
        {           
            Console.WriteLine("Read Completed");
            FileStream strm = (FileStream)result.AsyncState;
            // Finished, so we can call EndRead and it will return without blocking 

            int numBytes = 0;

            try
            {
                numBytes = strm.EndRead(result);
            }
            catch (IOException)
            {
                Console.WriteLine("An IO Exception occurred");
            }
            // Don't forget to close the stream
            strm.Close();
            Console.WriteLine("Read {0} Bytes", numBytes);
            Console.WriteLine(BitConverter.ToString(buffer));
          
            
        }
    }
}
