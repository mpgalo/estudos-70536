using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NextMatchExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            string buscar = "Este é meu e-mail pessoal mpghelli@hotmail.com, não meu email de trabalho marcus.ghelli@pdcase.com.br";
            Match a = reg.Match(buscar);
            while (a.Success)
            {
                Console.WriteLine(a.Value);
                a = a.NextMatch();
            }
        }
    }
}
