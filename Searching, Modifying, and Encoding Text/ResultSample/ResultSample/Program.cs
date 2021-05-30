using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ResultSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string Html = "Isto é um <b>Simples</b> <i>Teste</i> do result para retorno de substring";
            Regex reg = new Regex(@"<(.*)>.*<\/\1>");
            Match a = reg.Match(Html);            
            while (a.Success)
            {
                Console.WriteLine(a.Result("$0"));
                a = a.NextMatch();
            }

        }
    }
}
