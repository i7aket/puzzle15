namespace puzzle15;

public class GameBoard
{
    public int ZeroPosX = 3;
    public int ZeroPosY = 3;
    
    public int [,] Board  =
    {
        {1,2,3,4},
        {5,6,7,8},
        {9,10,11,12},
        {13,14,15,0},
    };
    
    public int [,] Winboard  =
    {
        {1,2,3,4},
        {5,6,7,8},
        {9,10,11,12},
        {13,14,15,0},
    };

    
    public void Shuffle()
    {
        Random random = new Random();
        for (int i = 0; i < 20; i++)
        {
            int rnd = random.Next(1, 4);
            Movetile("Up", rnd);
            Movetile("Left",rnd);
            Movetile("Down", rnd);
            Movetile("Right",rnd);
        }
    }

    public void Defaultposition()
    {
        ZeroPosX = 3;
        ZeroPosY = 3;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Board[i, j] = Winboard[i, j];
            } 
        }
    }
    
    
    public void Movetile(string move, int repeat)
    {
        switch (move)
        {
            case "Right":
                for (int i = 0; i < repeat; i++)
                {
                    Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY, ZeroPosX + 1];
                    Board[ZeroPosY, ZeroPosX + 1] = 0;
                    ZeroPosX++;
                }

                break;

            case "Down":
            {
                for (int i = 0; i < repeat; i++)
                {
                    Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY + 1, ZeroPosX];
                    Board[ZeroPosY + 1, ZeroPosX] = 0;
                    ZeroPosY++;
                }

                break;
            }

            case "Left":
            {
                for (int i = 0; i < repeat; i++)
                {
                    Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY, ZeroPosX - 1];
                    Board[ZeroPosY, ZeroPosX - 1] = 0;
                    ZeroPosX--;
                }

                break;
            }

            case "Up":
            {
                for (int i = 0; i < repeat; i++)
                {
                    Board[ZeroPosY, ZeroPosX] = Board[ZeroPosY - 1, ZeroPosX];
                    Board[ZeroPosY - 1, ZeroPosX] = 0;
                    ZeroPosY--;
                }
                break;
            }
        }
    }

    public bool Chekwin()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Board[i, j] != Winboard[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
