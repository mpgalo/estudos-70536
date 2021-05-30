using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EncodingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pegando em Bytes os caracteres de um determinado formato
            Encoding e = Encoding.GetEncoding("Korean");
            // Convert ASCII bytes to Korean encoding
            byte[] encoded;
            encoded = e.GetBytes("Hello, world!");
            // Display the byte codes
            for (int i = 0; i < encoded.Length; i++)
                Console.WriteLine("Byte {0}: {1}", i, encoded[i]);

            //Mostrando os formatos suportados
            EncodingInfo[] ei = Encoding.GetEncodings();
            foreach (EncodingInfo en in ei)
                Console.WriteLine("{0}: {1}, {2}", en.CodePage, en.Name, en.DisplayName);

            //Criando arquivos com determinado formato especificado
            StreamWriter swUtf7 = new StreamWriter(@"c:\utf7.txt", false, Encoding.UTF7);
            swUtf7.WriteLine("Hello, World!");
            swUtf7.Close();
            StreamWriter swUtf8 = new StreamWriter(@"c:\utf8.txt", false, Encoding.UTF8);
            swUtf8.WriteLine("Hello, World!");
            swUtf8.Close();
            StreamWriter swUtf16 = new StreamWriter(@"c:\utf16.txt", false, Encoding.Unicode);
            swUtf16.WriteLine("Hello, World!");
            swUtf16.Close();
            StreamWriter swUtf32 = new StreamWriter(@"c:\utf32.txt", false, Encoding.UTF32);
            swUtf32.WriteLine("Hello, World!");
            swUtf32.Close();


            //Ler arquivos em determinados Formatods
            string fn = @"c:\utf7.txt";
           
            StreamReader sr = new StreamReader(fn, Encoding.UTF7);//Como o arquivo foi criado em UTF7, ao fazer a leitura devemos especificar
            //o encoding senao exibira o texto de forma incorreta
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }
    }
}
