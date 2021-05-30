namespace Indexers
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
            this.add = new System.Windows.Forms.Button();
            this.findName = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.phoneNumber = new System.Windows.Forms.TextBox();
            this.findPhone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
// 
// add
// 
            this.add.Location = new System.Drawing.Point(20, 74);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(56, 24);
            this.add.TabIndex = 13;
            this.add.Text = "Add";
            this.add.Click += new System.EventHandler(this.add_Click);
// 
// findName
// 
            this.findName.Location = new System.Drawing.Point(180, 50);
            this.findName.Name = "findName";
            this.findName.Size = new System.Drawing.Size(72, 24);
            this.findName.TabIndex = 12;
            this.findName.Text = "<-- Search";
            this.findName.Click += new System.EventHandler(this.findName_Click);
// 
// label2
// 
            this.label2.Location = new System.Drawing.Point(268, 18);
            this.label2.Name = "label2";
            this.label2.TabIndex = 11;
            this.label2.Text = "phone number";
// 
// phoneNumber
// 
            this.phoneNumber.Location = new System.Drawing.Point(268, 42);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(144, 20);
            this.phoneNumber.TabIndex = 10;
// 
// findPhone
// 
            this.findPhone.Location = new System.Drawing.Point(180, 26);
            this.findPhone.Name = "findPhone";
            this.findPhone.Size = new System.Drawing.Size(72, 23);
            this.findPhone.TabIndex = 9;
            this.findPhone.Text = "Search -->";
            this.findPhone.Click += new System.EventHandler(this.findPhone_Click);
// 
// label1
// 
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "name";
// 
// name
// 
            this.name.Location = new System.Drawing.Point(20, 42);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(144, 20);
            this.name.TabIndex = 7;
// 
// Form1
// 
            this.ClientSize = new System.Drawing.Size(432, 117);
            this.Controls.Add(this.add);
            this.Controls.Add(this.findName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.phoneNumber);
            this.Controls.Add(this.findPhone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name);
            this.Name = "Form1";
            this.Text = "Phone Book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button findName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox phoneNumber;
        private System.Windows.Forms.Button findPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
    }
}

