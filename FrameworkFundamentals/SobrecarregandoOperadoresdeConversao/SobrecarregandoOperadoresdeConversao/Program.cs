using System;
using System.Collections.Generic;
using System.Text;

namespace SobrecarregandoOperadoresdeConversao
{
    class Program
    {
        static void Main(string[] args)
        {
            Hour hour = 12;
            int intHour = (int)hour;
            Console.WriteLine(hour);
        }
    }
    struct Hour
    {
        public double Value;
       
        // Allows implicit conversion from an integer.
        public static implicit operator Hour(int arg)
        {
            Hour res = new Hour();
            res.Value = arg;
            return res;
        }
       
        // Allows explicit conversion to an integer
        public static explicit operator int(Hour arg)
        {
            return (int)arg.Value;
        }
        // Provides string conversion (avoids boxing).
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
