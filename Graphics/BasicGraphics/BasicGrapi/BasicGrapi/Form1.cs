using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BasicGrapi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            
            //Posicionando controles
            //PointF --> usa float em vez de int
            button1.Location = new Point(10, 10);

            //button1.Left = 10;
            //button1.Top = 10;

            //Dimensionamento dos controles
            button1.Size = new Size(60, 50);

            //Cores
            //button1.ForeColor = Color.Red;
            //button1.BackColor = Color.Blue;

            //Cores usando RGB
            button1.ForeColor = Color.FromArgb(10, 200, 200);
            button1.BackColor = Color.FromArgb(200, 5, 5);

        }
    }
}