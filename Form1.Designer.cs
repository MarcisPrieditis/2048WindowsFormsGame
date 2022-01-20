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
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.EnableHardMode = new System.Windows.Forms.RadioButton();
            this.CountDownTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ScoreLabel.Location = new System.Drawing.Point(257, 85);
            this.ScoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(60, 34);
            this.ScoreLabel.TabIndex = 1;
            this.ScoreLabel.Text = "Score: \r\n 0";
            // 
            // HighscoreLabel
            // 
            this.HighscoreLabel.AutoSize = true;
            this.HighscoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighscoreLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.HighscoreLabel.Location = new System.Drawing.Point(248, 127);
            this.HighscoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HighscoreLabel.Name = "HighscoreLabel";
            this.HighscoreLabel.Size = new System.Drawing.Size(107, 17);
            this.HighscoreLabel.TabIndex = 1;
            this.HighscoreLabel.Text = "High Score: 0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Restart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RestartGame);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this._keyboardEvent);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Cursor = System.Windows.Forms.Cursors.No;
            this.button2.Location = new System.Drawing.Point(251, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "addcell";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AddCell);
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this._keyboardEvent);
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
            this.EnableHardMode.Location = new System.Drawing.Point(251, 214);
            this.EnableHardMode.Name = "EnableHardMode";
            this.EnableHardMode.Size = new System.Drawing.Size(130, 17);
            this.EnableHardMode.TabIndex = 4;
            this.EnableHardMode.TabStop = true;
            this.EnableHardMode.Text = "Enable Hard Mode";
            this.EnableHardMode.UseVisualStyleBackColor = true;
            this.EnableHardMode.CheckedChanged += new System.EventHandler(this.EnableHardMode_CheckedChanged);
            this.EnableHardMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this._keyboardEvent);
            // 
            // CountDownTimer
            // 
            this.CountDownTimer.AutoSize = true;
            this.CountDownTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountDownTimer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CountDownTimer.Location = new System.Drawing.Point(277, 234);
            this.CountDownTimer.Name = "CountDownTimer";
            this.CountDownTimer.Size = new System.Drawing.Size(68, 17);
            this.CountDownTimer.TabIndex = 5;
            this.CountDownTimer.Text = "Timer: 3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(383, 256);
            this.Controls.Add(this.CountDownTimer);
            this.Controls.Add(this.EnableHardMode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HighscoreLabel);
            this.Controls.Add(this.ScoreLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "2048";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this._keyboardEvent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label HighscoreLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton EnableHardMode;
        private System.Windows.Forms.Label CountDownTimer;
    }
}

