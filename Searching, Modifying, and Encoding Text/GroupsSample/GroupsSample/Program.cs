using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GroupsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex("(1(2))3");
            string buscar = "823412312423";
            Match a = reg.Match(buscar);
            foreach(Group group in a.Groups)
            {
                Console.WriteLine(group);
            }
        }
    }
}
