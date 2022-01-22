using System;
using System.Drawing;
using System.Windows.Forms;


namespace Game2048
{
    public partial class Form1 : Form
    {
        private BoardCells _board;
        private MovementActions _movementActions;

        public Form1()
        {
            InitializeComponent();
            _movementActions = new MovementActions(this);
            _board = new BoardCells(this, 4, 4);
            _board.SetupBoard();
            //Testing Purpose AddCell button
            addCellButton.Hide();
        }

        public void StoreHighScore()
        {
            if (BoardCells._score > BoardCells._highScore)
            {
                BoardCells._highScore = BoardCells._score;
                HighscoreLabel.Text = $"High Score:\n {BoardCells._highScore}";
            }
        }

        private void AddCell(object sender, EventArgs e)
        {
            WinnerBoard();
        }

        private void EnableHardMode_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void SpawnCellTimer(object sender, EventArgs e)
        {
            if (!IfBoardIsFull())
                _board.RandomNewCellLocations();
        }

        public bool IfBoardIsFull()
        {
            var ifBoardIsFull = true;

            foreach (var cell in BoardCells._cellPic)
            {
                if (cell == null)
                {
                    ifBoardIsFull = false;
                    break;
                }
            }

            return ifBoardIsFull;
        }

        public bool IfGameIsOver()
        {
            if (IfBoardIsFull())
            {
                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (row < 3)
                        {
                            if (BoardCells._cellPic[row, col].Text.Equals(BoardCells._cellPic[row + 1, col].Text))
                                return false;
                        }

                        if (col < 3)
                        {
                            if (BoardCells._cellPic[row, col].Text.Equals(BoardCells._cellPic[row, col + 1].Text))
                                return false;
                        }
                    }
                }
            }
            else
                return false;

            return true;
        }

        public void GameOverBoard()
        {
            StoreHighScore();
            var c = WinLostLabel;
            c.Location = new Point(25, 25);
            c.Size = new Size(215, 215);
            c.BackColor = Color.DarkSlateBlue;
            c.ForeColor = Color.White;
            c.Font = new Font("Arial", 55, FontStyle.Bold);
            c.TextAlign = ContentAlignment.MiddleCenter;
            c.Text = "You\n Lost";
            this.Controls.Add(c);
            c.BringToFront();
        }

        public void WinnerBoard()
        {
            StoreHighScore();
            var c = WinLostLabel;
            c.Location = new Point(25, 25);
            c.Size = new Size(215, 215);
            c.BackColor = Color.DarkSlateBlue;
            c.ForeColor = Color.White;
            c.Font = new Font("Arial", 45, FontStyle.Bold);
            c.TextAlign = ContentAlignment.MiddleCenter;
            c.Text = "2048\n You Won!";
            Controls.Add(c);
            c.BringToFront();
        }

        private void RestartGame(object sender, EventArgs e)
        {
            StoreHighScore();
            EnableHardMode.Checked = false;
            timer1.Stop();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Controls.Remove(BoardCells._cellPic[i, j]);
                    BoardCells._cellPic[i, j] = null;
                }
            }

            BoardCells._score = 0;
            ScoreLabel.Text = "Score:\n 0";
            _board.SetupBoard();
            WinLostLabel.Text = "";
        }

        private void KeyDownActions(object sender, KeyEventArgs e)
        {

            var clonedBoard = new Label[4, 4];
            clonedBoard = (Label[,])BoardCells._cellPic.Clone();

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                _movementActions.RightKey();
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                _movementActions.LeftKey();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                _movementActions.UpKey();

            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                _movementActions.DownKey();
            }

            //Make sure if cloned board cells is similar with original after key is pressed
            var boardsAreEqual = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (clonedBoard[i, j] != BoardCells._cellPic[i, j])
                    {
                        boardsAreEqual = false;
                        break;
                    }
                }
            }

            //if both label arrays not equal spawn new random cell
            if (!boardsAreEqual)
            {
                if (!IfBoardIsFull())
                    _board.RandomNewCellLocations();
            }

            if (IfGameIsOver())
                GameOverBoard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
