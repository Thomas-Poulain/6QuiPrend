namespace CardGame2022
{
    partial class MainWindow
    {


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newRound = new System.Windows.Forms.Button();
            this.NewGame = new System.Windows.Forms.Button();
            this.labelCurrentPlayer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newRound
            // 
            this.newRound.BackColor = System.Drawing.SystemColors.ControlDark;
            this.newRound.Enabled = false;
            this.newRound.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.newRound.Location = new System.Drawing.Point(12, 24);
            this.newRound.Name = "newRound";
            this.newRound.Size = new System.Drawing.Size(75, 33);
            this.newRound.TabIndex = 10;
            this.newRound.Text = "New Round";
            this.newRound.UseVisualStyleBackColor = false;
            this.newRound.Click += new System.EventHandler(this.NewRound_Click);
            // 
            // NewGame
            // 
            this.NewGame.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewGame.Location = new System.Drawing.Point(12, 75);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(75, 34);
            this.NewGame.TabIndex = 15;
            this.NewGame.Text = "New Game";
            this.NewGame.UseVisualStyleBackColor = false;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // labelCurrentPlayer
            // 
            this.labelCurrentPlayer.AutoSize = true;
            this.labelCurrentPlayer.ForeColor = System.Drawing.Color.Black;
            this.labelCurrentPlayer.Location = new System.Drawing.Point(147, 377);
            this.labelCurrentPlayer.Name = "labelCurrentPlayer";
            this.labelCurrentPlayer.Size = new System.Drawing.Size(0, 13);
            this.labelCurrentPlayer.TabIndex = 16;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 517);
            this.Controls.Add(this.labelCurrentPlayer);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.newRound);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.Text = "6 nimmt! (IUT version)";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainWindow_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button newRound;
        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Label labelCurrentPlayer;
    }
}

