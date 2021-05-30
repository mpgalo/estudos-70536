namespace Cards
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
            this.east = new System.Windows.Forms.TextBox();
            this.west = new System.Windows.Forms.TextBox();
            this.south = new System.Windows.Forms.TextBox();
            this.north = new System.Windows.Forms.TextBox();
            this.returnToPack = new System.Windows.Forms.Button();
            this.Deal = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
// 
// east
// 
            this.east.Location = new System.Drawing.Point(362, 36);
            this.east.Multiline = true;
            this.east.Name = "east";
            this.east.Size = new System.Drawing.Size(96, 184);
            this.east.TabIndex = 6;
// 
// west
// 
            this.west.Location = new System.Drawing.Point(248, 36);
            this.west.Multiline = true;
            this.west.Name = "west";
            this.west.Size = new System.Drawing.Size(96, 184);
            this.west.TabIndex = 7;
// 
// south
// 
            this.south.Location = new System.Drawing.Point(134, 36);
            this.south.Multiline = true;
            this.south.Name = "south";
            this.south.Size = new System.Drawing.Size(96, 184);
            this.south.TabIndex = 8;
// 
// north
// 
            this.north.Location = new System.Drawing.Point(20, 36);
            this.north.Multiline = true;
            this.north.Name = "north";
            this.north.Size = new System.Drawing.Size(96, 184);
            this.north.TabIndex = 5;
// 
// returnToPack
// 
            this.returnToPack.Location = new System.Drawing.Point(248, 238);
            this.returnToPack.Name = "returnToPack";
            this.returnToPack.Size = new System.Drawing.Size(96, 23);
            this.returnToPack.TabIndex = 4;
            this.returnToPack.Text = "Return to pack";
            this.returnToPack.Click += new System.EventHandler(this.returnToPack_Click);
// 
// Deal
// 
            this.Deal.Location = new System.Drawing.Point(134, 238);
            this.Deal.Name = "Deal";
            this.Deal.Size = new System.Drawing.Size(96, 23);
            this.Deal.TabIndex = 3;
            this.Deal.Text = "Deal";
            this.Deal.Click += new System.EventHandler(this.Deal_Click);
// 
// label4
// 
            this.label4.Location = new System.Drawing.Point(362, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "East";
// 
// label3
// 
            this.label3.Location = new System.Drawing.Point(248, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "West";
// 
// label2
// 
            this.label2.Location = new System.Drawing.Point(134, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "South";
// 
// label1
// 
            this.label1.Location = new System.Drawing.Point(20, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "North";
// 
// Form1
// 
            this.ClientSize = new System.Drawing.Size(480, 273);
            this.Controls.Add(this.east);
            this.Controls.Add(this.west);
            this.Controls.Add(this.south);
            this.Controls.Add(this.north);
            this.Controls.Add(this.returnToPack);
            this.Controls.Add(this.Deal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Card Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox east;
        private System.Windows.Forms.TextBox west;
        private System.Windows.Forms.TextBox south;
        private System.Windows.Forms.TextBox north;
        private System.Windows.Forms.Button returnToPack;
        private System.Windows.Forms.Button Deal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

