using System;
using System.Collections.Generic;
using System.Text;

namespace GenericConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Parse("01/01/2006");
            DateTime date2 = DateTime.Parse("02/02/2006");
            CompGen<DateTime> comp = new CompGen<DateTime>(date, date2);
            DateTime maiorDate = comp.Max();
            Console.WriteLine(maiorDate);

            //Geraria erro mais Exception não herda de IComparab
            //Exception ex1;
            //Exception ex2;
            //CompGen<Exception> = new CompGen<Exception>(ex1, ex2);
        }
    }

    class CompGen<T> where T : IComparable
    {
        public T t1; public T t2;
        public CompGen(T _t1, T _t2)
        {
            t1 = _t1;
            t2 = _t2;
        }
        public T Max() { if (t2.CompareTo(t1) < 0) return t1; else return t2; }
        //Somente através do  where T : IComparable podemos usar o metodo CompareTo, pois 
        //se a classe herda da interface consequentemente ele deve implementar este metodo
    }
}
