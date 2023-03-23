namespace Puzzle15;

public class ComponentBox
{
    public int ShiftX { get; private set;} 
    public int ShiftY { get; private set;} 
    public ConsoleColor Color { get; private set;}
    public string[] Str { get; private set;}
    
    public ComponentBox (int shiftX, int shiftY, ConsoleColor color, string[] str)
    {
        this.ShiftX = shiftX;
        this.ShiftY = shiftY;
        this.Color = color;
        this.Str = str;
    }
    public ComponentBox (int shiftX, int shiftY, ConsoleColor color, string str)
    {
        this.ShiftX = shiftX;
        this.ShiftY = shiftY;
        this.Color = color;
        this.Str = new string[] {str};
    }
}