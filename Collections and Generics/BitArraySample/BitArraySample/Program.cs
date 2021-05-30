using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BitArraySample
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray bits = new BitArray(3);
            bits[0] = false;
            bits[1] = true;
            bits[2] = false;
            //Redimensiona array de bits
            bits.Length = 2;

            BitArray moreBits = new BitArray(3);
            moreBits[0] = true;
            moreBits[1] = true;
            moreBits[2] = false;
            //Redimensiona array de bits
            moreBits.Length = 2;
           

            BitArray xorBits = bits.Xor(moreBits); // Permite Operações logicas desde que ambos arrays possuam mesmo numero de itens

            foreach (bool bit in xorBits)
            {
                Console.WriteLine(bit);
            }

        }
    }
}
