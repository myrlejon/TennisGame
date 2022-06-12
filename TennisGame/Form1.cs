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
        private bool DeuceBool { get; set; }
        private Dictionary<string, int> Scores { get; set; }
        private Models.Player Player1 { get; set; }
        private Models.Player Player2 { get; set; }

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

            Player1 = new Models.Player() { PlayerNumber = 1, PlayerName = "Björn Borg"};
            Player2 = new Models.Player() { PlayerNumber = 2, PlayerName = "John McEnroe"};

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

        private void ButtonHandler(Models.Player player, Models.Player opponent)
        {
            // Avgör vilken spelare som får poäng
            GameScore(player);
            Deuce(player, opponent);
            bool win = WinCondition(player, opponent);

            if (win)
            {
                SetScore(player, opponent);
            }
            SetResults(player, opponent);
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
            player.PlayerSetCounter++;
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
        }
    }
}
