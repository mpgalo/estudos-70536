using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se você quiser converter para o codigo ascii...

            string texto = "teste";
            int[] asciiCodes = new int[texto.Length];
            for (int i = 0; i < texto.Length; i++)
            {
                asciiCodes[i] = (int)texto[i];
                Console.WriteLine(asciiCodes[i]);
            }

            string textoOriginal = string.Empty;
            char[] asciiStrCodes = new char[texto.Length];
            for (int i = 0; i < texto.Length; i++)
            {
                asciiStrCodes[i] = (char)asciiCodes[i];
                textoOriginal += ((char)asciiCodes[i]).ToString();
                //Imprime na tela uma letra de cada vez
                Console.WriteLine(asciiStrCodes[i]);
            }
            //Imprime na tela a palavra to já transformada novamente em letras
            Console.WriteLine(textoOriginal);

        }
    }
}
