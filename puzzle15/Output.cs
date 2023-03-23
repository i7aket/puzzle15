namespace Puzzle15;

public static class Output
{
    public static void Layer0()
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
    
    public static void Layer1CharBox(int shiftY, int shiftX, int height, int width , char symbol, ConsoleColor color=ConsoleColor.Yellow)
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
    
    public static void Layer2(int shiftY, int shiftX, ConsoleColor color, string label)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(shiftX, shiftY);
        Console.Write(label);
    }
    
    public static void Layer2(int shiftY, int shiftX, ConsoleColor color, string[] label)
    {
        for (int row = 0; row < label.Length; row++)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(shiftX, shiftY+row);
            Console.Write(label[row]);
        }
    }
    public static void Layer2(int shiftY, int shiftX, ConsoleColor color, string[,] label, int el)
    {
        for (int row = 0; row < label.GetLength(1); row++)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(shiftX, shiftY+row);
            Console.Write(label[el,row]);
        }
    }
    
    public static void Layer3(ComponentNumber componentNumber)    {
        for (int line = 0; line < componentNumber.lines; line++)
        {
            Console.ForegroundColor = componentNumber.color;
            Console.SetCursorPosition(componentNumber.ShiftX, componentNumber.ShiftY+line);
            Console.Write(componentNumber.number[line]);    
        }
    }
}