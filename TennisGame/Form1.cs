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
        private bool DeuceBool { get; set; }
        private Dictionary<string, int> Scores { get; set; }

        public Form1()
        {
            Scores = new Dictionary<string, int>()
            {
                {"Love", 0},
                {"Fifteen", 1},
                {"Thirty", 2},
                {"Forty", 3},
                {"Deuce", 4 }
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
            // Avgör vilken spelare som får poäng
            GameScore(player);

            GetPlayerProperties(player, out int playerGameCounter, out int playerScoreCounter,
                    out int playerSetCounter, out int opponentGameCounter, out Label playerScore,
                    out Label playerScoreString);

            Deuce(player, playerGameCounter, opponentGameCounter);
            bool win = WinCondition(player);

            if (win)
            {
                SetScore(player);
            }
            // AdvantageHandler()
        }

        public void Deuce(int player, int playerGameCounter, int opponentGameCounter)
        {
            if (playerGameCounter >= 3 && opponentGameCounter >= 3 && playerGameCounter == opponentGameCounter)
            {
                player1ScoreString.Text = "Deuce";
                player2ScoreString.Text = "Deuce";
                DeuceBool = true;
            }
            if (DeuceBool && playerGameCounter > opponentGameCounter)
            {
                if (player == 1)
                {
                    player1ScoreString.Text = "Advantage";
                }
                else if (player == 2)
                {
                    player2ScoreString.Text = "Advantage";
                }
            }
            //if (DeuceBool && playerGameCounter == opponentGameCounter)
            //{
            //    player1ScoreString.Text = "Deuce";
            //    player2ScoreString.Text = "Deuce";
            //}
        }

        // TODO: Refaktorera för DRY principer.
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
            DeuceBool = false;
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
                                out int playerSetCounter, out int opponentGameCounter, out Label playerScore,
                                out Label playerScoreString);

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
            return win;
        }

        // Denna metod bestämmer vilken spelare det är som ska få poäng.
        public void GetPlayerProperties(int player, out int playerGameCounter, out int playerScoreCounter,
                                        out int playerSetCounter, out int opponentGameCounter, out Label playerScore,
                                        out Label playerScoreString)
        {
            playerGameCounter = new();
            playerScoreCounter = new();
            playerSetCounter = new();
            opponentGameCounter = new();
            playerScore = new();
            playerScoreString = new();

            if (player == 1)
            {
                playerGameCounter = PlayerOneGameCounter;
                playerScoreCounter = PlayerOneScoreCounter;
                playerSetCounter = PlayerOneSetCounter;
                opponentGameCounter = PlayerTwoGameCounter;
                playerScore = player1Score;
                playerScoreString = player1ScoreString;
            }
            else if (player == 2)
            {
                playerGameCounter = PlayerTwoGameCounter;
                playerScoreCounter = PlayerTwoScoreCounter;
                playerSetCounter = PlayerTwoSetCounter;
                opponentGameCounter = PlayerOneGameCounter;
                playerScore = player2Score;
                playerScoreString = player2ScoreString;
            }
        }
    }
}
