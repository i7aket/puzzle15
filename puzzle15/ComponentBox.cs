namespace Puzzle15;

public class ComponentBox
{
    public int ShiftX { get; private set;}
    public int ShiftY { get; private set;}
    public ConsoleColor Color{ get; private set;}  
    public string[] Arr{ get; private set;}
    

    public ComponentBox (int shiftX, int shiftY, ConsoleColor color, string[] arr) : this(arr)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
    }
    public ComponentBox (int shiftX, int shiftY, ConsoleColor color, string str) : this(shiftX, shiftY, color, new string[] {str})
    {
    }
    public ComponentBox (string[] arr)
    {
        Arr = arr;
    }
    public ComponentBox () : this(string.Empty)
    {
    }
    
    public ComponentBox (string str) : this (new string []  {str})
    {
    }
    public ComponentBox Set(int shiftX, int shiftY, ConsoleColor color)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
        return this; 
    }
    public ComponentBox Set(string []str)
    {
        Arr = str;
        return this; 
    }
    public ComponentBox Set(string str)
    {
        Set(new string[] { str });
        return this; 
    }
    public ComponentBox Set(int shiftX, int shiftY, ConsoleColor color, string str)
    {
        Set(shiftX, shiftY, color, new string[] { str });
        return this;
    }
    public ComponentBox Set(int shiftX, int shiftY, ConsoleColor color, string[] str)
    {
        Set(shiftX, shiftY, color);
        Set(str);
        return this; 
    }
}