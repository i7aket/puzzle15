namespace Puzzle15;

public class ComponentBox
{
    public int ShiftX;
    public int ShiftY;
    public ConsoleColor Color;
    public string[] Str;
    
    
    public ComponentBox ()
    {
        
    }
    
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

    public ComponentBox (string[] str)
    {
        this.Str = str;
    }
    
    public ComponentBox (string str)
    {
        this.Str = new string[] {str};
    }
    
    public ComponentBox Set(int shiftX, int shiftY, ConsoleColor color, string str)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
        Str = new string[] {str};
        return this;
    }
    
    public ComponentBox Set(int shiftX, int shiftY, ConsoleColor color, string[] str)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
        Str = str;
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
        Str = new string[] {str};
        return this; 
    }
    public ComponentBox Set(string []str)
    {
        Str = str;
        return this; 
    }
    
}