namespace Puzzle15;

public class ComponentBox
{
    public int ShiftX { get; private set;}
    public int ShiftY { get; private set;}
    public ConsoleColor Color{ get; private set;}
    public string[] Arr{ get; private set;}
    
    
    public ComponentBox ()
    {
    }
    
    public ComponentBox (int shiftX, int shiftY, ConsoleColor color, string[] arr)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
        Arr = arr;
    }
    
    public ComponentBox (int shiftX, int shiftY, ConsoleColor color, string str) : this(shiftX, shiftY, color, new string[] {str})
    {
    }

    public ComponentBox (string[] arr) : this(0, 0, ConsoleColor.Black, arr)
    {
    }
    
    public ComponentBox (string str) : this (new string[] {str})
    {
    }
    
    public ComponentBox Set(int shiftX, int shiftY, ConsoleColor color, string str)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
        Arr = new string[] {str};
        return this;
    }
    
    public ComponentBox Set(int shiftX, int shiftY, ConsoleColor color, string[] str)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
        Arr = str;
        return this; 
    }
    
    public ComponentBox Set(int shiftX, int shiftY, ConsoleColor color)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
        return this; 
    }

    public ComponentBox Set(string str)
    {
        Arr = new string[] {str};
        return this; 
    }
    public ComponentBox Set(string []str)
    {
        Arr = str;
        return this; 
    }
    
}