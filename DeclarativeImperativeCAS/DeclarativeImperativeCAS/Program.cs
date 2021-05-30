using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Diagnostics;

//Permite depurar considerando as permissões, sem isso terá uma excecao logo ao rodar o aplicativo
[assembly: UIPermission(SecurityAction.RequestOptional, Unrestricted = true)]
[assembly: EventLogPermission(SecurityAction.RequestOptional, Unrestricted = true)]
[assembly: FileIOPermissionAttribute(SecurityAction.RequestOptional, Read = @"C:\")]
//Permite o acesso a uma pasta, e bloqueia as demais permissoes deste mesmo tipo que nao estejam declaradas
[assembly: FileIOPermissionAttribute(SecurityAction.RequestOptional, Read = @"C:\Temp")]
[assembly: FileIOPermissionAttribute(SecurityAction.RequestRefuse, Read = @"C:\Windows\")]
//Necessário para que seja possivel o uso de Assert 
//Além disto o assembly tem que ter permissão de Assemblies must have the
//Assert Any Permission That Has Been Granted no tipo de permissão Security no CAS
[assembly: SecurityPermissionAttribute(SecurityAction.RequestOptional, Assertion = true)]
//Permite chamar assembly com strong name (gac) a partir de um assembly parcialmente confiavel (que usa o CAS)
[assembly: AllowPartiallyTrustedCallers]
//As permissões do usuário continuam valendo e não são ignorada nem pelo Assert
namespace DeclarativeImperativeCAS
{
    //Permite que as classe filhas herdar as permissões de segurança baseado em um certificado de segurança (apenas declarativamente)
    //[PublisherIdentityPermission(SecurityAction.InheritanceDemand, CertFile = @"C:\Certificates\MyCertificate.cer")]
    //use demands to protect custom resources that require custom permissions.
    class Program
    {
        static void Main(string[] args)
        {
            VerifyMultiplePermissions();
            VerifyAssemblyPermission();
            try
            {
                ReadBoot();
                Console.WriteLine("Reading one line of the boot.ini file:");
                StreamReader sr = new StreamReader(@"C:\boot.ini");
                Console.WriteLine("First line of boot.ini: " + sr.ReadLine());
            }
            catch (SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ReadBootImperatively();
            DenyReadFileImperatively();
            AssertReadBootImperativelyNoPermission();
            Console.ReadLine();
        }

        //Só irá funcionar se o chamador (assembly tiver permissão em C:\
        [FileIOPermission(SecurityAction.Demand, Read = @"C:\boot.ini")]
        public static void ReadBoot()
        {
            StreamReader sr = new StreamReader(@"C:\boot.ini");
            Console.WriteLine("First line of boot.ini: " + sr.ReadLine());
        }

        //Uma das vantagens de fazer imperativamente é que você pode controlar a segurança e até mesmo a excecao 
        //(caso seja disparada) de forma interna ao metódo.
        public static void ReadBootImperatively()
        {

            try
            {
                FileIOPermission filePermissions = new FileIOPermission(FileIOPermissionAccess.Read, @"C:\boot.ini");
                filePermissions.Demand();
                StreamReader sr = new StreamReader(@"C:\boot.ini");
                Console.WriteLine("First line of boot.ini: " + sr.ReadLine());
            }
            catch (SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [FileIOPermissionAttribute(SecurityAction.Deny, Read = @"C:\")]
        public static void AssertReadBootImperativelyNoPermission()
        {
            AssertReadBootImperatively();
        }

        //Assert serve para Ignorar alguma sentença de verificação
        //só pode ser usado uma vez pode metodo
        public static void AssertReadBootImperatively()
        {
            // Block all CAS permission checks for file access to the Windows directory           
            try
            {
                FileIOPermission filePermissions = new FileIOPermission(FileIOPermissionAccess.AllAccess, @"C:\");
                // Block all CAS permission checks for file access to the C: directory
                filePermissions.Assert();
                StreamReader sr = new StreamReader(@"C:\boot.ini");
                Console.WriteLine("As sentenças de verificação do metodo anterior foram ignoradas(Assert)\r\nFirst line of boot.ini: " + sr.ReadLine());
            }
            catch (SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
                Console.WriteLine("Assert Revertido");
            }
        }

        public static void VerifyAssemblyPermission()
        {
            FileIOPermission filePermissions = new FileIOPermission(FileIOPermissionAccess.Read, @"C:\");
            if (SecurityManager.IsGranted(filePermissions) == true)
            {
                Console.WriteLine("Assembly possui permissão em C:");
            }
            else
                Console.WriteLine("Não é possivel ler o C:, permissões insuficientes");
        }

        public static void DenyReadFileImperatively()
        {
            try
            {
                // Deny access to the Windows directory
                FileIOPermission filePermissions = new FileIOPermission(FileIOPermissionAccess.AllAccess, @"C:\");
                filePermissions.Deny();
                StreamReader sr = new StreamReader(@"C:\boot.ini");
                Console.WriteLine("First line of boot.ini: " + sr.ReadLine());
            }
            catch (SecurityException ex)
            {
                Console.WriteLine("Não é possivel ler um arquivo quando a permissão está Deny para ele");
                //Desfaz a proibicao no acesso ao arquivo
                CodeAccessPermission.RevertDeny();
                Console.WriteLine("Deny Desfeito");

                //Pode ser usado em tratamentos de exceção para permitir somente gravar o log de erro
                EventLogPermission errorPerms = new EventLogPermission(PermissionState.Unrestricted);
                errorPerms.PermitOnly();

                EventLog eventLog = new EventLog("Application");
                eventLog.Source = "CAS Error";
                eventLog.WriteEntry("Have a CAS ERROR", EventLogEntryType.Information);

                try
                {
                    StreamReader sr1 = new StreamReader(@"C:\boot.ini");
                    Console.WriteLine("First line of boot.ini: " + sr1.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Não é possivel ler um arquivo quando a permissão está PermitOnly para EventLog");
                }
            }

            Console.WriteLine("Permit Only Desfeito");
            //Desfaz a proibicao que permite somente gravar log de eventos.
            CodeAccessPermission.RevertPermitOnly();
            StreamReader sr2 = new StreamReader(@"C:\boot.ini");
            Console.WriteLine("First line of boot.ini: " + sr2.ReadLine());
        }

        public static void VerifyMultiplePermissions()
        {

            try
            {
                PermissionSet myPerms = new PermissionSet(PermissionState.None);
                myPerms.AddPermission(new FileIOPermission(FileIOPermissionAccess.Read, @"C:\"));
                myPerms.AddPermission(new RegistryPermission(RegistryPermissionAccess.Write, @"HKEY_LOCAL_MACHINE\Software"));

                System.Collections.IEnumerator enumerator = myPerms.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    IPermission permission = (IPermission)enumerator.Current;

                    if (SecurityManager.IsGranted(permission) == true)
                    {
                        Console.WriteLine("Assembly tem a seguinte permissão:" + permission.GetType().ToString());
                    }
                    else
                        Console.WriteLine("Assembly não tem a seguinte permissão:" + permission.GetType().ToString());
                }

            }
            catch (SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        [WebPermission(SecurityAction.Demand, ConnectPattern = @"http://www\.microsoft\.com/.*")]
        public static void requestWebPage()
        {
            // Method logic
        }

        public static void requestWebPageImperatively()
        {
            try
            {
                Regex connectPattern = new Regex(@"http://www\.microsoft\.com/.*");
                WebPermission webPermissions = new WebPermission(NetworkAccess.Connect, connectPattern);
                webPermissions.Demand();
                // Method logic
            }
            catch
            {
                // Error-handling logic
            }
        }

        public static void permitWebAccess()
        {
            try
            {
                // Permit only Web access, and limit it to www.microsoft.com
                Regex connectPattern = new Regex(@"http://www\.microsoft\.com/.*");
                WebPermission webPermissions = new WebPermission(NetworkAccess.Connect,
                connectPattern);
                webPermissions.PermitOnly();
                // Method logic
            }
            catch
            {
                // Error-handling logic
            }
        }


    }
}
