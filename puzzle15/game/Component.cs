namespace puzzle15;
public class Component
{
    private readonly int _elementNumberWidth;
    private readonly int _elementNumberHeight;
    private readonly int _padding;
    private readonly int _shiftTop;
    private readonly int _shiftLeft;

    public event Action <ComponentBox> PrintEvent;
    
    private readonly Dictionary<int, List<ComponentBox>> _interfaceComponents =
        new Dictionary<int, List<ComponentBox>>();
    private readonly Dictionary<int, CoordinateBox> _numberCoordinates =
        new Dictionary<int, CoordinateBox>();
    
    public Component()
    {
        _elementNumberWidth = _numbers[0, 0].Length * 2; // numbers consists of 2 digits 
        _elementNumberHeight = _numbers.GetUpperBound(1) + 1;
        _padding = 1;
        _shiftTop = _padding + (_elementNumberHeight + _padding) * (GamePuzzle15.Rows);
        _shiftLeft = _padding + (_elementNumberWidth + _padding) * (GamePuzzle15.Columns);

        // Setting up coordinates of numbers 
        int counter = 0;
        int shiftNumberTop = _padding;

        for (int row = 0; row < GamePuzzle15.Rows; row++)
        {
            var shiftNumberLeft = _padding;
            for (int column = 0; column < GamePuzzle15.Columns; column++)
            {
                _numberCoordinates[counter++] = new CoordinateBox(shiftNumberTop, shiftNumberLeft);
                shiftNumberLeft += _elementNumberWidth + _padding;
            }

            shiftNumberTop += _elementNumberHeight + _padding;
        }


        string[] howToPlay = new[]
        {
            "   Use cursor control keys   ",
            " (the arrows) to move blocks ",
            "                             ",
            "   Press esc to exit Game    ",
            "    Press N for New Game     ",
            "   Press C to change name    ",
        };

        string[] nameMovesTimes = new[]
        {
            " Name:  ",
            "",
            " Moves: ",
            "",
            " Time:  ",
            ""
        };

        //Component Layer0
        List<ComponentBox> layer0 = new List<ComponentBox>();
        layer0.Add(new ComponentBox(0, 0, Color.Yellow,
            CreateCharBox(_shiftTop, _padding + _shiftLeft + howToPlay[0].Length, '*')));
        _interfaceComponents[Const.Layer0] = layer0;

        List<ComponentBox> howToPlayTable = new List<ComponentBox>();

        howToPlayTable.Add(new ComponentBox(_shiftLeft, _padding + _elementNumberHeight + _padding, Color.Black,
            CreateCharBox(6, 29)));
        howToPlayTable.Add(new ComponentBox(_shiftLeft, _padding + _elementNumberHeight + _padding, Color.Green,
            howToPlay));
        howToPlayTable.Add(new ComponentBox(_shiftLeft + 9, _padding + _elementNumberHeight + _padding + 3, Color.Red,
            "esc"));
        howToPlayTable.Add(new ComponentBox(_shiftLeft + 10, _padding + _elementNumberHeight + _padding + 4, Color.Red,
            "N"));
        howToPlayTable.Add(new ComponentBox(_shiftLeft + 9, _padding + _elementNumberHeight + _padding + 5, Color.Red,
            "C"));
        _interfaceComponents[Const.HowToPlayTable] = howToPlayTable;

        List<ComponentBox> nameMovesTimesTable = new List<ComponentBox>();
        nameMovesTimesTable.Add(new ComponentBox(_shiftLeft, _padding, Color.Black, CreateCharBox(howToPlay.GetUpperBound(0) + 1, howToPlay[0].Length)));
        nameMovesTimesTable.Add(new ComponentBox(_shiftLeft, _padding, Color.Green, nameMovesTimes));
        _interfaceComponents[Const.NameMovesTimeTable] = nameMovesTimesTable;


        string[] win = new[]
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
            "",
            "",
            "",
            "                Press any key to start new game                      "
        };

        List<ComponentBox> winMessageComponentBoxes = new List<ComponentBox>();
        winMessageComponentBoxes.Add(new ComponentBox((_shiftLeft + howToPlay[0].Length) / 2 - win[0].Length / 2,
            _shiftTop / 2 - win.Length / 2, Color.Red, win));
        _interfaceComponents[Const.WinMessage] = winMessageComponentBoxes;


        List<ComponentBox> nameComponentBoxes = new List<ComponentBox>();
        nameComponentBoxes.Add(new ComponentBox(_shiftLeft + nameMovesTimes[0].Length, _padding, Color.Green,
            CreateCharBox(1, 21)));
        nameComponentBoxes.Add(new ComponentBox(_shiftLeft + nameMovesTimes[0].Length, _padding, Color.Green, ""));
        _interfaceComponents[Const.Name] = nameComponentBoxes;

        List<ComponentBox> movesComponentBoxes = new List<ComponentBox>();
        movesComponentBoxes.Add(new ComponentBox(_shiftLeft + nameMovesTimes[0].Length, _padding + 2, Color.Green,
            CreateCharBox(1, 21)));
        movesComponentBoxes.Add(new ComponentBox(_shiftLeft + nameMovesTimes[0].Length, _padding + 2, Color.Green,
            "0"));
        _interfaceComponents[Const.Moves] = movesComponentBoxes;

        List<ComponentBox> timeComponentBoxes = new List<ComponentBox>();
        timeComponentBoxes.Add(new ComponentBox(_shiftLeft + nameMovesTimes[0].Length, _padding + 4, Color.Green,
            CreateCharBox(1, 21)));
        timeComponentBoxes.Add(new ComponentBox(_shiftLeft + nameMovesTimes[0].Length, _padding + 4, Color.Green,
            "00:00"));
        _interfaceComponents[Const.Time] = timeComponentBoxes;
        
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
        int scoreboardShiftTop = _padding + _elementNumberHeight + _padding + _elementNumberHeight +  _padding + _padding;
        int scoreboardShiftLeft = _shiftLeft + _padding;
        int scoreboardShiftLeftTime = Const.MaxNameLength; 
        int scoreboardShiftLeftMoves = 22;
        int scoreBoardMaxLines = 0;
        
        if (GamePuzzle15.Rows <= 3) 
        {
            scoreBoardMaxLines = _elementNumberHeight - _padding;    
        }
        else
        {
            scoreBoardMaxLines += _elementNumberHeight + _elementNumberHeight + (GamePuzzle15.Rows - 4) * (_elementNumberHeight +_padding);
        }
        
        
        int scoreboardLines = scoreBoardMaxLines > scoreboard.Count ? scoreboard.Count : scoreBoardMaxLines;
        
        PrintEvent (new ComponentBox(_shiftLeft, 15, Color.Black, CreateCharBox(scoreBoardMaxLines+_padding, 29)));
        PrintEvent (new ComponentBox(_shiftLeft+_padding,15, Color.Green, "Name            Time  Moves"));
        
        for (int n = 0; n < scoreboardLines; n++)
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
            PrintEvent(new ComponentBox(scoreboardShiftLeft, scoreboardShiftTop+n, color, scoreboard[n].Name));
            PrintEvent(new ComponentBox(scoreboardShiftLeft + scoreboardShiftLeftTime,scoreboardShiftTop+n, color, scoreboard[n].Ts.ToString(@"mm\:ss")));
            PrintEvent(new ComponentBox(scoreboardShiftLeft + scoreboardShiftLeftMoves,scoreboardShiftTop+n, color, scoreboard[n].Moves.ToString()));
        }
    }
}
