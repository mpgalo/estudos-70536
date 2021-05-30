using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace CompressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CompressFile(@"c:\teste.txt", @"c:\teste.gz");
            UncompressFile(@"c:\teste.gz", @"c:\teste.txt");
        }

        static void CompressFile(string inFilename, string outFilename)
        {
            FileStream sourceFile = File.Open(inFilename, FileMode.Open);
            FileStream destFile = File.Create(outFilename);
            GZipStream compStream = new GZipStream(destFile, CompressionMode.Compress);

            //Ler byte a byte
            //int theByte = sourceFile.ReadByte();
            //while (theByte != -1)
            //{
            //    compStream.WriteByte((byte)theByte);
            //    theByte = sourceFile.ReadByte();
            //}

            //Ler todos de uma vez compactar desta forma temos uma maior taxa de compressão
            byte[] byteBuffer = new byte[sourceFile.Length];
            sourceFile.Read(byteBuffer, 0, (int)sourceFile.Length);
            compStream.Write(byteBuffer, 0, byteBuffer.Length);

            compStream.Close();
            destFile.Close();
            sourceFile.Close();
          
        }

        static void UncompressFile(string inFilename, string outFilename)
        {
            FileStream sourceFile = File.Open(inFilename, FileMode.Open);
            FileStream destFile = File.Create(outFilename);
            GZipStream compStream = new GZipStream(sourceFile, CompressionMode.Decompress);

            int theByte = compStream.ReadByte();
            while (theByte != -1)
            {
                destFile.WriteByte((byte)theByte);
                theByte = compStream.ReadByte();
            }

            compStream.Close();
            destFile.Close();
            sourceFile.Close();
        }
    }
}
