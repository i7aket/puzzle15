using System.ComponentModel;

namespace Puzzle15;

public class Graphics
{
    public int ShiftX;
    public int ShiftY;
    public ConsoleColor color;
    public string label;
    
    
    public Graphics (Player player, GameBoard gameBoard, ScoreBoard scoreBoard)
    {
        Console.Clear();
        Output.Layer0();
        
        Output.Layer1CharBox(1, 65, 6, 29, ' ');
        Output.Layer1CharBox(8, 65, 6, 29, ' ');
        Output.Layer1CharBox(15, 65, 13, 29, ' ');

        Output.Layer2(1,65, ConsoleColor.Green, _nameMovesTimes);
        Output.Layer2(1,73, ConsoleColor.Green, player.Name);
        Output.Layer2(3,73, ConsoleColor.Green, "0"); //Moves
        Output.Layer2(5,73, ConsoleColor.Green, "00:00"); //Time

        
        Output.Layer2(8,65, ConsoleColor.Green, _howToPlay);
        Output.Layer2(11,74, ConsoleColor.Red, "esc");
        Output.Layer2(12,75, ConsoleColor.Red, "N");
        Output.Layer2(13,74, ConsoleColor.Red, "C");
        
        Output.Layer2(15,66, ConsoleColor.Green, _scoreTable);
        
        InitBoard(gameBoard);
        InitScoreBoard(scoreBoard);
        
    }
    
    public Graphics(int ShiftX, int ShiftY, ConsoleColor color, string label)
    {
        this.ShiftX = ShiftX;
        this.ShiftY = ShiftY;
        this.color = color;
        this.label = label;
    }

    /*public void OutPut()
    {
        _output.Layer3();
    }*/
    
    private static string _sometext = "SOME TEXT";

    public void InitBoard(GameBoard board)
    {
        int shiftY = 1;
        
        for (int row = 0; row < 4; row++)
        {
            int shiftX = 1;
            for (int column = 0; column < 4; column++)
            {
                ConsoleColor color = board.CheckPosition(row,column) ? ConsoleColor.Green : ConsoleColor.Yellow;
                
                Output.Layer3(new (shiftX,shiftY, color, board.Board[row,column]));
                
                shiftX += 16;
            }
            shiftY += 7;
        }
        
        Console.SetCursorPosition(0, 30);
    }
    
    public void InitScoreBoard(ScoreBoard scoreBoard)
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
            
            Output.Layer2(shiftY+n, shiftX, color, scoreBoard.playerName(n));
            Output.Layer2(shiftY+n, shiftX + shiftTimeX, color, scoreBoard.playerTime(n));
            Output.Layer2(shiftY+n, shiftX + shiftMovesX, color, scoreBoard.playerMoves(n));
        }
    }
    
    public void ChangeTime(Player player )
    {
        Output.Layer2(5, 73, ConsoleColor.Green, player.TimeSpent());
    }
    
    public void ChangeMoves(GameBoard gameBoard)
    {
        Output.Layer2(3, 73, ConsoleColor.Green, gameBoard.GetMoves());
    }
    
    public void ChangeName()
    {
        showEmptyName();
        Console.SetCursorPosition(73,1);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Type your Name");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(73,1);
    }
    
    public void showEmptyName ()
    {
        Output.Layer1CharBox(1, 73, 1, 21, ' ');
    }
    
    public void ShowYouWon()
    {
        Output.Layer2(4, 15, ConsoleColor.Red, _win0);
        Output.Layer2(20, 30, ConsoleColor.Red, _win1);
    }
    
    private readonly string _scoreTable = "Name            Time  Moves";
    
    public readonly string EmptyNameField = "                ";

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

    private readonly string[] _win0 =
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

    private readonly string _win1 = "Press any key to start new game";
    
}