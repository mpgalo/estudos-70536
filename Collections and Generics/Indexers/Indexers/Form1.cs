#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Indexers
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void findPhone_Click(object sender, System.EventArgs e)
        {
            string text = name.Text;
            if (!string.IsNullOrEmpty(text.Trim()))
            {                
                phoneNumber.Text = phoneBook[new Name(text)].Text;
            }
        }

        private void findName_Click(object sender, System.EventArgs e)
        {
            string text = phoneNumber.Text;
            if (!string.IsNullOrEmpty(text.Trim()))
            {
                name.Text = phoneBook[new PhoneNumber(text)].Text;
            }
        }

        private void add_Click(object sender, System.EventArgs e)
        {
            if (name.Text != "" && phoneNumber.Text != "")
            {
                phoneBook.Add(new Name(name.Text),
                              new PhoneNumber(phoneNumber.Text));
                name.Text = "";
                phoneNumber.Text = "";
            }
        }

        private PhoneBook phoneBook = new PhoneBook();
    }
}