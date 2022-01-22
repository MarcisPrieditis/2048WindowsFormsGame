namespace Game2048
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.HighscoreLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.addCellButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.EnableHardMode = new System.Windows.Forms.RadioButton();
            this.CountDownTimer = new System.Windows.Forms.Label();
            this.WinLostLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ScoreLabel.Location = new System.Drawing.Point(343, 105);
            this.ScoreLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(70, 40);
            this.ScoreLabel.TabIndex = 1;
            this.ScoreLabel.Text = "Score: \r\n 0";
            // 
            // HighscoreLabel
            // 
            this.HighscoreLabel.AutoSize = true;
            this.HighscoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighscoreLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.HighscoreLabel.Location = new System.Drawing.Point(331, 156);
            this.HighscoreLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.HighscoreLabel.Name = "HighscoreLabel";
            this.HighscoreLabel.Size = new System.Drawing.Size(115, 40);
            this.HighscoreLabel.TabIndex = 1;
            this.HighscoreLabel.Text = "High Score: \r\n   0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 54);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Restart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RestartGame);
            // 
            // addCellButton
            // 
            this.addCellButton.AutoSize = true;
            this.addCellButton.Cursor = System.Windows.Forms.Cursors.No;
            this.addCellButton.Location = new System.Drawing.Point(335, 209);
            this.addCellButton.Margin = new System.Windows.Forms.Padding(4);
            this.addCellButton.Name = "addCellButton";
            this.addCellButton.Size = new System.Drawing.Size(100, 31);
            this.addCellButton.TabIndex = 3;
            this.addCellButton.Text = "addcell";
            this.addCellButton.UseVisualStyleBackColor = true;
            this.addCellButton.Click += new System.EventHandler(this.AddCell);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.SpawnCellTimer);
            // 
            // EnableHardMode
            // 
            this.EnableHardMode.AutoSize = true;
            this.EnableHardMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableHardMode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.EnableHardMode.Location = new System.Drawing.Point(335, 263);
            this.EnableHardMode.Margin = new System.Windows.Forms.Padding(4);
            this.EnableHardMode.Name = "EnableHardMode";
            this.EnableHardMode.Size = new System.Drawing.Size(163, 21);
            this.EnableHardMode.TabIndex = 4;
            this.EnableHardMode.TabStop = true;
            this.EnableHardMode.Text = "Enable Hard Mode";
            this.EnableHardMode.UseVisualStyleBackColor = true;
            this.EnableHardMode.CheckedChanged += new System.EventHandler(this.EnableHardMode_CheckedChanged);
            // 
            // CountDownTimer
            // 
            this.CountDownTimer.AutoSize = true;
            this.CountDownTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountDownTimer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CountDownTimer.Location = new System.Drawing.Point(369, 288);
            this.CountDownTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CountDownTimer.Name = "CountDownTimer";
            this.CountDownTimer.Size = new System.Drawing.Size(79, 20);
            this.CountDownTimer.TabIndex = 5;
            this.CountDownTimer.Text = "Timer: 3";
            // 
            // WinLostLabel
            // 
            this.WinLostLabel.Location = new System.Drawing.Point(25, 25);
            this.WinLostLabel.Name = "WinLostLabel";
            this.WinLostLabel.Size = new System.Drawing.Size(215, 215);
            this.WinLostLabel.TabIndex = 6;
            this.WinLostLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(535, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Play with keys:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.Location = new System.Drawing.Point(511, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 45);
            this.label2.TabIndex = 9;
            this.label2.Text = "A";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Lavender;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label3.Location = new System.Drawing.Point(562, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 45);
            this.label3.TabIndex = 10;
            this.label3.Text = "W";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Lavender;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(562, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 45);
            this.label4.TabIndex = 10;
            this.label4.Text = "S";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Lavender;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label5.Location = new System.Drawing.Point(613, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 45);
            this.label5.TabIndex = 10;
            this.label5.Text = "D";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(672, 315);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WinLostLabel);
            this.Controls.Add(this.CountDownTimer);
            this.Controls.Add(this.EnableHardMode);
            this.Controls.Add(this.addCellButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HighscoreLabel);
            this.Controls.Add(this.ScoreLabel);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "2048";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownActions);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public  System.Windows.Forms.Label ScoreLabel;
        public  System.Windows.Forms.Label HighscoreLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addCellButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton EnableHardMode;
        private System.Windows.Forms.Label CountDownTimer;
        public System.Windows.Forms.Label WinLostLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

