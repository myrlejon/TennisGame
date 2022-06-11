
namespace TennisGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.player1 = new System.Windows.Forms.Button();
            this.player2 = new System.Windows.Forms.Button();
            this.player1Score = new System.Windows.Forms.Label();
            this.player2Score = new System.Windows.Forms.Label();
            this.player1ScoreString = new System.Windows.Forms.Label();
            this.player2ScoreString = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.winLabel = new System.Windows.Forms.Label();
            this.player1SetsWon = new System.Windows.Forms.Label();
            this.player2SetsWon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // player1
            // 
            this.player1.Location = new System.Drawing.Point(126, 320);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(129, 68);
            this.player1.TabIndex = 0;
            this.player1.Text = "Player 1";
            this.player1.UseVisualStyleBackColor = true;
            this.player1.Click += new System.EventHandler(this.button1_Click);
            // 
            // player2
            // 
            this.player2.Location = new System.Drawing.Point(486, 320);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(129, 68);
            this.player2.TabIndex = 1;
            this.player2.Text = "Player 2";
            this.player2.UseVisualStyleBackColor = true;
            this.player2.Click += new System.EventHandler(this.button2_Click);
            // 
            // player1Score
            // 
            this.player1Score.AutoSize = true;
            this.player1Score.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player1Score.Location = new System.Drawing.Point(229, 174);
            this.player1Score.Name = "player1Score";
            this.player1Score.Size = new System.Drawing.Size(72, 86);
            this.player1Score.TabIndex = 4;
            this.player1Score.Text = "0";
            // 
            // player2Score
            // 
            this.player2Score.AutoSize = true;
            this.player2Score.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player2Score.Location = new System.Drawing.Point(427, 174);
            this.player2Score.Name = "player2Score";
            this.player2Score.Size = new System.Drawing.Size(72, 86);
            this.player2Score.TabIndex = 5;
            this.player2Score.Text = "0";
            // 
            // player1ScoreString
            // 
            this.player1ScoreString.AutoSize = true;
            this.player1ScoreString.Font = new System.Drawing.Font("Amiri Quran", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player1ScoreString.Location = new System.Drawing.Point(149, 267);
            this.player1ScoreString.Name = "player1ScoreString";
            this.player1ScoreString.Size = new System.Drawing.Size(85, 50);
            this.player1ScoreString.TabIndex = 6;
            this.player1ScoreString.Text = "Love";
            // 
            // player2ScoreString
            // 
            this.player2ScoreString.AutoSize = true;
            this.player2ScoreString.Font = new System.Drawing.Font("Amiri Quran", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player2ScoreString.Location = new System.Drawing.Point(513, 267);
            this.player2ScoreString.Name = "player2ScoreString";
            this.player2ScoreString.Size = new System.Drawing.Size(85, 50);
            this.player2ScoreString.TabIndex = 7;
            this.player2ScoreString.Text = "Love";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TennisGame.Properties.Resources.tennis_icon_6;
            this.pictureBox1.Location = new System.Drawing.Point(268, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.Location = new System.Drawing.Point(337, 267);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(0, 15);
            this.winLabel.TabIndex = 10;
            // 
            // player1SetsWon
            // 
            this.player1SetsWon.AutoSize = true;
            this.player1SetsWon.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player1SetsWon.Location = new System.Drawing.Point(307, 174);
            this.player1SetsWon.Name = "player1SetsWon";
            this.player1SetsWon.Size = new System.Drawing.Size(54, 65);
            this.player1SetsWon.TabIndex = 11;
            this.player1SetsWon.Text = "0";
            this.player1SetsWon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2SetsWon
            // 
            this.player2SetsWon.AutoSize = true;
            this.player2SetsWon.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player2SetsWon.Location = new System.Drawing.Point(367, 174);
            this.player2SetsWon.Name = "player2SetsWon";
            this.player2SetsWon.Size = new System.Drawing.Size(54, 65);
            this.player2SetsWon.TabIndex = 12;
            this.player2SetsWon.Text = "0";
            this.player2SetsWon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(708, 471);
            this.Controls.Add(this.player2SetsWon);
            this.Controls.Add(this.player1SetsWon);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.player2ScoreString);
            this.Controls.Add(this.player1ScoreString);
            this.Controls.Add(this.player2Score);
            this.Controls.Add(this.player1Score);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button player1;
        private System.Windows.Forms.Button player2;
        private System.Windows.Forms.Label player1Score;
        private System.Windows.Forms.Label player2Score;
        private System.Windows.Forms.Label player1ScoreString;
        private System.Windows.Forms.Label player2ScoreString;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Label player1SetsWon;
        private System.Windows.Forms.Label player2SetsWon;
    }
}

