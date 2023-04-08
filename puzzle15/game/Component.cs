namespace puzzle15;
public class Component
{
    public event Action <ComponentBox> PrintEvent;
    
    private readonly Dictionary<int, List<ComponentBox>> _interfaceComponents =
        new Dictionary<int, List<ComponentBox>>();
    private readonly Dictionary<int, CoordinateBox> _numberCoordinates =
        new Dictionary<int, CoordinateBox>();
    private readonly Dictionary<int, string []> _numberComponents =
        new Dictionary<int, string []>();
    
    public Component()
    {
        int counter = 0;
        int shiftY = 1;
        
        for (int row = 0; row < 4; row++)
        {
            int shiftX = 1;
            for (int column = 0; column < 4; column++)
            {
                _numberCoordinates[counter] = new CoordinateBox(shiftY, shiftX);
                counter++;
                shiftX += 16;
            }
            shiftY += 7;
        }
        
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

        //  numbers

        for (int i = 0; i < numbers.GetLength(0); i++)
        {
            
            string [] arr = new string [numbers.GetLength(1)];    

            for (int n = 0; n < numbers.GetLength(1); n++)
                arr [n] = numbers[i,n];

            _numberComponents.Add(i, arr);
        }
        
        
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

        //Component Layer0
        List<ComponentBox> layer0 = new List<ComponentBox>();
        layer0.Add(new ComponentBox(0, 0, Color.Yellow, CreateCharBox(Const.CanvasHeight, Const.CanvasWidth, '*')));
        _interfaceComponents[Const.Layer0] = layer0;
        
        List<ComponentBox> howToPlayTable = new List<ComponentBox>();
        
        howToPlayTable.Add(new ComponentBox(65, 8, Color.Black, CreateCharBox(6, 29)));
        howToPlayTable.Add(new ComponentBox(65, 8, Color.Green, howToPlay));
        howToPlayTable.Add (new ComponentBox(74,11, Color.Red, "esc"));
        howToPlayTable.Add (new ComponentBox(75,12, Color.Red, "N"));
        howToPlayTable.Add (new ComponentBox(74,13, Color.Red, "C"));
        _interfaceComponents[Const.HowToPlayTable] = howToPlayTable;
        
        
        List<ComponentBox> nameMovesTimesTable = new List<ComponentBox>();
        nameMovesTimesTable.Add(new ComponentBox(65, 1, Color.Black, CreateCharBox(6, 29)));
        nameMovesTimesTable.Add(new ComponentBox(65, 1, Color.Green, nameMovesTimes));
        _interfaceComponents[Const.NameMovesTimeTable] = nameMovesTimesTable;
        
        List<ComponentBox> scoreboardTable = new List<ComponentBox>();
        nameMovesTimesTable.Add(new ComponentBox(65, 15, Color.Black, CreateCharBox(13, 29)));
        scoreboardTable.Add (new ComponentBox(66,15, Color.Green, "Name            Time  Moves"));
        _interfaceComponents[Const.ScoreboardTable] = scoreboardTable;

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
            "",
            "",
            "",
            "                Press any key to start new game                      "
        };
        
        
        List<ComponentBox> winMessageComponentBoxes = new List<ComponentBox>();
        winMessageComponentBoxes.Add(new ComponentBox(15, 4, Color.Red, win));
        _interfaceComponents[Const.WinMessage] = winMessageComponentBoxes;
        
        List<ComponentBox> nameComponentBoxes = new List<ComponentBox>();
        nameComponentBoxes.Add(new ComponentBox(Const.NamePosLeft, Const.NamePosTop, Color.Green, CreateCharBox(1, 21)));
        nameComponentBoxes.Add(new ComponentBox(Const.NamePosLeft,Const.NamePosTop, Color.Green, ""));
        _interfaceComponents[Const.Name] = nameComponentBoxes;
        
        List<ComponentBox> movesComponentBoxes = new List<ComponentBox>();
        movesComponentBoxes.Add(new ComponentBox(Const.MovesPosLeft, Const.MovesPosTop, Color.Green, CreateCharBox(1, 21)));
        movesComponentBoxes.Add(new ComponentBox(Const.MovesPosLeft,Const.MovesPosTop, Color.Green, "0"));
        _interfaceComponents[Const.Moves] = movesComponentBoxes;

        List<ComponentBox> timeComponentBoxes = new List<ComponentBox>();
        timeComponentBoxes.Add(new ComponentBox(Const.TimePosLeft, Const.TimePosTop, Color.Green, CreateCharBox(1, 21)));
        timeComponentBoxes.Add(new ComponentBox(Const.TimePosLeft,Const.TimePosTop, Color.Green, "00:00"));
        _interfaceComponents[Const.Time] = timeComponentBoxes;
        
