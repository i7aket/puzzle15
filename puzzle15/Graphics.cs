namespace Puzzle15;

public class Graphics
{
    private readonly Output _output = new Output();

    public Graphics()
    {
        Console.Clear();
        _output.Layer0();
        
        _output.Layer1CharBox(1, 65, 6, 29, ' ');
        _output.Layer1CharBox(8, 65, 6, 29, ' ');
        _output.Layer1CharBox(15, 65, 13, 29, ' ');

        _output.Layer2(1,65, ConsoleColor.Green, _nameMovesTimes);
        _output.Layer2(3,73, ConsoleColor.Green, "0"); //Moves
        _output.Layer2(5,73, ConsoleColor.Green, "00:00"); //Time

        
        _output.Layer2(8,65, ConsoleColor.Green, _howToPlay);
        _output.Layer2(11,74, ConsoleColor.Red, "esc");
        _output.Layer2(12,75, ConsoleColor.Red, "N");
        _output.Layer2(13,74, ConsoleColor.Red, "C");
        
        
        _output.Layer2(15,66, ConsoleColor.Green, _scoreTable);
    }

    public void InitBoard(GameBoard board)
    {
        int shiftY = 1;
        
        for (int row = 0; row < 4; row++)
        {
            int shiftX = 1;
            for (int column = 0; column < 4; column++)
            {
                ConsoleColor color = board.Board[row,column] == board.WinBoard[row,column] ? ConsoleColor.Green : ConsoleColor.Yellow;
                
                _output.Layer2(shiftY,shiftX, color, _numbers, board.Board[row,column]);
                
                shiftX += 16;
            }
            shiftY += 7;
        }
        
        Console.SetCursorPosition(0, 30);
    }
    
    public void InitScoreBoard(List<Player> list)
    {
        int shiftY = 16;
        int shiftX = 66;
        int shiftTimeX = 16;
        int shiftMovesX = 22;
            
        int lines = list.Count < 12 ? list.Count : 12;
        for (int i = 0; i < lines; i++)
        {

            ConsoleColor color;
            if (i == 0)
            {
                color = ConsoleColor.Red;
            } else if (i < 3)
            {
                color = ConsoleColor.Yellow;
            }
            else
            {
                color = ConsoleColor.Green;
            }
            
            _output.Layer2(shiftY+i, shiftX, color, list[i].Name);
            _output.Layer2(shiftY+i, shiftX + shiftTimeX, color, list[i].Ts.ToString(@"mm\:ss"));
            _output.Layer2(shiftY+i, shiftX + shiftMovesX, color, list[i].Moves.ToString());
        }

    }
    
    public void ChangeMovesAndTime(string moves, string timeSpent )
    {
        _output.Layer2(3, 73, ConsoleColor.Green, moves);
        _output.Layer2(5, 73, ConsoleColor.Green, timeSpent);
        Console.SetCursorPosition(0, 30);
    }
    
    public void ChangeName(string playerName)
    {
        _output.Layer1CharBox(1, 73, 1, 15, ' ');
        _output.Layer2(1, 73, ConsoleColor.Green, playerName);
    }
    
    public void ShowYouWon()
    {
        _output.Layer2(4, 15, ConsoleColor.Red, _win0);
        _output.Layer2(20, 30, ConsoleColor.Red, _win1);
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


    private readonly string[,] _numbers = {
            {
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               "
            },
            {
                "      ██╗      ",
                "     ███║      ",
                "     ╚██║      ",
                "      ██║      ",
                "      ██║      ",
                "      ╚═╝      "
            },
            {
                "   ██████╗     ",
                "   ╚════██╗    ",
                "    █████╔╝    ",
                "   ██╔═══╝     ",
                "   ███████╗    ",
                "   ╚══════╝    "
            },
            {
                "   ██████╗     ",
                "   ╚════██╗    ",
                "    █████╔╝    ",
                "    ╚═══██╗    ",
                "   ██████╔╝    ",
                "   ╚═════╝     "
            },
            {
                "   ██╗  ██╗    ",
                "   ██║  ██║    ",
                "   ███████║    ",
                "   ╚════██║    ",
                "        ██║    ",
                "        ╚═╝    "
            },
            {
                "   ███████╗    ",
                "   ██╔════╝    ",
                "   ███████╗    ",
                "   ╚════██║    ",
                "   ███████║    ",
                "   ╚══════╝    ",     
            },
            {
                "    ██████╗    ",
                "   ██╔════╝    ",
                "   ███████╗    ",
                "   ██╔═══██╗   ",
                "   ╚██████╔╝   ",
                "    ╚═════╝    "
            },
            {
                "   ███████╗    ",
                "   ╚════██║    ",
                "       ██╔╝    ",
                "      ██╔╝     ",  
                "      ██║      ",
                "      ╚═╝      "       
            },
            {
                "    █████╗     ",
                "   ██╔══██╗    ",
                "   ╚█████╔╝    ",
                "   ██╔══██╗    ",
                "   ╚█████╔╝    ",
                "    ╚════╝     ",      
            },
            {
                "    █████╗     ",
                "   ██╔══██╗    ",
                "   ╚██████║    ",
                "    ╚═══██║    ",
                "    █████╔╝    ",
                "    ╚════╝     "
            },
            {
                "  ██╗ ██████╗  ",
                " ███║██╔═████╗ ",
                " ╚██║██║██╔██║ ",
                "  ██║████╔╝██║ ",
                "  ██║╚██████╔╝ ",
                "  ╚═╝ ╚═════╝  ",
            },
            {
                "     ██╗ ██╗   ",
                "    ███║███║   ",
                "    ╚██║╚██║   ",
                "     ██║ ██║   ",
                "     ██║ ██║   ",
                "     ╚═╝ ╚═╝   "    
            },
            {
                "  ██╗██████╗   ",
                " ███║╚════██╗  ",
                " ╚██║ █████╔╝  ",
                "  ██║██╔═══╝   ",
                "  ██║███████╗  ",
                "  ╚═╝╚══════╝  "   
            },
            {
                "  ██╗██████╗   ",
                " ███║╚════██╗  ",
                " ╚██║ █████╔╝  ",
                "  ██║ ╚═══██╗  ",
                "  ██║██████╔╝  ",
                "  ╚═╝╚═════╝   "  
            },
            {
                "  ██╗██╗  ██╗  ",
                " ███║██║  ██║  ",
                " ╚██║███████║  ",
                "  ██║╚════██║  ",
                "  ██║     ██║  ",
                "  ╚═╝     ╚═╝  "
            },
            {
                "  ██╗███████╗  ",
                " ███║██╔════╝  ",
                " ╚██║███████╗  ",
                "  ██║╚════██║  ",
                "  ██║███████║  ",
                "  ╚═╝╚══════╝  " 
            }
    };
}