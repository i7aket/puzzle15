namespace Puzzle15;

public class Graphics
{
    public Graphics (Player player, GameBoard gameBoard, ScoreBoard scoreBoard)
    {
        Console.Clear();
        ConsoleOutput.PrintLayer0();
        
        ConsoleOutput.PrintEmptyBox(1, 65, 6, 29);
        ConsoleOutput.PrintEmptyBox(8, 65, 6, 29);
        ConsoleOutput.PrintEmptyBox(15, 65, 13, 29);

        new ConsoleOutput(65,1, ConsoleColor.Green, NameMovesTimes);
        new ConsoleOutput(73,1, ConsoleColor.Green, player.Name);
        new ConsoleOutput(73,3, ConsoleColor.Green, "0"); //Moves
        new ConsoleOutput(73,5, ConsoleColor.Green, "00:00"); //Time
        new ConsoleOutput(65,8, ConsoleColor.Green, HowToPlay);
        new ConsoleOutput(74,11, ConsoleColor.Red, "esc");
        new ConsoleOutput(75,12, ConsoleColor.Red, "N");
        new ConsoleOutput(74,13, ConsoleColor.Red, "C");
        new ConsoleOutput(66,15, ConsoleColor.Green, "Name            Time  Moves");
        
        InitBoard(gameBoard);
        InitScoreBoard(scoreBoard);
    }
    

    public void InitBoard(GameBoard board)
    {
        int shiftY = 1;
        
        for (int row = 0; row < 4; row++)
        {
            int shiftX = 1;
            for (int column = 0; column < 4; column++)
            {
                ConsoleColor color = board.CheckPosition(row,column) ? ConsoleColor.Green : ConsoleColor.Yellow;

                string[] numberTile = new ComponentNumber(board.Board[row, column]).Number; 
                new ConsoleOutput(shiftX,shiftY, color, numberTile);
                
                shiftX += 16;
            }
            shiftY += 7;
        }
        Console.SetCursorPosition(0, 30);
    }

    private void InitScoreBoard(ScoreBoard scoreBoard)
    {
        int shiftY = 16;
        int shiftX = 66;
        int shiftTimeX = 16;
        int shiftMovesX = 22;
            
        int lines = scoreBoard.CountPlayers() < 12 ? scoreBoard.CountPlayers() : 12;
        for (int n = 0; n < lines; n++)
        {

            ConsoleColor color;
            if (n == 0)
            {
                color = ConsoleColor.Red;
            } else if (n < 3)
            {
                color = ConsoleColor.Yellow;
            }
            else
            {
                color = ConsoleColor.Green;
            }
            
            new ConsoleOutput(shiftX, shiftY+n, color, scoreBoard.PlayerName(n));
            new ConsoleOutput (shiftX + shiftTimeX,shiftY+n, color, scoreBoard.PlayerTime(n));
            new ConsoleOutput (shiftX + shiftMovesX,shiftY+n, color, scoreBoard.PlayerMoves(n));
        }
    }
    
    public void ChangeTime(Player player )
    {
        new ConsoleOutput(73, 5, ConsoleColor.Green, player.TimeSpent());
    }
    
    public void ChangeMoves(GameBoard gameBoard)
    {
        new ConsoleOutput(73, 3, ConsoleColor.Green, gameBoard.GetMoves());
    }
    
    public void ChangeName()
    {
        ConsoleOutput.PrintEmptyBox(1, 73, 1, 21);
        new ConsoleOutput (73,1, ConsoleColor.Red, "Type your Name");
        new ConsoleOutput (73,1, ConsoleColor.Green, "");
    }
    
    public void ShowYouWon()
    {
        new ConsoleOutput(15, 4, ConsoleColor.Red, Win);
        new ConsoleOutput(30, 20, ConsoleColor.Red, "Press any key to start new game");
    }
    
    private readonly string[] NameMovesTimes =
    {
        " Name:                       ",
        "                             ",
        " Moves:                      ",
        "                             ",
        " Time:                       ",
        "                             "
    };

    private readonly string[] HowToPlay =
    {
        "   Use cursor control keys   ",
        " (the arrows) to move blocks ",
        "                             ",
        "   Press esc to exit Game    ",
        "    Press N for New Game     ",
        "   Press C to change name    ",
    };

    private readonly string[] Win =
    {
        " ██████╗ ██████╗ ███╗   ██╗ ██████╗ ██████╗  █████╗ ████████╗███████╗",
        "██╔════╝██╔═══██╗████╗  ██║██╔════╝ ██╔══██╗██╔══██╗╚══██╔══╝██╔════╝",
        "██║     ██║   ██║██╔██╗ ██║██║  ███╗██████╔╝███████║   ██║   ███████╗",
        "██║     ██║   ██║██║╚██╗██║██║   ██║██╔══██╗██╔══██║   ██║   ╚════██║",
        "╚██████╗╚██████╔╝██║ ╚████║╚██████╔╝██║  ██║██║  ██║   ██║   ███████║",
        " ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚══════╝",
        "",
        "",
        " ██╗██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗ ██████╗ ███╗   ██╗██╗  ",
        " ██║╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██╔═══██╗████╗  ██║██║  ",
        " ██║ ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║   ██║██╔██╗ ██║██║  ",
        " ╚═╝  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║   ██║██║╚██╗██║╚═╝  ",
        " ██╗   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝╚██████╔╝██║ ╚████║██╗  ",
        " ╚═╝   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝  ╚═════╝ ╚═╝  ╚═══╝╚═╝  ",
    };
    
    
}