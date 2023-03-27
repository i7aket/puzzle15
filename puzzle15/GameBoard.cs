using System.Reflection;

namespace Puzzle15;

public class GameBoard
{
    private int ZeroPosX { get; set;}= 3;
    private int ZeroPosY{ get; set;}= 3;
    private int LastMoveX{ get; set;}
    private int LastMoveY{ get; set;}
    public int Moves { get; private set;}= 0;

    public int [,] Board  { get; private set;}=
    {
        {1,2,3,4},
        {5,6,7,8},
        {9,10,11,12},
        {13,14,15,0},
    };

    private readonly int [,] _winBoard  =
    {
        {1,2,3,4},
        {5,6,7,8},
        {9,10,11,12},
        {13,14,15,0},
    };
    
    
    public GameBoard ()
    {
        Shuffle();
    }

    private void Shuffle()
    {
        Random random = new Random();
        for (int i = 0; i < 20; i++)
        {
            int rnd = random.Next(1, 4);
            Move("Up", rnd);
            Move("Left",rnd);
            Move("Down", rnd);
            Move("Right",rnd);
        }
        Moves = 0;
    }

    public void DefaultPosition() 
    {
        ZeroPosX = 3;
        ZeroPosY = 3;
        
        
        
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Board[i, j] = _winBoard[i, j];
            } 
        }
    }
    
    public void Move(string move, int repeat=1)
    {
        bool correctmove = false;
        switch (move)
        {
            case "Right" when ZeroPosX < 3:

                SaveLastMove();
                
                for (int i = 0; i < repeat; i++)
                {
                    Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY, ZeroPosX + 1];
                    Board[ZeroPosY, ZeroPosX + 1] = 0;
                    ZeroPosX++;
                    Moves++;
                }
                break;

            case "Down" when ZeroPosY < 3:
            {
                SaveLastMove(); 
                for (int i = 0; i < repeat; i++)
                {
                    Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY + 1, ZeroPosX];
                    Board[ZeroPosY + 1, ZeroPosX] = 0;
                    ZeroPosY++;
                    Moves++;
                }
                break;
            }

            case "Left" when ZeroPosX > 0:
            {
                SaveLastMove();
                for (int i = 0; i < repeat; i++)
                {
                    Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY, ZeroPosX - 1];
                    Board[ZeroPosY, ZeroPosX - 1] = 0;
                    ZeroPosX--;
                    Moves++;
                }
                break;
            }

            case "Up" when ZeroPosY > 0:
            {
                SaveLastMove();
                for (int i = 0; i < repeat; i++)
                {
                    Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY - 1, ZeroPosX];
                    Board[ZeroPosY - 1, ZeroPosX] = 0;
                    ZeroPosY--;
                    Moves++;
                }
                break;
            }
        }
    }

    private void SaveLastMove()
    {
        if (LastMoveX != ZeroPosX) LastMoveX = ZeroPosX;
        if (LastMoveY != ZeroPosY) LastMoveY = ZeroPosY;
    }

    public bool LastMove(int row, int column)
    {
        if (Board[row, column] == Board[LastMoveY, LastMoveX] || Board[row, column] == Board[ZeroPosY, ZeroPosX] || Moves == 0) return true;
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
