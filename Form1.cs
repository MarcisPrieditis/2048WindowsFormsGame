using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game2048.Properties;


namespace Game2048
{
    public partial class Form1 : Form
    {
        private static int _score;
        private static int _highScore;
        private BoardCells _board;


        public Form1()
        {
            InitializeComponent();
            _board = new BoardCells(this, 4, 4);
            _board.CreatMap();
            _board.RandomNewCellLocations();
            _board.RandomNewCellLocations();
        }

        private void _keyboardEvent(object sender, KeyEventArgs e)
        {
            var clonedBoard = new Label[4, 4];
            clonedBoard = (Label[,])_board._cellPic.Clone();

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 3; y >= 0; y--)
                    {
                        if (IfCellIsNotEmpty(x, y))
                        {
                            for (int k = y - 1; k >= 0; k--)
                            {
                                if (_board._cellPic[x, k] != null)
                                {
                                    if (_board._cellPic[x, k].Text == _board._cellPic[x, y].Text)
                                    {
                                        _board._cellPic[x, y].Text = (int.Parse(_board._cellPic[x, y].Text) +
                                                               int.Parse(_board._cellPic[x, k].Text)).ToString();
                                        _board.BackGroundColorBasedOnNumber(_board._cellPic[x, y].Text, x, y);

                                        _score += int.Parse(_board._cellPic[x, y].Text);
                                        ScoreLabel.Text = $"Score:\n {_score}";
                                        this.Controls.Remove(_board._cellPic[x, k]);
                                        _board._cellPic[x, k] = null;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                for (int x = 0; x < 4; x++)
                {
                    for (int y = 2; y >= 0; y--)
                    {
                        if (IfCellIsNotEmpty(x, y))
                        {
                            for (int j = y + 1; j <= 3; j++)
                            {
                                MoveCellsToRightOrLeft(x, j, +55, -1);
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (IfCellIsNotEmpty(x, y))
                        {
                            for (int k = y + 1; k <= 3; k++)
                            {
                                if (_board._cellPic[x, k] != null)
                                {
                                    if (_board._cellPic[x, k].Text == _board._cellPic[x, y].Text)
                                    {
                                        _board._cellPic[x, y].Text = (int.Parse(_board._cellPic[x, y].Text) +
                                                                      int.Parse(_board._cellPic[x, k].Text)).ToString();
                                        _board.BackGroundColorBasedOnNumber(_board._cellPic[x, y].Text, x, y);

                                        _score += int.Parse(_board._cellPic[x, y].Text);
                                        ScoreLabel.Text = $"Score:\n {_score}";
                                        if (_board._cellPic[x, y].Text == "2048")
                                            WinnerBoard();
                                        this.Controls.Remove(_board._cellPic[x, k]);
                                        _board._cellPic[x, k] = null;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                for (int x = 0; x < 4; x++)
                {
                    for (int y = 1; y < 4; y++)
                    {
                        if (IfCellIsNotEmpty(x, y))
                        {
                            for (int j = y - 1; j >= 0; j--)
                            {
                                MoveCellsToRightOrLeft(x, j, -55, +1);
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (IfCellIsNotEmpty(x, y))
                        {
                            for (int k = x + 1; k <= 3; k++)
                            {
                                if (_board._cellPic[k, y] != null)
                                {
                                    if (_board._cellPic[k, y].Text == _board._cellPic[x, y].Text)
                                    {
                                        _board._cellPic[x, y].Text = (int.Parse(_board._cellPic[x, y].Text) +
                                                                      int.Parse(_board._cellPic[k, y].Text)).ToString();
                                        _board.BackGroundColorBasedOnNumber(_board._cellPic[x, y].Text, x, y);

                                        _score += int.Parse(_board._cellPic[x, y].Text);
                                        ScoreLabel.Text = $"Score:\n {_score}";
                                        if (_board._cellPic[x, y].Text == "2048")
                                            WinnerBoard();
                                        this.Controls.Remove(_board._cellPic[k, y]);
                                        _board._cellPic[k, y] = null;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                for (int x = 1; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (IfCellIsNotEmpty(x, y))
                        {
                            for (int j = x - 1; j >= 0; j--)
                            {
                                MoveCellsToUpOrDown(j, y, -55, +1);
                            }


                        }
                    }
                }

            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                for (int x = 3; x >= 1; x--)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (IfCellIsNotEmpty(x, y))
                        {
                            for (int k = x - 1; k >= 0; k--)
                            {
                                if (_board._cellPic[k, y] != null)
                                {
                                    if (_board._cellPic[k, y].Text == _board._cellPic[x, y].Text)
                                    {
                                        _board._cellPic[x, y].Text = (int.Parse(_board._cellPic[x, y].Text) +
                                                               int.Parse(_board._cellPic[k, y].Text)).ToString();
                                        _board.BackGroundColorBasedOnNumber(_board._cellPic[x, y].Text, x, y);

                                        _score += int.Parse(_board._cellPic[x, y].Text);
                                        ScoreLabel.Text = $"Score:\n {_score}";

                                        this.Controls.Remove(_board._cellPic[k, y]);
                                        _board._cellPic[k, y] = null;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                for (int x = 2; x >= 0; x--)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (IfCellIsNotEmpty(x, y))
                        {
                            for (int j = x + 1; j <= 3; j++)
                            {
                                MoveCellsToUpOrDown(j, y, +55, -1);
                            }
                        }
                    }
                }
            }

            var boardsAreEqual = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (clonedBoard[i, j] != _board._cellPic[i, j])
                    {
                        boardsAreEqual = false;
                        break;
                    }
                }
            }

            if (!boardsAreEqual)
            {
                if (!IfBoardIsFull())
                    _board.RandomNewCellLocations();
            }

            if (IfGameIsOver())
                GameOverBoard();
        }

        public bool IfCellIsNotEmpty(int x, int y)
        {
            return _board._cellPic[x, y] != null;
        }

        public void MoveCellsToUpOrDown(int j, int y, int direction, int cellDirection)
        {
            if (_board._cellPic[j, y] == null)
            {
                _board._cellPic[j, y] = _board._cellPic[j + cellDirection, y];
                _board._cellPic[j + cellDirection, y] = null;
                _board._cellPic[j, y].Location = new Point(_board._cellPic[j, y].Location.X,
                    _board._cellPic[j, y].Location.Y + direction);
            }
        }

        public void MoveCellsToRightOrLeft(int x, int j, int direction, int cellDirection)
        {
            if (_board._cellPic[x, j] == null)
            {
                _board._cellPic[x, j] = _board._cellPic[x, j + cellDirection];
                _board._cellPic[x, j + cellDirection] = null;
                _board._cellPic[x, j].Location = new Point(_board._cellPic[x, j].Location.X + direction,
                    _board._cellPic[x, j].Location.Y);
            }
        }

        public void StoreHighScore()
        {
            if (_score > _highScore)
            {
                _highScore = _score;
                HighscoreLabel.Text = $"High Score:\n {_highScore}";
            }
        }

        public void WinnerBoard()
        {
            StoreHighScore();
            var c = new Label();
            c.Location = new Point(25, 25);
            c.Size = new Size(215, 215);
            c.BackColor = Color.DarkSlateBlue;
            c.ForeColor = Color.White;
            c.Font = new Font("Arial", 55, FontStyle.Bold);
            c.TextAlign = ContentAlignment.MiddleCenter;
            c.Text = "2048";
            this.Controls.Add(c);
            c.BringToFront();
        }

        private void RestartGame(object sender, EventArgs e)
        {
            StoreHighScore();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Controls.Remove(_board._cellPic[i, j]);
                    _board._cellPic[i, j] = null;
                }
            }

            _score = 0;
            ScoreLabel.Text = "Score:\n 0";
            _board.CreatMap();
            _board.RandomNewCellLocations();
            _board.RandomNewCellLocations();
        }

        private void AddCell(object sender, EventArgs e)
        {
            _board.RandomNewCellLocations();
        }

        private void EnableHardMode_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void SpawnCellTimer(object sender, EventArgs e)
        {
            _board.RandomNewCellLocations();
            CountDownTimer.Text = $"Time: ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public bool IfBoardIsFull()
        {
            var ifBoardIsFull = true;

            foreach (var cell in _board._cellPic)
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
                            if (_board._cellPic[row, col].Text.Equals(_board._cellPic[row + 1, col].Text))
                            {
                                return false;
                            }
                        }

                        if (col < 3)
                        {
                            if (_board._cellPic[row, col].Text.Equals(_board._cellPic[row, col + 1].Text))
                            {
                                return false;
                            }
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
            var c = new Label();
            c.Location = new Point(25, 25);
            c.Size = new Size(215, 215);
            c.BackColor = Color.DarkSlateBlue;
            c.ForeColor = Color.White;
            c.Font = new Font("Arial", 55, FontStyle.Bold);
            c.TextAlign = ContentAlignment.MiddleCenter;
            c.Text = "You Lost";
            this.Controls.Add(c);
            c.BringToFront();
        }
    }
}
