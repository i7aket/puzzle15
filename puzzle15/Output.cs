namespace Puzzle15;

public class Output
{
    public void Layer0()
    {
        Console.Clear();
        for (var y = 0; y < 29; y++)
        {
            for (var x = 0; x < 95; x++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('*');
            }
            Console.WriteLine();
        }
    }
    
    public void Layer1CharBox(int shiftY, int shiftX, int height, int width , char symbol, ConsoleColor color=ConsoleColor.Yellow)
    {
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(shiftX+x, shiftY+y);
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }
    
    public void Layer2(int shiftY, int shiftX, ConsoleColor color, string label)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(shiftX, shiftY);
        Console.Write(label);
    }
    
    public void Layer2(int shiftY, int shiftX, ConsoleColor color, string[] label)
    {
        for (int row = 0; row < label.Length; row++)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(shiftX, shiftY+row);
            Console.Write(label[row]);
        }
    }
    public void Layer2(int shiftY, int shiftX, ConsoleColor color, string[,] label, int el)
    {
        for (int row = 0; row < label.GetLength(1); row++)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(shiftX, shiftY+row);
            Console.Write(label[el,row]);
        }
    }
}