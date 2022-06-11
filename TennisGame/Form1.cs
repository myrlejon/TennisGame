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
        // score counter = alla, gamecounter = 0-4 
        private int PlayerOneScoreCounter { get; set; }
        private int PlayerTwoScoreCounter { get; set; }
        private int PlayerOneGameCounter { get; set; }
        private int PlayerTwoGameCounter { get; set; }
        private int PlayerOneSetCounter { get; set; }
        private int PlayerTwoSetCounter { get; set; }
        private Dictionary<string, int> Scores { get; set; }

        public Form1()
        {
            Scores = new Dictionary<string, int>()
            {
                {"Love", 0},
                {"Fifteen", 1},
                {"Thirty", 2},
                {"Forty", 3},
                {"Game", 4 }
            };

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerOneGameCounter = ButtonHandler(PlayerOneScoreCounter, PlayerOneGameCounter, PlayerOneSetCounter,
                player1SetsWon, player1Score, player2Score, player1ScoreString, player2ScoreString, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayerTwoGameCounter = ButtonHandler(PlayerTwoScoreCounter, PlayerTwoGameCounter, PlayerTwoSetCounter,
                player2SetsWon, player2Score, player1Score, player2ScoreString, player1ScoreString, 2);
        }

        private int ButtonHandler(int scoreCounter, int gamesCounter, int setsWon, Label playerSetsWon, Label playerScore, 
            Label opponentScore, Label playerScoreString, Label opponentScoreString, int player)
        {
            scoreCounter++;
            gamesCounter++;
            playerScore.Text = gamesCounter.ToString();
            int playerScoreInt = Convert.ToInt32(playerScore.Text);
            int opponentScoreInt = Convert.ToInt32(opponentScore.Text);

            foreach (var key in Scores)
            {
                if (key.Value == gamesCounter)
                {
                    playerScoreString.Text = key.Key;
                }
            }

            bool win = WinCondition(playerScoreInt, opponentScoreInt, player);

            if (win == true)
            {
                PlayerOneGameCounter = 0;
                PlayerTwoGameCounter = 0;
                gamesCounter = 0;
                setsWon++;
                //playerScore.Text = "0";
                //opponentScore.Text = "0";
                playerScoreString.Text = "Love";
                opponentScoreString.Text = "Love";
                playerSetsWon.Text = setsWon.ToString(); 
            }

            return gamesCounter;
            // AdvantageHandler()
        }

        public bool WinCondition(int playerScore, int opponentScore, int player)
        {
            bool win = false;
            if (playerScore == 4 && playerScore - 1 > opponentScore)
            {
                winLabel.Text = "Player " + player.ToString() + " wins!";
                win = true;
            }
            else if (playerScore > 3 && opponentScore > 3 && playerScore > opponentScore + 1)
            {
                winLabel.Text = "Player " + player.ToString() + " wins!";
                win = true;
            }
            return win;
        }
        
        //private void AdvantageHandler()
        //{
        //    // Överskriver värdet ifall spelaren leder
        //    if (playerScoreInt > opponentScoreInt)
        //    {
        //        playerScoreString.Text = "Advantage";
        //    }
        //    else if (playerScoreInt < opponentScoreInt)
        //    {
        //        opponentScoreString.Text = "Advantage";
        //    }
        //}
    }
}
