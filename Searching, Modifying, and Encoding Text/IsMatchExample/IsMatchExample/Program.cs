using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IsMatchExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma palavra para procurar");
            string busca = Console.ReadLine();
            string texto = "O ASP.NET faz parte do .NET Framework o que o torna ideal para desenvolvimento de aplica��es Web. � f�cil de"
                + " configurar, pois n�o requer configura��o do registro do Windows.";

            Regex Expr = new Regex(busca, RegexOptions.IgnoreCase);
            if (Expr.IsMatch(texto))
                Console.WriteLine(busca + " encontrado");
            else
                Console.WriteLine(busca + " n�o encontrado");
        }
    }
}
