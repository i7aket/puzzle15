namespace Puzzle15;

public class Components
{
    public readonly Dictionary<int, ComponentBox> Numbers = new Dictionary<int, ComponentBox>();
    public readonly Dictionary<string, ComponentBox> Strings = new Dictionary<string, ComponentBox>();
    public readonly List<ComponentBox> ScoreBoard = new List<ComponentBox>();
    private readonly ScoreBoard _scoreBoard = new ScoreBoard();
    
    public Components()
    {


        string[] howToPlay = new [] {
            "   Use cursor control keys   ",
            " (the arrows) to move blocks ",
            "                             ",
            "   Press esc to exit Game    ",
            "    Press N for New Game     ",
            "   Press C to change name    ",
        };
        
        string[] nameMovesTimes = new [] {
            " Name:                       ",
            "                             ",
            " Moves:                      ",
            "                             ",
            " Time:                       ",
            "                             "
        };
        
        string[] win = new [] {
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
        
        string[,] numbers = new [,] {
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
        
        for (int i = 0; i < numbers.GetLength(0); i++)
        {
            
            string [] arr = new string [numbers.GetLength(1)];    

            for (int n = 0; n < numbers.GetLength(1); n++)
                arr [n] = numbers[i,n];

            Numbers.Add(i, new ComponentBox(arr));
        }
        
        Strings.Add("NameMovesTimes", new ComponentBox(65, 1, ConsoleColor.Green, nameMovesTimes));
        Strings.Add("HowToPlay", new ComponentBox(65, 8, ConsoleColor.Green, howToPlay));
        Strings.Add("Name", new ComponentBox(73,1, ConsoleColor.Green, ""));
        Strings.Add("Moves", new ComponentBox(73,3, ConsoleColor.Green, "0"));
        Strings.Add("Time", new ComponentBox(73,5, ConsoleColor.Green, "00:00"));
        Strings.Add ("esc", new ComponentBox(74,11, ConsoleColor.Red, "esc"));
        Strings.Add ("N", new ComponentBox(75,12, ConsoleColor.Red, "N"));
        Strings.Add ("C", new ComponentBox(74,13, ConsoleColor.Red, "C"));
        Strings.Add ("NameTimeMoves", new ComponentBox(66,15, ConsoleColor.Green, "Name            Time  Moves"));
        Strings.Add ("Type your Name", new ComponentBox(73,1, ConsoleColor.Red, "Type your Name"));
        Strings.Add("Win", new ComponentBox(15, 4, ConsoleColor.Red, win));
        Strings.Add ("Win2", new ComponentBox(30,20, ConsoleColor.Red, "Press any key to start new game"));
        Strings.Add ("ScoreBoard", new ComponentBox(String.Empty));
        
        
        //Component ScoreBoard
        const int shiftY = 16;
        const int shiftX = 66;
        const int shiftTimeX = 16;
        const int shiftMovesX = 22;
        
        int lines = _scoreBoard.CountPlayers() < 12 ? _scoreBoard.CountPlayers() : 12;
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
            
            ScoreBoard.Add(new ComponentBox(shiftX, shiftY+n, color, _scoreBoard.PlayerName(n)));
            ScoreBoard.Add(new ComponentBox(shiftX + shiftTimeX,shiftY+n, color, _scoreBoard.PlayerTime(n)));
            ScoreBoard.Add(new ComponentBox(shiftX + shiftMovesX,shiftY+n, color, _scoreBoard.PlayerMoves(n)));
        }
    }
}