namespace Puzzle15;

public class GameBoard
{
    private int ZeroPosX { get; set; } = 3;
    private int ZeroPosY { get; set; } = 3;
    public int LastMoveX { get; private set; }
    public int LastMoveY { get; private set; }
    public int Moves { get; private set; } = 0;
    public int[,] Board { get; private set; }

    private readonly int[,] _winBoard = new int[,] {
        { 1, 2, 3, 4 },
        { 5, 6, 7, 8 },
        { 9, 10, 11, 12 },
        { 13, 14, 15, 0 },
    };
    
    public GameBoard()
    {
        Board = new int[,] {
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
        ZeroPosX = 3;
        ZeroPosY = 3;
        
        Board = new[,] {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 0 },
        };
    }

    public void Right(int repeat = 1)
    {
        if (ZeroPosX < 3)
        {
            SaveLastMove();
            for (int i = 0; i < repeat; i++)
            {
                Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY, ZeroPosX + 1];
                Board[ZeroPosY, ZeroPosX + 1] = 0;
                ZeroPosX++;
                Moves++;
            }
        }
    }

    public void Down(int repeat = 1)
    {
        if (ZeroPosY < 3)
        {
            SaveLastMove();
            for (int i = 0; i < repeat; i++) 
            {
                Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY + 1, ZeroPosX];
                Board[ZeroPosY + 1, ZeroPosX] = 0;
                ZeroPosY++; 
                Moves++;
            }

        }
    }
    
    public void Left(int repeat = 1) {
        if (ZeroPosX > 0) {
            SaveLastMove();
            for (int i = 0; i < repeat; i++)
            {
                Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY, ZeroPosX - 1];
                Board[ZeroPosY, ZeroPosX - 1] = 0;
                ZeroPosX--;
                Moves++;
            }
        }
    }
    
    public void Up(int repeat= 1) {
        if (ZeroPosY > 0)
        {
            SaveLastMove();
            for (int i = 0; i < repeat; i++)
            {
                Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY - 1, ZeroPosX];
                Board[ZeroPosY - 1, ZeroPosX] = 0;
                ZeroPosY--;
                Moves++;
            }
        }
    }

    private void SaveLastMove()
    {
        if (LastMoveX != ZeroPosX) LastMoveX = ZeroPosX;
        if (LastMoveY != ZeroPosY) LastMoveY = ZeroPosY;
    }

    /*public int LastMove()
    {
        return Board[LastMoveY, LastMoveX];
    }*/


    public bool LastMove(int row, int column)
    {
        if (Board[row, column] == Board[LastMoveY, LastMoveX] || Board[row, column] == Board[ZeroPosY, ZeroPosX]) return true;
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
