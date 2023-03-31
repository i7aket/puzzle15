namespace Puzzle15;

public class GameBoard
{
    private int _zeroPosX = 3;
    private int _zeroPosY= 3;
    private int LastMoveX { get; set; }
    private int LastMoveY { get; set; }
    public int Moves { get; private set; }
    public int[,] Board { get; private set; }

    private readonly int[,] _winBoard = new int[,] {
        { 1, 2, 3, 4 },
        { 5, 6, 7, 8 },
        { 9, 10, 11, 12 },
        { 13, 14, 15, 0 },
    };
    
    public GameBoard()
    {
        Board = new[,] {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 0 },
        };
        Shuffle();
    }

    private void Shuffle()
    {
        Random random = new Random();
        for (int i = 0; i < 20; i++)
        {
            int rnd = random.Next(1, 4);
            Up (rnd);
            Left(rnd);
            Down(rnd);
            Right(rnd);
        }
        Moves = 0;
    }

    public void DefaultPosition()
    {
        _zeroPosX = 3;
        _zeroPosY = 3;
        
        Board = new[,] {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 0 },
        };
    }

    public void Right(int repeat = 1)
    {
        if (_zeroPosX < 3)
        {
            SaveLastMove();
            for (int i = 0; i < repeat; i++)
            {
                Board[_zeroPosY, _zeroPosX] = Board[_zeroPosY, _zeroPosX + 1];
                Board[_zeroPosY, _zeroPosX + 1] = 0;
                _zeroPosX++;
                Moves++;
            }
        }
    }

    public void Down(int repeat = 1)
    {
        if (_zeroPosY < 3)
        {
            SaveLastMove();
            for (int i = 0; i < repeat; i++) 
            {
                Board[_zeroPosY, _zeroPosX] = Board[_zeroPosY + 1, _zeroPosX];
                Board[_zeroPosY + 1, _zeroPosX] = 0;
                _zeroPosY++; 
                Moves++;
            }

        }
    }
    
    public void Left(int repeat = 1) {
        if (_zeroPosX > 0) {
            SaveLastMove();
            for (int i = 0; i < repeat; i++)
            {
                Board[_zeroPosY, _zeroPosX] = Board[_zeroPosY, _zeroPosX - 1];
                Board[_zeroPosY, _zeroPosX - 1] = 0;
                _zeroPosX--;
                Moves++;
            }
        }
    }
    
    public void Up(int repeat= 1) {
        if (_zeroPosY > 0)
        {
            SaveLastMove();
            for (int i = 0; i < repeat; i++)
            {
                Board[_zeroPosY, _zeroPosX] = Board[_zeroPosY - 1, _zeroPosX];
                Board[_zeroPosY - 1, _zeroPosX] = 0;
                _zeroPosY--;
                Moves++;
            }
        }
    }

    private void SaveLastMove()
    {
        if (LastMoveX != _zeroPosX) LastMoveX = _zeroPosX;
        if (LastMoveY != _zeroPosY) LastMoveY = _zeroPosY;
    }

    /*public int LastMove()
    {
        return Board[LastMoveY, LastMoveX];
    }*/


    public bool LastMove(int row, int column)
    {
        if (Board[row, column] == Board[LastMoveY, LastMoveX] || Board[row, column] == Board[_zeroPosY, _zeroPosX]) return true;
        else return false;
    }

    public string GetMoves()
    {
        return Moves.ToString();
    }
    
    public bool CheckPosition(int row, int column)
    {
        if (Board[row, column] == _winBoard[row, column])
        {
            return true;
        }
        else
            return false;

    }

    public bool CheckWin()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Board[i, j] != _winBoard[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
