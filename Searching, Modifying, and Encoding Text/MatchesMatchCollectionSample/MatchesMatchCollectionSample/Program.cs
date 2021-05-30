using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MatchesMatchCollectionSample
{
    class Program
    {
        static void Main(string[] args)
        {            
            Regex reg = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            MatchCollection Cols = reg.Matches("Este é meu e-mail pessoal mpghelli@hotmail.com, não meu email de trabalho marcus.ghelli@pdcase.com.br");
            foreach (Match Col in Cols)
            {
                Console.WriteLine(Col.Value);
            }
        }
    }
}
