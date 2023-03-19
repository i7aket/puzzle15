namespace Puzzle15;

public class Display
{
    private char[,] _canvas  = new char[29, 99];
    private string[,] _canvasColor = new string[29, 99];
    private Labels _label  = new Labels();
    

    public void FillCanvas()
    {
        for (var i = 0; i < _canvas.GetLength(0); i++)
        {
            for (var j = 0; j < _canvas.GetLength(1); j++)
            {
                _canvas[i, j] = '*';
            }
        }
    }    
    
    public void FillColorCanvas()
    {
        for (var i = 0; i < _canvasColor.GetLength(0); i++)
        {
            for (var j = 0; j < _canvasColor.GetLength(1); j++)
            {
                _canvasColor[i, j] = "";
            }
        }
    }


    public void InitInterface(string name, List<Player> playersList)
    {
        DrawLabel(8,68, "Green", _label.HowToPlay);
        DrawLabel(1,68, "Green", _label.NameMovesTimes);
        DrawLabel(3,77, "Green", "0"); //moves
        DrawLabel(1,77, "Green", name);
        DrawLabel(5,77, "Green", "00:00"); //time
        DrawBoxUsingSymbol(15, 68, "Green", 13, 29, ' ');
        DrawLabel(15,69, "Green", _label.ScoreTable); 
        DrawLabel(16,69, 16, 22, "Green", playersList);
    }

    public void ChangeName(string playerName)
    {
        DrawLabel(1, 77, "Green", _label.EmptyNameField);
        DrawLabel(1, 77, "Green", playerName);
    }
    
    public void ChangeMovesAndTime(string moves, string timeSpent )
    {
        DrawLabel(3, 77, "Green", moves);
        DrawLabel(5, 77, "Green", timeSpent);
    }

    public void ShowYouWIn()
    {
        DrawLabel(4, 15, "Red", _label.Win);
    }
    

    public void Draw()
    {
        for (var i = 0; i < _canvas.GetLength(0); i++)
        {
            for (var j = 0; j < _canvas.GetLength(1); j++)
            {
                switch (_canvasColor[i,j])
                {
                    case "DarkYellow":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    
                    case "Red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    
                    case "Green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    
                    case "Yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    
                    default: Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                }
                    
                Console.Write(_canvas[i, j]);
            }
            Console.WriteLine();
        }
    }
    
    public void InitBoard(GameBoard board)
    {
        int shiftY = 1;
        for (int line = 0; line < board.Board.GetLength(0); line++)
        {
            int shiftX = 3;
            for (int column = 0; column < board.Board.GetLength(1); column++)
            {
                string color = board.Board[line, column] == board.WinBoard[line, column] ? "Green" : "Yellow";
                DrawNumber(board.Board[line,column], shiftY, shiftX, color);
                shiftX += 16;
            }
            shiftY += 7;
        }
    }

    private void DrawNumber(int element, int shiftY, int shiftX, string color)
    {
        for (int canvasY = 0; canvasY < _label.Numbers.GetLength(1); canvasY++)
        {
            for (int canvasX = 0; canvasX < _label.Numbers[0, 0].Length; canvasX++)
            {
                _canvas[canvasY + shiftY, canvasX + shiftX] = _label.Numbers[element, canvasY][canvasX];
                _canvasColor[canvasY + shiftY, canvasX + shiftX] = color;
            }
        }
    }

    private void DrawLabel (int shiftY, int shiftX, string color, string text)
    {
        //place where to begin to draw an element
        
        for (int canvasX = 0; canvasX < text.Length; canvasX++)
        {
                _canvas[shiftY, canvasX + shiftX] = text[canvasX];
                _canvasColor[shiftY, canvasX + shiftX] = color;
        }
    }

    private void DrawLabel (int shiftY, int shiftX, string color, string [] text)
    {
        //place where to begin to draw an element

        for (int canvasY = 0; canvasY < text.GetLength(0); canvasY++)
        {
            for (int canvasX = 0; canvasX < text[canvasY].Length; canvasX++)
            {
                _canvas[canvasY + shiftY, canvasX + shiftX] = text[canvasY][canvasX];
                _canvasColor[canvasY + shiftY, canvasX + shiftX] = color;
            }
        }
    }

    private void DrawLabel(int shiftY, int shiftX, int shiftTime, int shiftMoves, string color, List<Player> text)
    {
        int lines = text.Count < 12 ? text.Count : 12;
        for (int i = 0; i < lines; i++)
        {
            string color1 = color;
            color1 = i == 0 ? "Red" : color;
            for (int canvasX = 0; canvasX < text[i].Name.Length; canvasX++)
            {
                _canvas[shiftY, canvasX + shiftX] = text[i].Name[canvasX];
                _canvasColor[shiftY, canvasX + shiftX] = color1;
            }

            for (int canvasX = 0; canvasX < text[i].Ts.ToString(@"mm\:ss").Length; canvasX++)
            {
                _canvas[shiftY, canvasX + shiftX + shiftTime] = text[i].Ts.ToString(@"mm\:ss")[canvasX];
                _canvasColor[shiftY, canvasX + shiftX + shiftTime] = color1;
            }

            for (int canvasX = 0; canvasX < text[i].Moves.ToString().Length; canvasX++)
            {
                _canvas[shiftY, canvasX + shiftX + shiftMoves] = text[i].Moves.ToString()[canvasX];
                _canvasColor[shiftY, canvasX + shiftX + shiftMoves] = color1;
            }
            shiftY++;
        }

    }

    private void DrawBoxUsingSymbol(int shiftY, int shiftX, string color, int sizeY, int sizeX, char symbol)
    {
        for (int canvasY = 0; canvasY < sizeY; canvasY++)
        {
            for (int canvasX = 0; canvasX < sizeX; canvasX++)
            {
                _canvas[canvasY + shiftY, canvasX + shiftX] = symbol;
                _canvasColor[canvasY + shiftY, canvasX + shiftX] = color;
            }
        }
    }
} 
