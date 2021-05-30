using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Gen<string, string> gen= new Gen<string, string>("Marcus","Paulo");
            Console.WriteLine(string.Concat( gen.t," ", gen.u));
           
            
            
        }
    }

    class Gen<T, U>
    {
        public T t; public U u;
        public Gen(T _t, U _u)
        {
            t = _t;
            u = _u;
        }
    }
}
