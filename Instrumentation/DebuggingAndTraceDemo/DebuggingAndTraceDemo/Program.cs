using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DebuggingAndTraceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool escreverDebug = true;
            //String MyMessage = ReturnMessage();
            //if (MyMessage == null)
            //{
            //    Debug.Fail("MyMessage is Missing");
            //    Debug.Assert(1 == 2,"Erro Debug");
            //    Debugger.Break();
            //    Debug.Print("Teste Print");
            //    Debug.WriteLineIf(escreverDebug, "Teste WriteLineIf");
            //    Debug.WriteLine("Teste WriteLine");
            //    Trace.Listeners.Clear();
            //    DefaultTraceListener myListener = new DefaultTraceListener();
            //    Trace.Listeners.Add(myListener);
            //    Debugger.Log(2, "Test", "This is a test"); Console.ReadLine();
            //}

            SoftwareCompany Company = new SoftwareCompany("A Datum", "Florida", "Miami");
            Company.TesteMetodo();
            ArrayListDemo arrayDemo = new ArrayListDemo();
            arrayDemo.ShouldIgnore = "Sim";

            

        }

        private static string ReturnMessage()
        {
            return null;
        }
    }
}
