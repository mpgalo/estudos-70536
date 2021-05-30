using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Security.AccessControl;
using Microsoft.Win32;
using System.IO;

namespace ManipulateACL
{
    //Para trazer SACL (Auditoria) usar o GetAuditRules
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Permissões de acesso a pasta arquivos de programas.");
            ShowFileSystemAcl();
            Console.WriteLine("Permissões de acesso a local machine no registro do windows.");
            ShowRegisterAcl();
            SetAcl();
        }

        public static void ShowFileSystemAcl()
        {
            // C#
            // You could also call Directory.GetAccessControl for the following line
            DirectorySecurity ds = new DirectorySecurity(@"C:\Arquivos de programas", AccessControlSections.Access);
            AuthorizationRuleCollection arc = ds.GetAccessRules(true, true, typeof(NTAccount));            
            foreach (FileSystemAccessRule ar in arc)
            {
                Console.WriteLine(ar.IdentityReference + ": " + ar.AccessControlType + " " + ar.FileSystemRights);
            }
        }

        public static void ShowRegisterAcl()
        {
            RegistrySecurity rs = Registry.LocalMachine.GetAccessControl();            
            AuthorizationRuleCollection arc = rs.GetAccessRules(true, true, typeof(NTAccount));
            foreach (RegistryAccessRule ar in arc)
            {
                Console.WriteLine(ar.IdentityReference + ": " + ar.AccessControlType + " " + ar.RegistryRights);
            }
        }

        public static void SetAcl()
        {
            string dir = @"C:\test";
            DirectorySecurity ds = Directory.GetAccessControl(dir);
            //Adicionar uma permissão / para remover seria RemoveAccessRule.
            ds.AddAccessRule(new FileSystemAccessRule("Guest", FileSystemRights.Read, AccessControlType.Allow));
            Directory.SetAccessControl(dir, ds);
            Console.WriteLine("Permissão de leitura atribuida ao usuário Guest");
        }
    }
}
