using System.Text;

namespace puzzle15;
public class Component
{
    public event Action <ComponentBox> PrintEvent;
    
    private readonly Dictionary<int, List<ComponentBox>> _interfaceComponents =
        new Dictionary<int, List<ComponentBox>>();
    private readonly Dictionary<int, CoordinateBox> _numberCoordinates =
        new Dictionary<int, CoordinateBox>();

    public Component()
    {
        int counter = 0; 
        int paddingTop = 1;

        for (int row = 0; row < Const.RowSize + 1; row++)
        {
            var paddingLeft = 1; 
            for (int column = 0; column < Const.ColumnSize + 1; column++)
            {
                _numberCoordinates[counter] = new CoordinateBox(paddingTop, paddingLeft);
                counter++;
                paddingLeft += _numbers[0,0].Length*2+1 ;   // multiply by 2 because we have 2 digits in number component.
            }

            paddingTop += _numbers.GetUpperBound(1) + 1 + 1; //+ height of the Element + padding 
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
        
        howToPlayTable.Add(new ComponentBox(77, 8, Color.Black, CreateCharBox(6, 29)));
        howToPlayTable.Add(new ComponentBox(77, 8, Color.Green, howToPlay));
        howToPlayTable.Add (new ComponentBox(86,11, Color.Red, "esc"));
        howToPlayTable.Add (new ComponentBox(87,12, Color.Red, "N"));
        howToPlayTable.Add (new ComponentBox(86,13, Color.Red, "C"));
        _interfaceComponents[Const.HowToPlayTable] = howToPlayTable;
        
        
        List<ComponentBox> nameMovesTimesTable = new List<ComponentBox>();
        nameMovesTimesTable.Add(new ComponentBox(77, 1, Color.Black, CreateCharBox(6, 29)));
        nameMovesTimesTable.Add(new ComponentBox(77, 1, Color.Green, nameMovesTimes));
        _interfaceComponents[Const.NameMovesTimeTable] = nameMovesTimesTable;
        
        List<ComponentBox> scoreboardTable = new List<ComponentBox>();
        nameMovesTimesTable.Add(new ComponentBox(77, 15, Color.Black, CreateCharBox(13, 29)));
        scoreboardTable.Add (new ComponentBox(78,15, Color.Green, "Name            Time  Moves"));
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
        winMessageComponentBoxes.Add(new ComponentBox(27, 4, Color.Red, win));
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
        typeYourNameComponentBoxes.Add(new ComponentBox(85, 1, Color.Green, CreateCharBox(1, 21)));
        typeYourNameComponentBoxes.Add(new ComponentBox(85,1, Color.Green, "Type your Name"));
        _interfaceComponents[Const.TypeYourNameMessage] = typeYourNameComponentBoxes;
    }

    string[,] _numbers = new[,]
    {
        {
            " ██████╗ ",
            "██╔═████╗",
            "██║██╔██║",
            "████╔╝██║",
            "╚██████╔╝",
            " ╚═════╝ ",
        },
        {
            " ██╗     ",
            "███║     ",
            "╚██║     ",
            " ██║     ",
            " ██║     ",
            " ╚═╝     "
        },
        {
            "██████╗  ",
            "╚════██╗ ",
            " █████╔╝ ",
            "██╔═══╝  ",
            "███████╗ ",
            "╚══════╝ "
        },
        {
            "██████╗  ",
            "╚════██╗ ",
            " █████╔╝ ",
            " ╚═══██╗ ",
            "██████╔╝ ",
            "╚═════╝  "
        },
        {
            "██╗  ██╗ ",
            "██║  ██║ ",
            "███████║ ",
            "╚════██║ ",
            "     ██║ ",
            "     ╚═╝ "
        },
        {
            "███████╗ ",
            "██╔════╝ ",
            "███████╗ ",
            "╚════██║ ",
            "███████║ ",
            "╚══════╝ ",
        },
        {
            " ██████╗ ",
            "██╔════╝ ",
            "███████╗ ",
            "██╔═══██╗",
            "╚██████╔╝",
            " ╚═════╝ "
        },
        {
            "███████╗ ",
            "╚════██║ ",
            "    ██╔╝ ",
            "   ██╔╝  ",
            "   ██║   ",
            "   ╚═╝   "
        },
        {
            " █████╗  ",
            "██╔══██╗ ",
            "╚█████╔╝ ",
            "██╔══██╗ ",
            "╚█████╔╝ ",
            " ╚════╝  "
        },
        {
            " █████╗  ",
            "██╔══██╗ ",
            "╚██████║ ",
            " ╚═══██║ ",
            " █████╔╝ ",
            " ╚════╝  "
        },
        {
            "         ",
            "         ",
            "         ",
            "         ",
            "         ",
            "         "
        },
        {
            "      ██╗",
            "     ███║",
            "     ╚██║",
            "      ██║",
            "      ██║",
            "      ╚═╝"
        },
        
    };

    private string[] CreateNumber(int number)
    {
        string[] arr = new string[_numbers.GetUpperBound(1) + 1];
        
        // int digit1 = (number / 10 == 0) ? 10 : (number / 10 == 1) ? 11 : number / 10; 
        // int digit2 = (digit1 == 10 && number % 10 == 0) ? 10 : number % 10;
        
        
        const int empty = 10;
        const int oneInTwoDigitNumber = 11;

        int digit1 = number / 10;
        int digit2 = number % 10;
    
        if (digit1 == 0)
        {
            digit1 = empty;
        }
        else if (digit1 == 1)
        {
            digit1 = oneInTwoDigitNumber;
        }
    
        if (digit1 == empty && digit2 == 0)
        {
            digit2 = empty;
        }

        for (int i = 0; i <= _numbers.GetUpperBound(1); i++)
        {
            arr[i] = string.Concat(_numbers[digit1, i], _numbers[digit2, i]);
        }

        return arr; 
    }


    
    private string[] CreateCharBox(int height, int width, char @char=' ')
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
            for (int index = 0; index < numbersIndexBox.Numbers.Count(); index++)
            {
                Color color = (numbersIndexBox.Numbers.Skip(index).First() == index + 1) ? Color.Green : Color.Yellow;
                int top = _numberCoordinates[index].Top;
                int left = _numberCoordinates[index].Left;
                string[] arr = CreateNumber(numbersIndexBox.Numbers.Skip(index).First());
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
                string[] arr = CreateNumber(numbersIndexBox.Numbers.Skip(index).First());
                PrintEvent(new ComponentBox(left, top, color, arr));
            }
        }
    }    
    

    public void ShowScoreboard(List<PlayerSaveLoadBox> scoreboard)
    {
        //Components ScoreBoard
        const int shiftTop = 16;
        const int shiftLeft = 78;
        const int shiftLeftTime = 16;
        const int shiftLeftMoves = 22;
        
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
            PrintEvent(new ComponentBox(shiftLeft, shiftTop+n, color, scoreboard[n].Name));
            PrintEvent(new ComponentBox(shiftLeft + shiftLeftTime,shiftTop+n, color, scoreboard[n].Ts.ToString(@"mm\:ss")));
            PrintEvent(new ComponentBox(shiftLeft + shiftLeftMoves,shiftTop+n, color, scoreboard[n].Moves.ToString()));
        }
    }
}
