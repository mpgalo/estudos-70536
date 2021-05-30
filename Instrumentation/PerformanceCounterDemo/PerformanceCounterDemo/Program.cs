using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Timers;

namespace PerformanceCounterDemo
{
    class Program
    {
        private static PerformanceCounter HeapCounter = null;
        private static PerformanceCounter ExceptionCounter = null;
        private static Timer DemoTimer;

        static void Main(string[] args)
        {
            DemoTimer = new Timer(3000);
            DemoTimer.Elapsed += new ElapsedEventHandler(OnTick);
            DemoTimer.Enabled = true;
            HeapCounter = new PerformanceCounter(".NET CLR Memory", "# Bytes in all Heaps");
            HeapCounter.InstanceName = "_Global_";
            ExceptionCounter = new PerformanceCounter(".NET CLR Exceptions", "# of Exceps Thrown");
            ExceptionCounter.InstanceName = "_Global_";
            Console.WriteLine("Press [Enter] to Quit Program");
            Console.ReadLine();
            
        }

        private static void OnTick(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("# of Bytes in all Heaps : " + HeapCounter.NextValue().ToString());
            Console.WriteLine("# of Framework Exceptions Thrown : " + ExceptionCounter.NextValue().ToString());
        }
    }
}
