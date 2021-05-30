using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Policy;

namespace AppDomainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // C#
            // Create an Evidence object for the Internet zone


            //Zone safeZone = new Zone(SecurityZone.Internet);
            try
            {
                object[] hostEvidence = { new Zone(SecurityZone.Internet) };
                Evidence e = new Evidence(hostEvidence, null);



                // Create an AppDomain.
                AppDomain d = AppDomain.CreateDomain("New Domain", e);
                
                // Run the assembly
                // TODO: Edit the path to the executable file
                d.ExecuteAssembly(@"C:\Projetos\ESTUDOS\70-536\Application Domains and Services\Lesson1-ShowBootIni-CS\ShowBootIni\ShowBootIni\bin\Debug\ShowBootIni.exe");
            }
            catch(SecurityException sEx)
            {
                Console.WriteLine(sEx.Message);
            }
        }
    }
}
