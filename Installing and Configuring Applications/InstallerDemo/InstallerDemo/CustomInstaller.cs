using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Configuration.Install;

namespace InstallerDemo
{
    public class CustomInstaller : Installer
    {
        public CustomInstaller()
            : base()
        {
            // Attach the 'Committed' event. 
            this.Committed += new InstallEventHandler(CustomInstaller_Committed); // Attach the 'Committing' event. 
            this.Committing += new InstallEventHandler(CustomInstaller_Committing);
        }
        private void CustomInstaller_Committing(object sender, InstallEventArgs e)
        {
            //Committing Happened 
            Console.WriteLine("Comitando");
        }
        private void CustomInstaller_Committed(object sender, InstallEventArgs e)
        {
            //Committed happened 
            Console.WriteLine("Comitado");
        }

        // Override the 'Install' method.
        public override void Install(IDictionary savedState)
        {
            Console.WriteLine("Iniciando Instalação");
            base.Install(savedState);
        }

        // Override the 'Commit' method.
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }

        // Override the 'Rollback' method.
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
    }
}
