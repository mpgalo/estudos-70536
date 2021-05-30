using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Security;
using System.Security.Principal;
using System.Security.Permissions;


namespace AuthenticationAuthorization
{
    class Program
    {
        static void Main(string[] args)
        {
            //Obtém informações do usuário corrente autenticado no Windows
            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
            Console.WriteLine("Nome Usuário: {0}", currentIdentity.Name);
            Console.WriteLine("Tipo de Autenticação: {0}", currentIdentity.AuthenticationType);
            Console.WriteLine("Token: {0}", currentIdentity.Token);

            // Display information based on Boolean properties of
            // the current user
            if (currentIdentity.IsAnonymous)
                Console.WriteLine("Is an anonymous user");
            if (currentIdentity.IsAuthenticated)
                Console.WriteLine("Is an authenticated user");
            if (currentIdentity.IsGuest)
                Console.WriteLine("Is a guest");
            if (currentIdentity.IsSystem)
                Console.WriteLine("Is part of the system");

            //foreach (IdentityReference group in currentIdentity.Groups)
            //{
            //    Console.WriteLine("Grupo: {0}", group.Value);
            //}

            //Windows Principal server para identificar o usuário e seus grupos
            //Pode ser obtido através de uma instancia de WindowsIdentity ou diretamente pela Thread

            // Para obter o WindowsPrincipal diretamente da Thread 
            //assim como para usar o PrincipalPermission para restringir acesso a metodos deve-se setar a politica principal:
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            // Converte o CurrentePrincipal em um WindowsPrincipal, visto que ele retorna a interface
            //WindowsPrincipal currentPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;

            WindowsPrincipal currentPrincipal = new WindowsPrincipal(currentIdentity);

            Console.WriteLine("The user {0} is a member of the following roles: ", currentPrincipal.Identity.Name);
            //Verifica se o usuário atual é de alguns dos grupos (Built-in) (Original da máquina)
            if (currentPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
                Console.WriteLine(WindowsBuiltInRole.Administrator.ToString());

            if (currentPrincipal.IsInRole(WindowsBuiltInRole.PowerUser))
                Console.WriteLine(WindowsBuiltInRole.PowerUser.ToString());
            if (currentPrincipal.IsInRole(WindowsBuiltInRole.User))
                Console.WriteLine(WindowsBuiltInRole.User.ToString());

            //Pode-se verificar se o usuário é de um grupo passando o nome do Grupo da seguinte forma: DOMINIO\GRUPO ou MAQ\GRUPO
            if (currentPrincipal.IsInRole(System.Environment.UserDomainName + "\\usrsr"))
                Console.WriteLine(System.Environment.UserDomainName + "\\users");

            if (currentPrincipal.IsInRole(System.Environment.MachineName + "\\ti"))
                Console.WriteLine(System.Environment.MachineName + "\\ti");

            //Se o grupo for da própria máquina não precisa de nome
            if (currentPrincipal.IsInRole("VS Developers"))
                Console.WriteLine("VS Developers");

            try
            {
                DoSomethingRoleDeclarative();
            }
            catch (SecurityException)
            {
                Console.WriteLine("Você não é do grupo VS Developers");
            }

            try
            {
                DoSomethingAuthenticatedDeclarative();
            }
            catch (SecurityException)
            {
                Console.WriteLine("O usuário não está autenticado");
            }

            try
            {
                DoSomethingNamedDeclarative();
            }
            catch (SecurityException)
            {
                Console.WriteLine(@"Você não é o usuário NETCEMIG\e060111");
            }

            try
            {
                DoSomethingAllDeclarative();
            }
            catch (SecurityException)
            {
                Console.WriteLine(@"Você não está autorizado(Autenticado E Grupo E Usuario).");
            }

            try
            {
                DoSomethingAllSeparatedDeclarative();
            }
            catch (SecurityException)
            {
                Console.WriteLine(@"Você não está autorizado(Autenticado OU Grupo OU Usuario).");
            }

            DoSomethingAllImperative();


            //GenericPrincipal tem as funcionalidade gerais de IPrincipal
            GenericIdentity myUser1 = new GenericIdentity("AHankin");
            String[] myUser1Roles = new String[] { "IT", "Users", "Administrators" };
            GenericPrincipal myPrincipal1 = new GenericPrincipal(myUser1, myUser1Roles);
            GenericIdentity myUser2 = new GenericIdentity("TAdams");
            String[] myUser2Roles = new String[] { "Users" };
            GenericPrincipal myPrincipal2 = new GenericPrincipal(myUser2, myUser2Roles);
            try
            {
                Thread.CurrentPrincipal = myPrincipal1;
                TestSecurity();
                Thread.CurrentPrincipal = myPrincipal2;
                TestSecurity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString() + " caused by " + Thread.CurrentPrincipal.Identity.Name);
            }
        }

        //Para o exemplo abaixo é disparado uma exceção ao chamar o metodo pois o usuario nao está neste grupo
        //[PrincipalPermission(SecurityAction.Demand, Role = "Convidados")]
        //No caso abaixo vai conseguir executar o metodo porque o usuário é do grupo especificado
        [PrincipalPermission(SecurityAction.Demand, Role = "VS Developers")]
        public static void DoSomethingRoleDeclarative()
        {
            Console.WriteLine("Se estiver vendo está linha é porque voce faz parte do grupo VS Developers");
        }

        //Só permite que o método seja visualizado por usuários Autenticados
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public static void DoSomethingAuthenticatedDeclarative()
        {
            Console.WriteLine("Se estiver vendo está linha é porque voce está autenticado");
        }

        //Só permite que o método seja visualizado por usuários Autenticados
        [PrincipalPermission(SecurityAction.Demand, Name = @"NETCEMIG\e060111")]
        public static void DoSomethingNamedDeclarative()
        {
            Console.WriteLine(@"Se estiver vendo está linha é porque voce é o usuário NETCEMIG\e060111");
        }

        [PrincipalPermission(SecurityAction.Demand, Name = @"NETCEMIG\e060111", Role = "VS Developers", Authenticated = true)]
        public static void DoSomethingAllDeclarative()
        {
            Console.WriteLine("Se estiver vendo está linha é porque voce está autenticado\nE faz parte do grupo VS Developers E é o usuário NETCEMIG\\e060111");
        }

        [PrincipalPermission(SecurityAction.Demand, Name = @"NETCEMIG\e06111")]
        [PrincipalPermission(SecurityAction.Demand, Role = "VS Developers")]
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public static void DoSomethingAllSeparatedDeclarative()
        {
            Console.WriteLine("Se estiver vendo está linha é porque voce está autenticado\nOU faz parte do grupo VS Developers OU é o usuário NETCEMIG\\e060111");
        }

        public static void DoSomethingAllImperative()
        {
            // C#
            // Define the security policy in use as Windows security
            System.AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            // Concatenate the group name as "MachineName\VS Developers"
            string r = System.Environment.MachineName + @"\VS Developers";
            // Catch any security denied exceptions so that they can be logged
            try
            {
                // Create and demand the PrincipalPermission object
                PrincipalPermission p = new PrincipalPermission(@"NETCEMIG\e060111", r, true);
                p.Demand();
                Console.WriteLine("Access allowed.");
                // TODO: Main application
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine("Access denied: " + ex.Message);
                // TODO: Log error
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "IT")]
        private static void TestSecurity()
        {
            Console.WriteLine(Thread.CurrentPrincipal.Identity.Name + " is in IT.");
        }

    }
}
