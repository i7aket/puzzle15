namespace Puzzle15;

public class Graphics
{
    private ConsoleOutput _consoleOutput = new ConsoleOutput();
    private ComponentBox _componentBox = new ComponentBox();
    private ComponentNumber _componentNumber = new ComponentNumber();
    
    
    public Graphics (Player player, GameBoard gameBoard, ScoreBoard scoreBoard)
    {
        Console.Clear();
        _consoleOutput.PrintLayer0();
        
        _consoleOutput.PrintEmptyBox(1, 65, 6, 29);
        _consoleOutput.PrintEmptyBox(8, 65, 6, 29);
        _consoleOutput.PrintEmptyBox(15, 65, 13, 29);
        _consoleOutput.Print(_componentBox.Set(65, 1, ConsoleColor.Green, _nameMovesTimes));
        _consoleOutput.Print(_componentBox.Set(73,1, ConsoleColor.Green, player.Name));
        _consoleOutput.Print(_componentBox.Set(73,3, ConsoleColor.Green, "0")); //Moves
        _consoleOutput.Print(_componentBox.Set(73,5, ConsoleColor.Green, "00:00")); //Time
        _consoleOutput.Print(_componentBox.Set(65,8, ConsoleColor.Green, _howToPlay));
        _consoleOutput.Print(_componentBox.Set(74,11, ConsoleColor.Red, "esc"));
        _consoleOutput.Print(_componentBox.Set(75,12, ConsoleColor.Red, "N"));
        _consoleOutput.Print(_componentBox.Set(74,13, ConsoleColor.Red, "C"));
        _consoleOutput.Print(_componentBox.Set(66,15, ConsoleColor.Green, "Name            Time  Moves"));
        
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
                _consoleOutput.Print(_componentBox.Set(shiftX,shiftY, color, _componentNumber.Numbers[board.Board[row, column]]));
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
            
            _consoleOutput.Print(_componentBox.Set(shiftX, shiftY+n, color, scoreBoard.PlayerName(n)));
            _consoleOutput.Print(_componentBox.Set(shiftX + shiftTimeX,shiftY+n, color, scoreBoard.PlayerTime(n)));
            _consoleOutput.Print(_componentBox.Set (shiftX + shiftMovesX,shiftY+n, color, scoreBoard.PlayerMoves(n)));
        }
    }
    
    public void ChangeTime(Player player )
    {
        _consoleOutput.Print(_componentBox.Set(73, 5, ConsoleColor.Green, player.TimeSpent()));
    }
    
    public void ChangeMoves(GameBoard gameBoard)
    {
        _consoleOutput.Print(_componentBox.Set(73, 3, ConsoleColor.Green, gameBoard.GetMoves()));
    }
    
    public void ChangeName()
    {
        _consoleOutput.PrintEmptyBox(1, 73, 1, 21);
        _consoleOutput.Print(_componentBox.Set (73,1, ConsoleColor.Red, "Type your Name"));
        _consoleOutput.Print(_componentBox.Set (73,1, ConsoleColor.Green, ""));
    }
    
    public void ShowYouWon()
    {
        _consoleOutput.Print(_componentBox.Set(15, 4, ConsoleColor.Red, _win));
        _consoleOutput.Print(_componentBox.Set(30, 20, ConsoleColor.Red, "Press any key to start new game"));
    }
    
    private readonly string[] _nameMovesTimes =
    {
        " Name:                       ",
        "                             ",
        " Moves:                      ",
        "                             ",
        " Time:                       ",
        "                             "
    };

    private readonly string[] _howToPlay =
    {
        "   Use cursor control keys   ",
        " (the arrows) to move blocks ",
        "                             ",
        "   Press esc to exit Game    ",
        "    Press N for New Game     ",
        "   Press C to change name    ",
    };

    private readonly string[] _win =
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