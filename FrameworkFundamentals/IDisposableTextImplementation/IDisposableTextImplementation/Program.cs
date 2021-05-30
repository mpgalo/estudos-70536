using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace IDisposableTextImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Usando using automaticamente após o escopo, é chamado o método Dispose()
            //Pois class implementa IDisposable
            using (ExampleDispose example = new ExampleDispose(@"C:\teste.txt"))
            {
                example.Read();
            }
           
        }
    }

    class ExampleDispose : IDisposable
    {
        string path;
        FileStream fileStream;
        StreamReader reader;

        public ExampleDispose(string caminho)
        {
            this.path = caminho;
        }

        ~ExampleDispose()
        {
            //Ao executar o Gc realizará o dispose do objeto
            this.Dispose();
        }

        public void Read()
        {
            fileStream = File.Open(path, FileMode.Open);
            reader = new StreamReader(fileStream);
            Console.WriteLine(reader.ReadToEnd());
        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {                
                fileStream.Close();
                reader.Close();
                path = null;
            }
            finally
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}
