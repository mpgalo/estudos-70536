using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an AppDomain.
            AppDomain d = AppDomain.CreateDomain("New Domain");

            // Run the assembly
            // TODO: Edit the path to the executable file
            d.ExecuteAssembly(@"C:\Projetos\ESTUDOS\70-536\Application Domains and Services\Lesson1-ShowBootIni-CS\ShowBootIni\ShowBootIni\bin\Debug\ShowBootIni.exe");

            Console.WriteLine("Assembly carregado em memória");

            AppDomain.Unload(d);

            Console.WriteLine("Assembly descarregado da memória");

            //d.ExecuteAssemblyByName("ShowBootIni");

        }
    }
}