        List<ComponentBox> typeYourNameComponentBoxes = new List<ComponentBox>();
        typeYourNameComponentBoxes.Add(new ComponentBox(73, 1, Color.Green, CreateCharBox(1, 21)));
        typeYourNameComponentBoxes.Add(new ComponentBox(73,1, Color.Green, "Type your Name"));
        _interfaceComponents[Const.TypeYourNameMessage] = typeYourNameComponentBoxes;
    }
    
    public string[] CreateCharBox(int height, int width, char @char=' ')
    {
        if (height < 0) throw new ArgumentException($"height of the Box can not be less than 0");
        if (width < 0) throw new ArgumentException($"width of the Box can not be less than 0");
        
        string[] box = new string[height];
        string boxString = String.Empty;
        
        for (int i = 0; i < width; i++)
        {
            boxString += @char;
        }
        for (int i = 0; i < height; i++)
        {
            box[i] = boxString;
        }
        return box;
    }
    
    public void ShowInterfaceGraphic()
    {
        foreach (var component in _interfaceComponents[Const.Layer0])
        {
            PrintEvent(component); 
        }
        foreach (var component in _interfaceComponents[Const.HowToPlayTable])
        {
            PrintEvent(component); 
        }
        foreach (var component in _interfaceComponents[Const.NameMovesTimeTable])
        {
            PrintEvent(component); 
        }
        foreach (var component in _interfaceComponents[Const.ScoreboardTable])
        {
            PrintEvent(component); 
        }
    }
    
    public void ChangeMoves(int moves)
    {
        string @String = moves.ToString();
        _interfaceComponents[Const.Moves][Const.MoveComponent].ChangeString(@String);//Changing moves in MoveComponent
        
        foreach (var component in _interfaceComponents[Const.Moves]) 
        {
            PrintEvent(component);    
        }
    }
    public void ResetMoves()
    {
        _interfaceComponents[Const.Moves][Const.MoveComponent].ChangeString("0");//Changing moves in MoveComponent
        
        foreach (var component in _interfaceComponents[Const.Moves]) 
        {
            PrintEvent(component);    
        }
    }
    
    
    public void ChangeName(PlayerNameSaveLoadBox playerNameSaveLoadBox)
    {
        string name = playerNameSaveLoadBox.Name;
        _interfaceComponents[Const.Name][Const.NameComponent].ChangeString(name); //Changing name in NameComponent
        foreach (var component in _interfaceComponents[Const.Name])
        {
            PrintEvent(component);
        }
    }
    
    public void ChangeTime(string timeSpent)
    {
        string time = timeSpent;
        _interfaceComponents[Const.Time][Const.TimeComponent].ChangeString(time); //Changing time in TimeComponent
        foreach (var component in _interfaceComponents[Const.Time])
        {
            PrintEvent(component);
        }
    }
    
    
    
    public void WinEvent()
    {
        foreach (var component in _interfaceComponents[Const.WinMessage])
        {
            PrintEvent(component);    
        }
    }
    
    
    public void MoveTileEvent(NumbersIndexBox numbersIndexBox)
    {
        if (numbersIndexBox.PrintNumbers == PrintNumbers.AllNumbers)
        {
            for (int index = 0; index < 16; index++)
            {
                Color color = (numbersIndexBox.Numbers.Skip(index).First() == index+1) ? Color.Green : Color.Yellow;
                int top = _numberCoordinates[index].Top;
                int left = _numberCoordinates[index].Left;
                string[] arr = _numberComponents[numbersIndexBox.Numbers.Skip(index).First()];
                PrintEvent(new ComponentBox(left, top, color, arr));
            }    
        }
        else
        {
            foreach (var index in numbersIndexBox.Index)
            {
                Color color = (numbersIndexBox.Numbers.Skip(index).First() == index + 1) ? Color.Green : Color.Yellow;
                int top = _numberCoordinates[index].Top;
                int left = _numberCoordinates[index].Left;
                string[] arr = _numberComponents[numbersIndexBox.Numbers.Skip(index).First()];
                PrintEvent(new ComponentBox(left, top, color, arr));
            }
        }
    }    
    

    public void ShowScoreboard(List<PlayerSaveLoadBox> scoreboard)
    {
        //Components ScoreBoard
        const int shiftY = 16;
        const int shiftX = 66;
        const int shiftTimeX = 16;
        const int shiftMovesX = 22;
        
        for (int n = 0; n < scoreboard.Count; n++)
        {
            Color color;
            if (n == 0)
            {
                color = Color.Red;
            } else if (n < 3)
            {
                color = Color.Yellow;
            }
            else
            {
                color = Color.Green;
            }
            PrintEvent(new ComponentBox(shiftX, shiftY+n, color, scoreboard[n].Name));
            PrintEvent(new ComponentBox(shiftX + shiftTimeX,shiftY+n, color, scoreboard[n].Ts.ToString(@"mm\:ss")));
            PrintEvent(new ComponentBox(shiftX + shiftMovesX,shiftY+n, color, scoreboard[n].Moves.ToString()));
        }
    }
}