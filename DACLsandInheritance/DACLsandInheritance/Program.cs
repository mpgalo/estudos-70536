using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Security.Principal;

namespace DACLsandInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorySecurity ds = new DirectorySecurity();
            ds.AddAccessRule(new FileSystemAccessRule("Guest", FileSystemRights.Read, AccessControlType.Allow));
            //Só herdaria as permissões de o diretorio fosse criado antes das permissoes serem atribuidas
            Directory.CreateDirectory(@"C:\Guest", ds);
            File.Create(@"C:\Guest\Data.Data");
        }
    }
}
