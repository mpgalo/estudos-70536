using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace DrawingShapes
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

            // Create a graphics object from the form
            Graphics g = this.CreateGraphics();
            //Clear the previous image draw in the form
            g.Clear(this.BackColor);
            // Create a pen object with which to draw
            Pen p = new Pen(Color.Red, 7);
            // Draw the line
            g.DrawLine(p, 1, 1, 100, 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a graphics object from the form
            Graphics g = this.CreateGraphics();
            //Clear the previous image draw in the form
            g.Clear(this.BackColor);
            // Create a pen object with which to draw
            Pen p = new Pen(Color.Blue, 3);
            // Draw the pie
            //Can use Pens.Blue
            g.DrawPie(p, 1, 1, 100, 100, -30, 60);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Create a graphics object from the form
            Graphics g = this.CreateGraphics();
            //Clear the previous image draw in the form
            g.Clear(this.BackColor);

            // Create an array of points
            Point[] points = new Point[]{new Point(10, 10),
                new Point(10, 100),
                new Point(50, 65),
                new Point(100, 100),
                new Point(85, 40)};

            Pen p = new Pen(Color.MediumPurple, 2);
            // Draw a shape defined by the array of points
            g.DrawPolygon(p, points);



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Pen p = new Pen(Color.Red, 7);
            p.DashStyle = DashStyle.Dot;
            g.DrawLine(p, 50, 25, 400, 25);
            p.DashStyle = DashStyle.Dash;
            g.DrawLine(p, 50, 50, 400, 50);
            p.DashStyle = DashStyle.DashDot;
            g.DrawLine(p, 50, 75, 400, 75);
            p.DashStyle = DashStyle.DashDotDot;
            g.DrawLine(p, 50, 100, 400, 100);
            p.DashStyle = DashStyle.Solid;
            g.DrawLine(p, 50, 125, 400, 125);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Pen p = new Pen(Color.Red, 7);

            p.StartCap = LineCap.ArrowAnchor;
            p.EndCap = LineCap.ArrowAnchor;
            p.DashStyle = DashStyle.Dot;
            g.DrawLine(p, 50, 25, 400, 25);

            p.StartCap = LineCap.SquareAnchor;
            p.EndCap = LineCap.SquareAnchor;
            p.DashStyle = DashStyle.Dash;
            g.DrawLine(p, 50, 50, 400, 50);

            p.StartCap = LineCap.DiamondAnchor;
            p.EndCap = LineCap.DiamondAnchor;
            p.DashStyle = DashStyle.DashDot;
            g.DrawLine(p, 50, 75, 400, 75);

            p.StartCap = LineCap.Triangle;
            p.EndCap = LineCap.Triangle;
            p.DashStyle = DashStyle.DashDotDot;
            g.DrawLine(p, 50, 100, 400, 100);

            p.StartCap = LineCap.RoundAnchor;
            p.EndCap = LineCap.NoAnchor;
            p.DashStyle = DashStyle.Solid;
            g.DrawLine(p, 50, 125, 400, 125);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            // Create a graphics object from the form
            Graphics g = this.CreateGraphics();
            //Clear the previous image draw in the form
            g.Clear(this.BackColor);

            // Create an array of points
            Point[] points = new Point[]{new Point(10, 10),
                new Point(10, 100),
                new Point(50, 65),
                new Point(100, 100),
                new Point(85, 40)};

            Brush b = new SolidBrush(Color.Maroon);
            // Fill a shape defined by the array of points
            g.FillPolygon(b, points);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            // Create a graphics object from the form
            Graphics g = this.CreateGraphics();
            //Clear the previous image draw in the form
            g.Clear(this.BackColor);

            // Create an array of points
            Point[] points = new Point[]{new Point(10, 10),
                new Point(10, 100),
                new Point(50, 65),
                new Point(100, 100),
                new Point(85, 40)};

            Brush b = new LinearGradientBrush(new Point(1, 1), new Point(100, 100),
                Color.White, Color.Red);

            Pen p = new Pen(Color.Maroon, 2);
            // Fill a shape defined by the array of points
            g.FillPolygon(b, points);
            //Create the shape border based on Pen definitions
            g.DrawPolygon(p, points);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Create a graphics object from the form
            Graphics g = this.CreateGraphics();
            //Clear the previous image draw in the form
            g.Clear(this.BackColor);

            // Create an array of points
            Point[] points = new Point[]{new Point(10, 10),
                new Point(10, 100),
                new Point(50, 65),
                new Point(100, 100),
                new Point(85, 40)};

            Brush b = new TextureBrush(Image.FromFile(@"C:\Documents and Settings\Note-Marcus\Meus documentos\Minhas imagens\PlanoFundoVsEditado.png"));
            Pen p = new Pen(Color.Maroon, 2);
            // Fill a shape defined by the array of points
            g.FillPolygon(b, points);
            //Create the shape border based on Pen definitions
            g.DrawPolygon(p, points);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Create a graphics object from the form
            Graphics g = this.CreateGraphics();
            //Clear the previous image draw in the form
            g.Clear(this.BackColor);

            // Create an array of points
            Point[] points = new Point[]{new Point(10, 10),
                new Point(10, 100),              
                new Point(100, 100),
                new Point(85, 40)};          

            PathGradientBrush b = new PathGradientBrush(points, WrapMode.Clamp);
            b.CenterColor = Color.Green;          

            Pen p = new Pen(Color.Maroon, 2);
            // Fill a shape defined by the array of points
            g.FillPolygon(b, points);
            //Create the shape border based on Pen definitions
            g.DrawPolygon(p, points);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Create a graphics object from the form
            Graphics g = this.CreateGraphics();
            //Clear the previous image draw in the form
            g.Clear(this.BackColor);

            // Create an array of points
            Point[] points = new Point[]{new Point(10, 10),
                new Point(10, 100),              
                new Point(100, 100),
                new Point(85, 40)};

            Brush b = new HatchBrush(HatchStyle.OutlinedDiamond, Color.Red, Color.Blue);
          
            Pen p = new Pen(Color.Maroon, 2);
            // Fill a shape defined by the array of points
            g.FillPolygon(b, points);
            //Create the shape border based on Pen definitions
            g.DrawPolygon(p, points);
        }
    }
}