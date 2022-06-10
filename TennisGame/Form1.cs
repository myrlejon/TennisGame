using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TennisGame
{
    public partial class Form1 : Form
    {
        private int PlayerOneScoreCounter { get; set; }
        private int PlayerTwoScoreCounter { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerOneScoreCounter++;
            player1Score.Text = PlayerOneScoreCounter.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayerTwoScoreCounter++;
            player2Score.Text = PlayerTwoScoreCounter.ToString();
        }
    }
}
