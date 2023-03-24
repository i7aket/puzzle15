namespace Puzzle15;

public class ConsoleOutput
{ 
    public void PrintLayer0()
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
    
    public void PrintEmptyBox(int shiftX, int shiftY, int height, int width)
    {
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                Console.SetCursorPosition(shiftX+x, shiftY+y);
                Console.Write(' '); 
            }
            Console.WriteLine();
        }
    }
    
    public void Print(ComponentBox componentBox)    
    {
        for (int line = 0; line < componentBox.Str.Length; line++)
        {
            Console.ForegroundColor = componentBox.Color;
            Console.SetCursorPosition(componentBox.ShiftX, componentBox.ShiftY+line);
            Console.Write(componentBox.Str[line]);    
        }
    }
}
