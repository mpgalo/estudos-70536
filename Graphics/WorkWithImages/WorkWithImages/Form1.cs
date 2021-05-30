using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace WorkWithImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Imagem em pictureBox
            //Image b = Image.FromFile(@"C:\Documents and Settings\Note-Marcus\Meus documentos\Minhas imagens\IMG0003A.jpg");
            //Bitmap b = new Bitmap(@"C:\Documents and Settings\Note-Marcus\Meus documentos\Minhas imagens\IMG0003A.jpg");
            //pictureBox1.Image = b;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = null;
            Bitmap bm = new Bitmap(@"C:\Documents and Settings\Note-Marcus\Meus documentos\Minhas imagens\IMG0003A.jpg");
            Graphics g = this.CreateGraphics();
            g.DrawImage(bm, 1, 1, this.Width, this.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(600, 600);
            Graphics g = Graphics.FromImage(bm);

            Brush b = new LinearGradientBrush(new Point(1, 1), new Point(600, 600),
                Color.White, Color.Red);

            Point[] points = new Point[]
                {new Point(10, 10),
                new Point(77, 500),
                new Point(590, 100),
                new Point(250, 590),
                new Point(300, 410)};

            g.FillPolygon(b, points);
            bm.Save("bm.jpg", ImageFormat.Jpeg);
            bm.Dispose();
            g.Dispose();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawIcon(SystemIcons.Question, 40, 40);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)Image.FromFile("bm.jpg");
            Bitmap bmUpdated = new Bitmap(bm.Width, bm.Height);

            Graphics g = Graphics.FromImage(bmUpdated);

            Brush b = new LinearGradientBrush(new Point(1, 1), new Point(600, 600),
                Color.White, Color.Green);
            g.DrawImage(bm, new Rectangle(0, 0, bm.Width, bm.Height));

            bm.Dispose();          


            g.DrawString("TESTE", SystemFonts.DefaultFont, b, new Point(10, 10));


            bmUpdated.Save("bm.jpg", ImageFormat.Jpeg);
            bmUpdated.Dispose();
            g.Dispose();


        }
    }
}