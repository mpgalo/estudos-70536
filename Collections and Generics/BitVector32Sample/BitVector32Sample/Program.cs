using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace BitVector32Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            BitVector32 vector = new BitVector32(0);//Passo 0 para definir que todos os bits estarao como 0
            int firstBit = BitVector32.CreateMask();//Define q é o brimeiro Bit
            int secondBit = BitVector32.CreateMask(firstBit);
            int thirdBit = BitVector32.CreateMask(secondBit);

            vector[firstBit] = true;
            vector[secondBit] = true;

            Console.WriteLine(vector);

            Console.WriteLine("Em decimal: {0}", vector.Data);//Exibe o valor inteiro correspondente a soma dos bists ligados

            BitVector32 newVector = new BitVector32(4);
            bool bit1 = newVector[firstBit];
            bool bit2 = newVector[secondBit];
            bool bit3 = newVector[thirdBit];

            Console.WriteLine(newVector);
            // bit1 = false, bit2 = false, bit3 = true

            Console.WriteLine();

            BitVector32.Section firstSection = BitVector32.CreateSection(10);//Define que o primeiro numero a ser agrupado
            //no array de bits tem valor maximo de 10
            BitVector32.Section secondSection = BitVector32.CreateSection(50, firstSection);
            BitVector32.Section thirdSection =  BitVector32.CreateSection(500, secondSection);

            BitVector32 packedBits = new BitVector32(0);
            packedBits[firstSection] = 10;
            packedBits[secondSection] = 1;
            packedBits[thirdSection] = 192;
            Console.WriteLine(packedBits[firstSection]);
            Console.WriteLine(packedBits[secondSection]);
            Console.WriteLine(packedBits[thirdSection]);

            Console.WriteLine(packedBits.Data);            
            Console.WriteLine(packedBits);
        }
    }
}
