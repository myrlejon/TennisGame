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
            ButtonHandler(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonHandler(2);
        }

        private void ButtonHandler(int player)
        {
            GameScore(player);

            bool win = WinCondition(player);

            if (win)
            {
                SetScore(player);
            }
            // AdvantageHandler()
        }

        public void GameScore(int player)
        {
            if (player == 1)
            {
                PlayerOneScoreCounter++;
                PlayerOneGameCounter++;
                player1Score.Text = PlayerOneScoreCounter.ToString();
                foreach (var key in Scores)
                {
                    if (key.Value == PlayerOneGameCounter)
                    {
                        player1ScoreString.Text = key.Key;
                    }
                }
            }
            else if (player == 2)
            {
                PlayerTwoScoreCounter++;
                PlayerTwoGameCounter++;
                player2Score.Text = PlayerTwoScoreCounter.ToString();
                foreach (var key in Scores)
                {
                    if (key.Value == PlayerTwoGameCounter)
                    {
                        player2ScoreString.Text = key.Key;
                    }
                }
            }
        }

        public void SetScore(int player)
        {
            PlayerOneGameCounter = 0;
            PlayerTwoGameCounter = 0;
            player1ScoreString.Text = "Love";
            player2ScoreString.Text = "Love";

            if (player == 1)
            {
                PlayerOneSetCounter++;
                player1SetsWon.Text = PlayerOneSetCounter.ToString();
            }
            else if (player == 2)
            {
                PlayerTwoSetCounter++;
                player2SetsWon.Text = PlayerTwoSetCounter.ToString();
            }
        }

        public bool WinCondition(int player)
        {
            bool win = false;

            GetPlayerProperties(player, out int playerGameCounter, out int playerScoreCounter, 
                                out int playerSetCounter, out int opponentGameCounter);

            // TODO: Håll dig till DRY principer, eftersom game conditions är samma, flytta dom till en metod.
            // Player 1 win conditions
            if (playerGameCounter == 4 && playerGameCounter - 1 > opponentGameCounter)
            {
                winLabel.Text = "Player " + player.ToString() + " wins!";
                win = true;
            }
            else if (playerGameCounter >= 3 && opponentGameCounter >= 3 && playerGameCounter > opponentGameCounter + 1)
            {
                winLabel.Text = "Player " + player.ToString() + " wins!";
                win = true;
            }
            // TODO: Lägg till "Douce"
            return win;
        }

        // Denna metod bestämmer vilken spelare det är som ska få poäng.
        public void GetPlayerProperties(int player, out int playerGameCounter, out int playerScoreCounter,
                                        out int playerSetCounter, out int opponentGameCounter)
        {
            playerGameCounter = new();
            playerScoreCounter = new();
            playerSetCounter = new();
            
            opponentGameCounter = new();
            if (player == 1)
            {
                playerGameCounter = PlayerOneGameCounter;
                playerScoreCounter = PlayerOneScoreCounter;
                playerSetCounter = PlayerOneSetCounter;
                opponentGameCounter = PlayerTwoGameCounter;
            }
            else if (player == 2)
            {
                playerGameCounter = PlayerTwoGameCounter;
                playerScoreCounter = PlayerTwoScoreCounter;
                playerSetCounter = PlayerTwoSetCounter;
                opponentGameCounter = PlayerOneGameCounter;
            }
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
