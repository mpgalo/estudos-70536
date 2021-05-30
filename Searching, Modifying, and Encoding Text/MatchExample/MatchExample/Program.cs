using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MatchExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex("ASP.NET");
            Match a = reg.Match("XML9658ASP.NET963");
            if (a.Success)
                Console.WriteLine("ASP.NET encontrado na posição " + a.Index);
            else
                Console.WriteLine("Não encontrado");
        }
    }
}
