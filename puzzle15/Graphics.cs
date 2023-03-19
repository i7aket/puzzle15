namespace Puzzle15;

public class Graphics
{
    public char[,] Canvas = new char[29, 99];
    public string[,] CanvasColor = new string[29, 99];

    
    public void FillCanvas()
    {
        for (var i = 0; i < Canvas.GetLength(0); i++)
        {
            for (var j = 0; j < Canvas.GetLength(1); j++)
            {
                Canvas[i, j] = '*';
            }
        }
    }    
    
    public void FillColorCanvas()
    {
        for (var i = 0; i < CanvasColor.GetLength(0); i++)
        {
            for (var j = 0; j < CanvasColor.GetLength(1); j++)
            {
                CanvasColor[i, j] = "";
            }
        }
    }

    public void Show()
    {
        for (var i = 0; i < Canvas.GetLength(0); i++)
        {
            for (var j = 0; j < Canvas.GetLength(1); j++)
            {
                switch (CanvasColor[i,j])
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
                    
                Console.Write(Canvas[i, j]);
            }
            Console.WriteLine();
        }
    }
    
    public void InitBoard(int[,] boardArray, int [,] winBoardArray, string [,] dicNum)
    {
        int shiftY = 1;
        for (int line = 0; line < boardArray.GetLength(0); line++)
        {
            int shiftX = 3;
            for (int column = 0; column < boardArray.GetLength(1); column++)
            {
                string color = boardArray[line, column] == winBoardArray[line, column] ? "Green" : "Yellow";
                DrawNumber(boardArray[line,column], shiftY, shiftX, color, dicNum);
                shiftX += 16;
            }
            shiftY += 7;
        }
    }
    
    public void DrawNumber(int element, int shiftY, int shiftX, string color, string [,] dicNum)
    {
        //place where to begin to draw an element

        for (int canvasY = 0; canvasY < dicNum.GetLength(1); canvasY++)
        {
            for (int canvasX = 0; canvasX < dicNum[0, 0].Length; canvasX++)
            {
                Canvas[canvasY + shiftY, canvasX + shiftX] = dicNum[element, canvasY][canvasX];
                CanvasColor[canvasY + shiftY, canvasX + shiftX] = color;
            }
        }
    }
    
    public void DrawMessage (int shiftY, int shiftX, string color, string text)
    {
        //place where to begin to draw an element
        
        for (int canvasX = 0; canvasX < text.Length; canvasX++)
        {
                Canvas[shiftY, canvasX + shiftX] = text[canvasX];
                CanvasColor[shiftY, canvasX + shiftX] = color;
        }
    }
    public void DrawMessage (int shiftY, int shiftX, string color, string [] text)
    {
        //place where to begin to draw an element

        for (int canvasY = 0; canvasY < text.GetLength(0); canvasY++)
        {
            for (int canvasX = 0; canvasX < text[canvasY].Length; canvasX++)
            {
                Canvas[canvasY + shiftY, canvasX + shiftX] = text[canvasY][canvasX];
                CanvasColor[canvasY + shiftY, canvasX + shiftX] = color;
            }
        }
    }

    public void DrawMessage(int shiftY, int shiftX, int shiftTime, int shiftMoves, string color, List<Player> text)
    {
        int lines = text.Count < 12 ? text.Count : 12;
        for (int i = 0; i < lines; i++)
        {
            string color1 = color;
            color1 = i == 0 ? "Red" : color;
            for (int canvasX = 0; canvasX < text[i].Name.Length; canvasX++)
            {
                Canvas[shiftY, canvasX + shiftX] = text[i].Name[canvasX];
                CanvasColor[shiftY, canvasX + shiftX] = color1;
            }

            for (int canvasX = 0; canvasX < text[i].Ts.ToString(@"mm\:ss").Length; canvasX++)
            {
                Canvas[shiftY, canvasX + shiftX + shiftTime] = text[i].Ts.ToString(@"mm\:ss")[canvasX];
                CanvasColor[shiftY, canvasX + shiftX + shiftTime] = color1;
            }

            for (int canvasX = 0; canvasX < text[i].Moves.ToString().Length; canvasX++)
            {
                Canvas[shiftY, canvasX + shiftX + shiftMoves] = text[i].Moves.ToString()[canvasX];
                CanvasColor[shiftY, canvasX + shiftX + shiftMoves] = color1;
            }
            shiftY++;
        }

    }

    public void DrawBoxUsingSymbol(int shiftY, int shiftX, string color, int sizeY, int sizeX, char symbol)
    {
        for (int canvasY = 0; canvasY < sizeY; canvasY++)
        {
            for (int canvasX = 0; canvasX < sizeX; canvasX++)
            {
                Canvas[canvasY + shiftY, canvasX + shiftX] = symbol;
                CanvasColor[canvasY + shiftY, canvasX + shiftX] = color;
            }
        }
    }
} 
