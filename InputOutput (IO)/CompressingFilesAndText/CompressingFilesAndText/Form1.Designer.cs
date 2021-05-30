namespace CompressingFilesAndText
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTextoOriginal = new System.Windows.Forms.TextBox();
            this.cmdComprimirTexto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArqOriComprimir = new System.Windows.Forms.TextBox();
            this.txtArqDestinoComprimir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdComprimir = new System.Windows.Forms.Button();
            this.cmdDescomprimir = new System.Windows.Forms.Button();
            this.txtArquivoFinal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtArqComprimido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInformacoesCompressao = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compressão de texto :";
            // 
            // txtTextoOriginal
            // 
            this.txtTextoOriginal.Location = new System.Drawing.Point(15, 26);
            this.txtTextoOriginal.Multiline = true;
            this.txtTextoOriginal.Name = "txtTextoOriginal";
            this.txtTextoOriginal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTextoOriginal.Size = new System.Drawing.Size(733, 170);
            this.txtTextoOriginal.TabIndex = 1;
            // 
            // cmdComprimirTexto
            // 
            this.cmdComprimirTexto.Location = new System.Drawing.Point(341, 202);
            this.cmdComprimirTexto.Name = "cmdComprimirTexto";
            this.cmdComprimirTexto.Size = new System.Drawing.Size(75, 23);
            this.cmdComprimirTexto.TabIndex = 2;
            this.cmdComprimirTexto.Text = "Comprimir";
            this.cmdComprimirTexto.UseVisualStyleBackColor = true;
            this.cmdComprimirTexto.Click += new System.EventHandler(this.cmdComprimirTexto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Compressão de Arquivos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdComprimir);
            this.groupBox1.Controls.Add(this.txtArqDestinoComprimir);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtArqOriComprimir);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 166);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comprimir";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdDescomprimir);
            this.groupBox2.Controls.Add(this.txtArquivoFinal);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtArqComprimido);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(385, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 166);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descomprimir";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Arquivo original:";
            // 
            // txtArqOriComprimir
            // 
            this.txtArqOriComprimir.Location = new System.Drawing.Point(94, 31);
            this.txtArqOriComprimir.Name = "txtArqOriComprimir";
            this.txtArqOriComprimir.Size = new System.Drawing.Size(263, 20);
            this.txtArqOriComprimir.TabIndex = 7;
            // 
            // txtArqDestinoComprimir
            // 
            this.txtArqDestinoComprimir.Location = new System.Drawing.Point(94, 73);
            this.txtArqDestinoComprimir.Name = "txtArqDestinoComprimir";
            this.txtArqDestinoComprimir.Size = new System.Drawing.Size(263, 20);
            this.txtArqDestinoComprimir.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Arq. Comprimido:";
            // 
            // cmdComprimir
            // 
            this.cmdComprimir.Location = new System.Drawing.Point(282, 99);
            this.cmdComprimir.Name = "cmdComprimir";
            this.cmdComprimir.Size = new System.Drawing.Size(75, 23);
            this.cmdComprimir.TabIndex = 6;
            this.cmdComprimir.Text = "Comprimir";
            this.cmdComprimir.UseVisualStyleBackColor = true;
            this.cmdComprimir.Click += new System.EventHandler(this.cmdComprimir_Click);
            // 
            // cmdDescomprimir
            // 
            this.cmdDescomprimir.Location = new System.Drawing.Point(248, 106);
            this.cmdDescomprimir.Name = "cmdDescomprimir";
            this.cmdDescomprimir.Size = new System.Drawing.Size(109, 23);
            this.cmdDescomprimir.TabIndex = 11;
            this.cmdDescomprimir.Text = "Descomprimir";
            this.cmdDescomprimir.UseVisualStyleBackColor = true;
            this.cmdDescomprimir.Click += new System.EventHandler(this.cmdDescomprimir_Click);
            // 
            // txtArquivoFinal
            // 
            this.txtArquivoFinal.Location = new System.Drawing.Point(94, 80);
            this.txtArquivoFinal.Name = "txtArquivoFinal";
            this.txtArquivoFinal.Size = new System.Drawing.Size(263, 20);
            this.txtArquivoFinal.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Arquivo Final:";
            // 
            // txtArqComprimido
            // 
            this.txtArqComprimido.Location = new System.Drawing.Point(94, 38);
            this.txtArqComprimido.Name = "txtArqComprimido";
            this.txtArqComprimido.Size = new System.Drawing.Size(263, 20);
            this.txtArqComprimido.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Arq. Comprimido:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblInformacoesCompressao);
            this.panel1.Location = new System.Drawing.Point(13, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 80);
            this.panel1.TabIndex = 6;
            // 
            // lblInformacoesCompressao
            // 
            this.lblInformacoesCompressao.AutoSize = true;
            this.lblInformacoesCompressao.ForeColor = System.Drawing.Color.Red;
            this.lblInformacoesCompressao.Location = new System.Drawing.Point(7, 7);
            this.lblInformacoesCompressao.Name = "lblInformacoesCompressao";
            this.lblInformacoesCompressao.Size = new System.Drawing.Size(163, 13);
            this.lblInformacoesCompressao.TabIndex = 0;
            this.lblInformacoesCompressao.Text = "Informações sobre a compressão";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdComprimirTexto);
            this.Controls.Add(this.txtTextoOriginal);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Compressão de Dados em .NET 2.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTextoOriginal;
        private System.Windows.Forms.Button cmdComprimirTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtArqOriComprimir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdComprimir;
        private System.Windows.Forms.TextBox txtArqDestinoComprimir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdDescomprimir;
        private System.Windows.Forms.TextBox txtArquivoFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtArqComprimido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInformacoesCompressao;
    }
}

