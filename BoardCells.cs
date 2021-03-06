using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game2048
{
    public class BoardCells
    {
        public Form1 Form1 { get; set; }
        private int _width;
        private int _height;
        public static int _score;
        public static int _highScore;
        public static Label[,] _cellPic;
        private Random _rnd = new Random();

        public BoardCells()
        {

        }

        public BoardCells(Form1 form, int width, int height)
        {
            Form1 = form;
            _width = width;
            _height = height;
            _cellPic = new Label[width, height];
        }

        public void SetupBoard()
        {
            CreatMap();
            RandomNewCellLocations();
            RandomNewCellLocations();
        }

        public void RandomNewCellLocations()

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
                    var c = new Label();
                    c.Location = new Point(25 + 55 * j, 25 + 55 * i);
                    c.Size = new Size(50, 50);
                    c.BackColor = Color.AliceBlue;
                    Form1.Controls.Add(c);
                    c.BringToFront();
                }
            }
        }

        public void RandomNewCellPic(int x, int y)
        {
            var random4Cell = _rnd.Next(0, 9);
            _cellPic[x, y] = new Label();
            _cellPic[x, y].Location = new Point(25 + 55 * y, 25 + 55 * x);
            _cellPic[x, y].Size = new Size(50, 50);
            //If random num ==0, 10% chance, than spawn 4 instead of 2 cell
            _cellPic[x, y].Text = random4Cell == 0 ? "4" : "2";
            BackGroundColorBasedOnNumber(_cellPic[x, y].Text, x, y);
            _cellPic[x, y].ForeColor = Color.White;
            _cellPic[x, y].TextAlign = ContentAlignment.MiddleCenter;
            _cellPic[x, y].Font = new Font("Arial", 13, FontStyle.Bold);
            Form1.Controls.Add(_cellPic[x, y]);
            _cellPic[x, y].BringToFront();
        }

        public Color BackGroundColorBasedOnNumber(string number, int x, int y)
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
    }
}