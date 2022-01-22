using System.Drawing;

namespace Game2048;

public class MovementActions
{
    public Form1 Form;
    public BoardCells _board = new();

    public MovementActions(Form1 form)
    {
        this.Form = form;
    }

    public bool CountingSimilarNumberLoopLeftRightKeys(int row, int col, int colK)
    {
        if (IfCellIsNotEmpty(row, colK))
        {
            if (BoardCells._cellPic[row, colK].Text != BoardCells._cellPic[row, col].Text)
                return true;

            if (BoardCells._cellPic[row, colK].Text == BoardCells._cellPic[row, col].Text)
            {
                BoardCells._cellPic[row, col].Text = (int.Parse(BoardCells._cellPic[row, col].Text) +
                                                      int.Parse(BoardCells._cellPic[row, colK].Text)).ToString();
                _board.BackGroundColorBasedOnNumber(BoardCells._cellPic[row, col].Text, row, col);

                BoardCells._score += int.Parse(BoardCells._cellPic[row, col].Text);
                Form.ScoreLabel.Text = $"Score:\n {BoardCells._score}";
                if (BoardCells._cellPic[row, col].Text == "2048")
                    Form.WinnerBoard();
                Form.Controls.Remove(BoardCells._cellPic[row, colK]);
                BoardCells._cellPic[row, colK] = null;
                return true;
            }
        }

        return false;
    }

    public bool CountingSimilarNumberLoopUpDownKeys(int row, int col, int rowK)
    {
        if (IfCellIsNotEmpty(rowK, col))
        {
            //Check if neighbor cell is not empty and afterwards if they are equal, if not break to skip next loop for nex row,
            //no need to check further
            if (BoardCells._cellPic[rowK, col].Text != BoardCells._cellPic[row, col].Text)
                return true;

            if (BoardCells._cellPic[rowK, col].Text == BoardCells._cellPic[row, col].Text)
            {
                BoardCells._cellPic[row, col].Text = (int.Parse(BoardCells._cellPic[row, col].Text) +
                                                      int.Parse(BoardCells._cellPic[rowK, col].Text)).ToString();
                _board.BackGroundColorBasedOnNumber(BoardCells._cellPic[row, col].Text, row, col);

                BoardCells._score += int.Parse(BoardCells._cellPic[row, col].Text);
                Form.ScoreLabel.Text = $"Score:\n {BoardCells._score}";
                if (BoardCells._cellPic[row, col].Text == "2048")
                    Form.WinnerBoard();
                Form.Controls.Remove(BoardCells._cellPic[rowK, col]);
                BoardCells._cellPic[rowK, col] = null;
                return true;
            }
        }

        return false;
    }

    public bool IfCellIsNotEmpty(int row, int col)
    {
        return BoardCells._cellPic[row, col] != null;
    }

    public void MoveCellsToUpOrDown(int j, int y, int direction, int cellDirection)
    {
        if (BoardCells._cellPic[j, y] == null)
        {
            BoardCells._cellPic[j, y] = BoardCells._cellPic[j + cellDirection, y];
            BoardCells._cellPic[j + cellDirection, y] = null;
            BoardCells._cellPic[j, y].Location = new Point(BoardCells._cellPic[j, y].Location.X,
            BoardCells._cellPic[j, y].Location.Y + direction);
        }
    }

    public void MoveCellsToRightOrLeft(int x, int j, int direction, int cellDirection)
    {
        if (BoardCells._cellPic[x, j] == null)
        {
            BoardCells._cellPic[x, j] = BoardCells._cellPic[x, j + cellDirection];
            BoardCells._cellPic[x, j + cellDirection] = null;
            BoardCells._cellPic[x, j].Location = new Point(BoardCells._cellPic[x, j].Location.X + direction,
                BoardCells._cellPic[x, j].Location.Y);
        }
    }

    /// At KeyPress Cell is being summed if equal and moved to pressed key side
    public void RightKey()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 3; y >= 0; y--)
            {
                if (IfCellIsNotEmpty(x, y))
                {
                    for (int k = y - 1; k >= 0; k--)
                    {
                        if (CountingSimilarNumberLoopLeftRightKeys(x, y, k))
                        {
                            break;
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

    public void LeftKey()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if (IfCellIsNotEmpty(x, y))
                {
                    for (int k = y + 1; k <= 3; k++)
                    {
                        if (CountingSimilarNumberLoopLeftRightKeys(x, y, k))
                        {
                            break;
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

    public void UpKey()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if (IfCellIsNotEmpty(x, y))
                {
                    for (int k = x + 1; k <= 3; k++)
                    {
                        if (CountingSimilarNumberLoopUpDownKeys(x, y, k))
                        {
                            break;
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

    public void DownKey()
    {
        for (int x = 3; x >= 1; x--)
        {
            for (int y = 0; y < 4; y++)
            {
                if (IfCellIsNotEmpty(x, y))
                {
                    for (int k = x - 1; k >= 0; k--)
                    {
                        if (CountingSimilarNumberLoopUpDownKeys(x, y, k))
                        {
                            break;
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
}