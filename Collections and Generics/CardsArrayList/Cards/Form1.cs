#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Cards
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Pack pack = new Pack();
        private Game game = new Game();

        private void Deal_Click(object sender, System.EventArgs e)
        {
            pack.Shuffle();
            Dealer.Deal(pack, game);
            DoRefresh();
        }

        private void returnToPack_Click(object sender, System.EventArgs e)
        {
            game.ReturnHandsTo(pack);
            DoRefresh();
        }

        private void DoRefresh()
        {
            north.Text = game.North().ToString();
            south.Text = game.South().ToString();
            west.Text = game.West().ToString();
            east.Text = game.East().ToString();
        }

        private void shuffle_Click(object sender, System.EventArgs e)
        {
            pack.Shuffle();
        }
    }
}