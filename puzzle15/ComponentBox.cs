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
    
    
    public ComponentBox CoordinatesAndColor(int shiftX, int shiftY, ConsoleColor color)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
        return this; 
    }
    
    public void CoordinatesColorAndString(int shiftX, int shiftY, ConsoleColor color, string str)
    {
        CoordinatesColorAndString(shiftX, shiftY, color, new string[] { str });
    }
    
    public void CoordinatesColorAndString(int shiftX, int shiftY, ConsoleColor color, string[] str)
    {
        CoordinatesAndColor(shiftX, shiftY, color);
        String(str);
    }    
    
    public void String(string []str)
    {
        Arr = str;
    }
    
    public void String(string str)
    {
        String(new string[] { str });
    }
}