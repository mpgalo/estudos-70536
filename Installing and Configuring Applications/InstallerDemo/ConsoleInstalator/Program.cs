using System;
using System.Collections;
using System.Configuration.Install;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInstalator
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary Actions = new Hashtable();
            try
            {
                //// Create an object of the 'AssemblyInstaller' class.
                //AssemblyInstaller CustomAssemblyInstaller = new AssemblyInstaller(@"C:\Projetos\ESTUDOS\70-536\Installing and Configuring Applications\InstallerDemo\InstallerDemo\bin\Debug\InstallerDemo.dll", args);
                //CustomAssemblyInstaller.UseNewContext = true;
                //// Install the 'MyAssembly' assembly.
                //CustomAssemblyInstaller.Install(Actions);
                //// Commit the 'MyAssembly' assembly.
                //CustomAssemblyInstaller.Commit(Actions);

                InstallerDemo.CustomInstaller installer = new InstallerDemo.CustomInstaller();
                installer.Install(Actions);
                installer.Commit(Actions);
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
