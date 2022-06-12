﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TennisGame
{
    public partial class Form1 : Form
    {
        // score counter = alla, gamecounter = 0-4 
        private bool DeuceBool { get; set; }
        private Dictionary<string, int> Scores { get; set; }
        private Models.Player Player1 { get; set; }
        private Models.Player Player2 { get; set; }
        // Environment.NewLine är som \n för windows forms.
        private string newLine = Environment.NewLine;

        public Form1()
        {
            Scores = new Dictionary<string, int>()
            {
                {"Love", 0},
                {"Fifteen", 1},
                {"Thirty", 2},
                {"Forty", 3},
                {"Deuce", 4}
            };

            Player1 = new Models.Player() { PlayerNumber = 1, PlayerName = "Björn Borg" };
            Player2 = new Models.Player() { PlayerNumber = 2, PlayerName = "John McEnroe" };

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonHandler(Player1, Player2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonHandler(Player2, Player1);
        }

        private void randomize_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            int winner = Randomize(Player1, Player2);
            if (winner == 1)
            {
                ButtonHandler(Player1, Player2);
            }
            else
            {
                ButtonHandler(Player2, Player1);
            }
        }

        public void RandomHandler((int, int) randomRange, int breakPoint, string firstEntry, string secondEntry,
                                  out string outcome, out int outcomeInt)
        {
            var rand = new Random();
            int result = rand.Next(randomRange.Item1, randomRange.Item2);
            outcomeInt = result;
            if (breakPoint > result)
            {
                outcome = firstEntry;
            }
            else
            {
                outcome = secondEntry;
            }
        }

        public int Serve(Models.Player player, Models.Player opponent, string serveOutcome, int serveOutcomeInt)
        {
            int result = 0;
            textBox2.Text = textBox2.Text + $"{player.PlayerName} servar och bollen... {serveOutcome}! {serveOutcomeInt}" + newLine;
            if (serveOutcomeInt < 3)
            {
                textBox2.Text = textBox2.Text + $"{opponent.PlayerName} vinner!" + newLine;
                result = opponent.PlayerNumber;
            }
            else 
            {
                textBox2.Text = textBox2.Text + $"{player.PlayerName} vinner!" + newLine;
                result = player.PlayerNumber;
            }
            return result;
        }

        public int Randomize(Models.Player player1, Models.Player player2)
        {
            int winner = 0;

            RandomHandler((0, 10), 5, "Krona", "Klave", out string myntOutcome, out int myntOutcomeInt);
            textBox2.Text = textBox2.Text + $"Domaren singlar slant och det blir... {myntOutcome}! {myntOutcomeInt}" + newLine;

            RandomHandler((0, 10), 3, "Missar", "Träffar", out string serveOutcome, out int serveOutcomeInt);


            if (myntOutcomeInt < 5)
            {
                winner = Serve(player1, player2, serveOutcome, serveOutcomeInt);
            }
            else
            {
                winner = Serve(player2, player1, serveOutcome, serveOutcomeInt);
            }
            return winner;
        }

        private void ButtonHandler(Models.Player player, Models.Player opponent)
        {
            // Avgör vilken spelare som får poäng
            GameScore(player);
            Deuce(player, opponent);
            bool win = WinCondition(player, opponent);
            SetResults(player, opponent);
            if (win)
            {
                SetScore(player, opponent);
            }
        }

        public void GameScore(Models.Player player)
        {
            player.PlayerScoreCounter++;
            player.PlayerGameCounter++;
            player.PlayerScoreLabel = player.PlayerScoreCounter.ToString();

            foreach (var key in Scores)
            {
                if (key.Value == player.PlayerGameCounter)
                {
                    player.PlayerScoreLabelString = key.Key;
                }
            }
        }

        public void Deuce(Models.Player player, Models.Player opponent)
        {
            if (player.PlayerGameCounter >= 3 && opponent.PlayerGameCounter >= 3 && player.PlayerGameCounter == opponent.PlayerGameCounter)
            {
                player.PlayerScoreLabelString = "Deuce";
                opponent.PlayerScoreLabelString = "Deuce";
                DeuceBool = true;
            }
            if (DeuceBool && player.PlayerGameCounter > opponent.PlayerGameCounter)
            {
                player.PlayerScoreLabelString = "Advantage";
            }
        }

        public bool WinCondition(Models.Player player, Models.Player opponent)
        {
            bool win = false;

            if (player.PlayerGameCounter == 4 && player.PlayerGameCounter - 1 > opponent.PlayerGameCounter)
            {
                winLabel.Text = player.PlayerName + " wins!";
                win = true;
            }
            else if (player.PlayerGameCounter >= 3 && opponent.PlayerGameCounter >= 3 && player.PlayerGameCounter > opponent.PlayerGameCounter + 1)
            {
                winLabel.Text = player.PlayerName + " wins!";
                win = true;
            }
            else
            {
                winLabel.Text = "";
            }
            return win;
        }

        public void SetScore(Models.Player player, Models.Player opponent)
        {
            DeuceBool = false;
            player.PlayerGameCounter = 0;
            opponent.PlayerGameCounter = 0;
            player.PlayerScoreLabelString = "Love";
            opponent.PlayerScoreLabelString = "Love";
            player1ScoreString.Text = "Love";
            player2ScoreString.Text = "Love";

            player.PlayerSetCounter++;
            textBox1.Text = "";
            player.PlayerSetsWon = player.PlayerSetCounter.ToString();
        }

        public void SetResults(Models.Player player, Models.Player opponent)
        {
            if (player.PlayerNumber == 1)
            {
                player1Score.Text = player.PlayerScoreLabel;
                player1ScoreString.Text = player.PlayerScoreLabelString;
                player1SetsWon.Text = player.PlayerSetsWon;

                player2Score.Text = opponent.PlayerScoreLabel;
                player2ScoreString.Text = opponent.PlayerScoreLabelString;
                player2SetsWon.Text = opponent.PlayerSetsWon;
            }
            else if (player.PlayerNumber == 2)
            {
                player2Score.Text = player.PlayerScoreLabel;
                player2ScoreString.Text = player.PlayerScoreLabelString;
                player2SetsWon.Text = player.PlayerSetsWon;

                player1Score.Text = opponent.PlayerScoreLabel;
                player1ScoreString.Text = opponent.PlayerScoreLabelString;
                player1SetsWon.Text = opponent.PlayerSetsWon;
            }

            textBox1.Text = textBox1.Text + $"{player.PlayerName} får ett poäng!" + newLine;
        }

    }
}
