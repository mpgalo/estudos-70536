using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LeituraDeArquivo
{
    class Program
    {
        static void Main(string[] args)
        {

            //FileStream file = File.Open(@"C:\boot.ini", FileMode.Open, FileAccess.Read);            
            //StreamReader rdr = new StreamReader(file);            
            //Console.WriteLine(rdr.ReadToEnd());
            string i = File.ReadAllText(@"C:\boot.ini");
            Console.WriteLine(i);

            ////DumpStream(file);            
            //rdr.Close();
            //file.Close();

            //rdr = File.OpenText(@"C:\boot.ini");
            //Console.WriteLine(rdr.ReadToEnd());
            ////DumpStream(file);
            //rdr.Close();
            //file.Close();



            
            StreamReader rdr = File.OpenText(@"C:\boot.ini");
            
            while (!rdr.EndOfStream)
            {
                //Le cada linha separadamente
                string line = rdr.ReadLine();
                //Imprime o valor da linha na tela (Se tiver usando console Application)
                Console.WriteLine(line);
            }

            rdr.Close();



        }

        static void DumpStream(Stream theStream)
        {
            // Move the stream's position to the beginning
            theStream.Position = 0;
            // Go through entire stream and show the contents
            while (theStream.Position != theStream.Length)
            {
                Console.WriteLine("{0:x2}", theStream.ReadByte());
            }
        }
    }
}
