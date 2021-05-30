using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Graphics g = this.CreateGraphics();
            // Construct a new Rectangle.
            Rectangle r = new Rectangle(new Point(40, 40), new Size(80, 80));
            // Construct 2 new StringFormat objects
            StringFormat f1 = new StringFormat(StringFormatFlags.NoClip);
            StringFormat f2 = new StringFormat(f1);
            // Set the LineAlignment and Alignment properties for
            // both StringFormat objects to different values.
            f1.LineAlignment = StringAlignment.Near;
            f1.Alignment = StringAlignment.Center;
            f2.LineAlignment = StringAlignment.Center;
            f2.Alignment = StringAlignment.Far;
            f2.FormatFlags = StringFormatFlags.DirectionVertical;
            // Draw the bounding rectangle and a string for each
            // StringFormat object.
            g.DrawRectangle(Pens.Black, r);
            Font f = new Font("Arial", 10, FontStyle.Bold);
            g.DrawString("Format1", f, Brushes.Red, (RectangleF)r, f1);
            g.DrawString("Format2", f, Brushes.Red, (RectangleF)r, f2);
        }
    }
}