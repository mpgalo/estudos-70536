using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TestRegExp
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (Regex.IsMatch(args[1], args[0])) Console.WriteLine("Input matches regular expression.");
            //else Console.WriteLine("Input DOES NOT match regular expression.");
            //Console.ReadLine();

            string input = "Company Name: Contoso, Inc.";
            Match m = Regex.Match(input, @"Company Name: (.*$)");
            Console.WriteLine(m.Groups[1]);
        }
    }
}
