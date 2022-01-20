using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private int _width = 4;
        private int _height = 4;
        private int[,] _mapCells = new int[4, 4];
        private Label[,] _cellPic = new Label[4, 4];
        private Random _rnd = new Random();
        private static int _score;
        private static int _highScore;



        public Form1()
        {
            InitializeComponent();
            CreatMap();
            RandomNewCellLocations();
            RandomNewCellLocations();
        }

        //Makes 2 in random place if cell is already taken tries new location
        private void RandomNewCellLocations()
        {
            var x = _rnd.Next(_width);
            var y = _rnd.Next(_height);

            if (_cellPic[x, y] == null)
                RandomNewCellPic(x, y);
            else
                RandomNewCellLocations();
        }

        public void CreatMap()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    var c = new PictureBox();
                    c.Location = new Point(25 + 55 * j, 25 + 55 * i);
                    c.Size = new Size(50, 50);
                    c.BackColor = Color.AliceBlue;
                    this.Controls.Add(c);
                }
            }
        }

        public void RandomNewCellPic(int x, int y)
        {
            _cellPic[x, y] = new Label();
            _cellPic[x, y].Location = new Point(25 + 55 * y, 25 + 55 * x);
            _cellPic[x, y].Size = new Size(50, 50);
            _cellPic[x, y].Text = "2";
            BackGroundColorBasedOnNumber(_cellPic[x, y].Text, x, y);
            _cellPic[x, y].ForeColor = Color.White;
            _cellPic[x, y].TextAlign = ContentAlignment.MiddleCenter;
            _cellPic[x, y].Font = new Font("Arial", 13, FontStyle.Bold);
            this.Controls.Add(_cellPic[x, y]);
            _mapCells[x, y] = 1;
            _cellPic[x, y].BringToFront();
        }

        private void _keyboardEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 3; y >= 0; y--)
                    {
                        if (CheckIfCellIsNotEmpty(x, y))
                        {
                            for (int k = y - 1; k >= 0; k--)
                            {
                                if (_cellPic[x, k] != null)
                                {
                                    if (_cellPic[x, k].Text == _cellPic[x, y].Text)
                                    {
                                        _cellPic[x, y].Text = (int.Parse(_cellPic[x, y].Text) +
                                                              int.Parse(_cellPic[x, k].Text)).ToString();
                                        BackGroundColorBasedOnNumber(_cellPic[x, y].Text, x, y);

                                        _score += int.Parse(_cellPic[x, y].Text);
                                        ScoreLabel.Text = $"Score:\n {_score}";

                                        this.Controls.Remove(_cellPic[x, k]);
                                        _cellPic[x, k] = null;
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
                        if (CheckIfCellIsNotEmpty(x, y))
                        {
                            for (int j = y + 1; j <= 3; j++)
                            {
                                MoveCellsToRightOrLeft(x, j, +55, -1);
                                //if (_cellPic[x, j] == null)
                                //{
                                //    _cellPic[x, j] = _cellPic[x, j - 1];
                                //    _cellPic[x, j - 1] = null;
                                //    _cellPic[x, j].Location = new Point(_cellPic[x, j].Location.X + 55,
                                //        _cellPic[x, j].Location.Y);
                                //}
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
                        if (CheckIfCellIsNotEmpty(x, y))
                        {
                            for (int k = y + 1; k <= 3; k++)
                            {
                                if (_cellPic[x, k] != null)
                                {
                                    if (_cellPic[x, k].Text == _cellPic[x, y].Text)
                                    {
                                        _cellPic[x, y].Text = (int.Parse(_cellPic[x, y].Text) +
                                                              int.Parse(_cellPic[x, k].Text)).ToString();
                                        BackGroundColorBasedOnNumber(_cellPic[x, y].Text, x, y);

                                        _score += int.Parse(_cellPic[x, y].Text);
                                        ScoreLabel.Text = $"Score:\n {_score}";

                                        this.Controls.Remove(_cellPic[x, k]);
                                        _cellPic[x, k] = null;
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
                        if (CheckIfCellIsNotEmpty(x, y))
                        {
                            for (int j = y - 1; j >= 0; j--)
                            {
                                MoveCellsToRightOrLeft(x, j, -55, +1);
                                //if (_cellPic[x, j] == null)
                                //{
                                //    _cellPic[x, j] = _cellPic[x, j + 1];
                                //    _cellPic[x, j + 1] = null;
                                //    _cellPic[x, j].Location = new Point(_cellPic[x, j].Location.X - 55,
                                //        _cellPic[x, j].Location.Y);
                                //}
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
                        if (CheckIfCellIsNotEmpty(x, y))
                        {
                            for (int k = x + 1; k <= 3; k++)
                            {
                                if (_cellPic[k, y] != null)
                                {
                                    if (_cellPic[k, y].Text == _cellPic[x, y].Text)
                                    {
                                        _cellPic[x, y].Text = (int.Parse(_cellPic[x, y].Text) +
                                                              int.Parse(_cellPic[k, y].Text)).ToString();
                                        BackGroundColorBasedOnNumber(_cellPic[x, y].Text, x, y);

                                        _score += int.Parse(_cellPic[x, y].Text);
                                        ScoreLabel.Text = $"Score:\n {_score}";

                                        this.Controls.Remove(_cellPic[k, y]);
                                        _cellPic[k, y] = null;
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
                        if (CheckIfCellIsNotEmpty(x, y))
                        {
                            for (int j = x - 1; j >= 0; j--)
                            {
                                MoveCellsToUpOrDown(j, y, -55, +1);
                                //if (_cellPic[j, y] == null)
                                //{
                                //    _cellPic[j, y] = _cellPic[j + 1, y];
                                //    _cellPic[j + 1, y] = null;
                                //    _cellPic[j, y].Location = new Point(_cellPic[j, y].Location.X,
                                //        _cellPic[j, y].Location.Y - 55);
                                //}
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
                        if (CheckIfCellIsNotEmpty(x, y))
                        {
                            for (int k = x - 1; k >= 0; k--)
                            {
                                if (_cellPic[k, y] != null)
                                {
                                    if (_cellPic[k, y].Text == _cellPic[x, y].Text)
                                    {
                                        _cellPic[x, y].Text = (int.Parse(_cellPic[x, y].Text) +
                                                              int.Parse(_cellPic[k, y].Text)).ToString();
                                        BackGroundColorBasedOnNumber(_cellPic[x, y].Text, x, y);

                                        _score += int.Parse(_cellPic[x, y].Text);
                                        ScoreLabel.Text = $"Score:\n {_score}";

                                        this.Controls.Remove(_cellPic[k, y]);
                                        _cellPic[k, y] = null;
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
                        if (CheckIfCellIsNotEmpty( x,  y))
                        {
                            for (int j = x + 1; j <= 3; j++)
                            {
                                MoveCellsToUpOrDown(j, y, +55, -1);
                                //if (_cellPic[j, y] == null)
                                //{
                                //    _cellPic[j, y] = _cellPic[j - 1, y];
                                //    _cellPic[j - 1, y] = null;
                                //    _cellPic[j, y].Location = new Point(_cellPic[j, y].Location.X,
                                //        _cellPic[j, y].Location.Y + 55);
                                //}
                            }
                        }
                    }
                }
            }

            RandomNewCellLocations();
        }

        public bool CheckIfCellIsNotEmpty(int x, int y)
        {
            return _cellPic[x, y] != null;
        }

        public void MoveCellsToUpOrDown(int j, int y, int direction, int cellDirection)
        {
            if (_cellPic[j, y] == null)
            {
                _cellPic[j, y] = _cellPic[j + cellDirection, y];
                _cellPic[j + cellDirection, y] = null;
                _cellPic[j, y].Location = new Point(_cellPic[j, y].Location.X,
                    _cellPic[j, y].Location.Y + direction);
            }
        }

        public void MoveCellsToRightOrLeft(int x, int j, int direction, int cellDirection)
        {
            if (_cellPic[x, j] == null)
            {
                _cellPic[x, j] = _cellPic[x, j + cellDirection];
                _cellPic[x, j + cellDirection] = null;
                _cellPic[x, j].Location = new Point(_cellPic[x, j].Location.X + direction,
                    _cellPic[x, j].Location.Y);
            }
        }

        private Color BackGroundColorBasedOnNumber(string number, int x, int y)
        {
            switch (number)
            {
                case "2":
                    return _cellPic[x, y].BackColor = Color.FromArgb(227, 215, 184);
                case "4":
                    return _cellPic[x, y].BackColor = Color.FromArgb(207, 184, 126);
                case "8":
                    return _cellPic[x, y].BackColor = Color.FromArgb(207, 161, 126);
                case "16":
                    return _cellPic[x, y].BackColor = Color.FromArgb(207, 141, 118);
                case "32":
                    return _cellPic[x, y].BackColor = Color.FromArgb(186, 112, 86);
                case "64":
                    return _cellPic[x, y].BackColor = Color.FromArgb(194, 70, 43);
                case "128":
                    return _cellPic[x, y].BackColor = Color.FromArgb(219, 188, 94);
                case "256":
                    return _cellPic[x, y].BackColor = Color.FromArgb(201, 169, 71);
                case "512":
                    return _cellPic[x, y].BackColor = Color.FromArgb(212, 173, 53);
                case "1024":
                    return _cellPic[x, y].BackColor = Color.FromArgb(224, 174, 20);
                case "2048":
                    return _cellPic[x, y].BackColor = Color.FromArgb(255, 8, 102);
                default:
                    return Color.Black;
            }
        }


        private void GameOver()
        {
            _score = 0;
            if (_score > _highScore)
            {
                _highScore = _score;
            }

            var checkIfBoardIsFull = true;

            foreach (var cell in _mapCells)
            {
                if (cell == 0)
                {
                    checkIfBoardIsFull = false;
                    break;
                }
            }

            if (checkIfBoardIsFull)
            {
                MessageBox.Show("You lost the game");
            }
        }

        public void WinnerBoard()
        {
            var c = new Label();
            c.Location = new Point(25, 25);
            c.Size = new Size(215, 215);
            c.BackColor = Color.HotPink;
            c.ForeColor = Color.White;
            c.Font = new Font("Arial", 55, FontStyle.Bold);
            c.TextAlign = ContentAlignment.MiddleCenter;
            c.Text = "2048";
            this.Controls.Add(c);
            c.BringToFront();
        }

        private void RestartGame(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _mapCells[i, j] = 0;
                    Controls.Remove(_cellPic[i, j]);
                    _cellPic[i, j] = null;
                }
            }

            _score = 0;
            ScoreLabel.Text = "Score:\n 0";
            RandomNewCellLocations();
            RandomNewCellLocations();
        }

        private void AddCell(object sender, EventArgs e)
        {
            RandomNewCellLocations();
        }

        private void EnableHardMode_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void SpawnCellTimer(object sender, EventArgs e)
        {
            RandomNewCellLocations();
            CountDownTimer.Text = $"Time: ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
