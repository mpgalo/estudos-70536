using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace CompressingFilesAndText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ComprimirTexto(string textoOriginal)
        {
            //Transforma o texto indicado em um array de bytes
            byte[] arrBytesTextoOriginal = System.Text.Encoding.UTF8.GetBytes(textoOriginal);
            //Recebe o array de bytes comprimido
            byte[] arrBytesTextoComprimido = null;
            //Stream em memória utilizado pela classe DeflateStream
            System.IO.MemoryStream memStream = new MemoryStream();
            //Utilizado apenas para compor mensagem sobre compressão
            StringBuilder sbMensagem = new StringBuilder();
            //Variavel usada para calculo da taxa de compressão
            int taxaCompressao = 0;
            //Instancia a classe DeflateStream, usada para compressão
            DeflateStream deflate = new DeflateStream(memStream, CompressionMode.Compress);
            //Efetua a compressao e escreve o resultado no MemoryStream
            deflate.Write(arrBytesTextoOriginal, 0, arrBytesTextoOriginal.Length);
            //Retorna um array de bytes comprimido, usaremos para calcular a taxa de compressão
            arrBytesTextoComprimido = memStream.ToArray();           
            taxaCompressao = (100 - (arrBytesTextoComprimido.Length * 100 / arrBytesTextoOriginal.Length));
            //Monta a mensagem e exibe no label
            sbMensagem.AppendFormat("Tamanho em bytes do texto original: {0} / ", arrBytesTextoOriginal.Length);
            sbMensagem.AppendFormat("Tamanho em bytes do texto Comprimido: {0} / ", arrBytesTextoComprimido.Length);
            sbMensagem.AppendFormat("Taxa de compressão: {0}%", taxaCompressao);

            lblInformacoesCompressao.Text = sbMensagem.ToString();

            //Fecha os streams e destroi os objetos
            deflate.Close();
            deflate.Dispose();
            deflate = null;
            memStream.Close();
            memStream.Dispose();
            memStream = null;


        }

        private void ComprimirArquivo(string caminhoArquivoOriginal,string caminhoArquivoDestino)
        {
            //Stream do arquivo de origem
            FileStream streamOrigem = File.Open(caminhoArquivoOriginal, FileMode.Open);
            //Stream do arquivo de destino
            FileStream streamDestino = File.Create(caminhoArquivoDestino);
            //Instancia da classe de compressão passando stream onde o arquivo será escrito comprimido
            GZipStream compressor = new GZipStream(streamDestino, CompressionMode.Compress);
            //Cria o array de bytes a partir do arquivo oriinal
            byte[] byteBuffer = new byte[streamOrigem.Length];
            //Le o conteudo do arquivo de origem e coloca no array
            streamOrigem.Read(byteBuffer, 0, (int)streamOrigem.Length);
            //Comprime o array de bytes
            compressor.Write(byteBuffer, 0, byteBuffer.Length);
            //Destroi os objetos da memória
            streamOrigem.Close();
            streamOrigem.Dispose();
            streamOrigem = null;            
            compressor.Close();
            compressor.Dispose();
            compressor = null;
            streamDestino.Close();
            streamDestino.Dispose();
            streamDestino = null;
            byteBuffer = null;
            //Exibe a mensagem de aviso
            lblInformacoesCompressao.Text = "Arquivo comprimido com sucesso";

        }

        private void DescomprimirArquivo(string caminhoArquivoComprimido, string caminhoArquivoDescomprimido)
        {
            //Stream do arquivo comprimido aberto para leitura
            FileStream streamOrigem = File.OpenRead(caminhoArquivoComprimido);
            //Stream do arquivo resultado
            FileStream streamDestino = File.Create(caminhoArquivoDescomprimido);
            //Efetua a descompressão
            GZipStream descompressor = new GZipStream(streamOrigem, CompressionMode.Decompress);
            //Tamanho do buffer
            int tamanhoBuffer = 4096;
            int leitura = 1;
            //Armazena o byte lido do arquivo
            byte[] arrayBytes = new byte[tamanhoBuffer];
            //Faz a leitura dos bytes e escreve no arquivo descomprimido
            while (leitura > 0)
            {
                //A variavel leitura armazena a quantidade de butes lidos do arquivo
                leitura = descompressor.Read(arrayBytes, 0, tamanhoBuffer);
                //Escreve os bytes lidos do arquivo em um novo arquivo
                streamDestino.Write(arrayBytes, 0, leitura);
            }

            //Destroi os objetos da memoria
            streamOrigem.Close();
            streamOrigem.Dispose();
            streamOrigem = null;
            streamDestino.Close();
            streamDestino.Dispose();
            streamDestino = null;
            descompressor.Close();
            descompressor.Dispose();
            descompressor = null;
            arrayBytes = null;
            //Exibe a mensagem de descompressão
            lblInformacoesCompressao.Text = "Arquivo descomprimido com sucesso em " + caminhoArquivoDescomprimido;

        }

        private void cmdComprimirTexto_Click(object sender, EventArgs e)
        {
            this.ComprimirTexto(txtTextoOriginal.Text);
        }

        private void cmdComprimir_Click(object sender, EventArgs e)
        {
            string arqOrigem = txtArqOriComprimir.Text;
            string arqDestino = txtArqDestinoComprimir.Text;
            //Se o arquivo de origem não existir, cancela o processo
            if (!File.Exists(arqOrigem))
            {
                MessageBox.Show("Arquivo Inexistente");
                arqOrigem = null;
            }

            if (arqOrigem != null)
            {
                this.ComprimirArquivo(arqOrigem, arqDestino);
            }
        }

        private void cmdDescomprimir_Click(object sender, EventArgs e)
        {
            string arqComprimido = txtArqComprimido.Text;
            string arqFinal = txtArquivoFinal.Text;
            //Se o arquivo de origem não existir, cancela o processo
            if (!File.Exists(arqComprimido))
            {
                MessageBox.Show("Arquivo Inexistente");
                arqComprimido = null;
            }

            if (arqComprimido != null)
            {
                this.DescomprimirArquivo(arqComprimido, arqFinal);
            }
        }
    }
}