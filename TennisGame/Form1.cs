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
        private Dictionary<string, int> Scores { get; set; }

        public Form1()
        {
            Scores = new Dictionary<string, int>()
            {
                {"Love", 0},
                {"Fifteen", 1},
                {"Thirty", 2},
                {"Forty", 3}
            };

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerOneScoreCounter = ButtonHandler(PlayerOneScoreCounter, player1Score, player1ScoreString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayerTwoScoreCounter = ButtonHandler(PlayerTwoScoreCounter, player2Score, player2ScoreString);
        }

        private int ButtonHandler(int counter, Label playerScore, Label playerScoreString)
        {
            counter++;
            playerScore.Text = counter.ToString();
            foreach (var key in Scores)
            {
                if (key.Value == counter)
                {
                    playerScoreString.Text = key.Key;
                }
            }
            return counter;
        } 
    }
}
