using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ProcessManipulating
{
    class Program
    {
        static void Main(string[] args)
        {

            // Obter Processo de acordo com ID

            try
            {
                Process SpecificProcess = null;
                SpecificProcess = Process.GetProcessById(5736);
                Console.WriteLine(string.Format("Processo:{0}, Memória:{1}, Processador:{2}", SpecificProcess.ProcessName
                    , SpecificProcess.PrivateMemorySize64, SpecificProcess.TotalProcessorTime));

            }
            catch (ArgumentException Problem)
            {
                Console.WriteLine(Problem.Message);
            }

            //Listar modulos de um processo especifico
            Process[] SpecificProcesses = null;
            SpecificProcesses = Process.GetProcessesByName("explorer", "micp100682.cemig.ad.corp");
            foreach (Process ThisProcess in SpecificProcesses)
            {
                Console.WriteLine(ThisProcess.ProcessName);
            }

            //Listar todos os processoas Maquina
            Process[] AllProcesses = null;
            try
            {
                AllProcesses = Process.GetProcesses("micp100682.cemig.ad.corp");
                foreach (Process Current in AllProcesses)
                {
                    Console.WriteLine(Current.ProcessName);
                }
            }
            catch (ArgumentException Problem)
            {
                Console.WriteLine(Problem.Message);
            }

            //Process.Start("calc");

            ProcessStartInfo Info = new ProcessStartInfo();
                        
            Info.FileName = "calc";
            Info.Arguments = "15";
            //Set UseShellExecute to false if you specify a username
            Info.UseShellExecute = false;
            Info.UserName = "e060111";
            System.Security.SecureString strSenha = new System.Security.SecureString();
            //Se passar usuario e senha tem de ser correto
            string senha = "Outubro2010";

            for (Int32 i = 0; i < senha.Length; i++)
            {
                strSenha.AppendChar(Convert.ToChar(senha[i]));
            }

            Info.Password = strSenha;

            Process.Start(Info);

            Console.ReadLine();

            try
            {
                Int32 x = 1;
                x--;
                Int32 i = 10 / x;
            }
            catch (DivideByZeroException Problem)
            {
                Debug.Assert(false, Problem.StackTrace);
            }
        }
    }
}
