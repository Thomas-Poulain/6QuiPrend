namespace CardGame2022
{
    partial class NumbersOfPlayers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownNbPlayers = new System.Windows.Forms.NumericUpDown();
            this.labelNumberPlayers = new System.Windows.Forms.Label();
            this.buttonOkNbPlayers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownNbPlayers
            // 
            this.numericUpDownNbPlayers.Location = new System.Drawing.Point(157, 104);
            this.numericUpDownNbPlayers.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownNbPlayers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNbPlayers.Name = "numericUpDownNbPlayers";
            this.numericUpDownNbPlayers.Size = new System.Drawing.Size(130, 20);
            this.numericUpDownNbPlayers.TabIndex = 0;
            this.numericUpDownNbPlayers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelNumberPlayers
            // 
            this.labelNumberPlayers.AutoSize = true;
            this.labelNumberPlayers.Location = new System.Drawing.Point(165, 54);
            this.labelNumberPlayers.Name = "labelNumberPlayers";
            this.labelNumberPlayers.Size = new System.Drawing.Size(101, 13);
            this.labelNumberPlayers.TabIndex = 1;
            this.labelNumberPlayers.Text = "Number of players ?";
            // 
            // buttonOkNbPlayers
            // 
            this.buttonOkNbPlayers.Location = new System.Drawing.Point(168, 172);
            this.buttonOkNbPlayers.Name = "buttonOkNbPlayers";
            this.buttonOkNbPlayers.Size = new System.Drawing.Size(98, 24);
            this.buttonOkNbPlayers.TabIndex = 2;
            this.buttonOkNbPlayers.Text = "OK";
            this.buttonOkNbPlayers.UseVisualStyleBackColor = true;
            this.buttonOkNbPlayers.Click += new System.EventHandler(this.buttonOkNbPlayers_Click);
            // 
            // NumbersOfPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 285);
            this.Controls.Add(this.buttonOkNbPlayers);
            this.Controls.Add(this.labelNumberPlayers);
            this.Controls.Add(this.numericUpDownNbPlayers);
            this.Name = "NumbersOfPlayers";
            this.Text = "NumbersOfPlayers";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownNbPlayers;
        private System.Windows.Forms.Label labelNumberPlayers;
        private System.Windows.Forms.Button buttonOkNbPlayers;
    }
}