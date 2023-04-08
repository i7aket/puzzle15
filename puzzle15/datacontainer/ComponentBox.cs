namespace puzzle15;

public class ComponentBox
{
    public int ShiftX { get; private set;}
    public int ShiftY { get; private set;}
    public Color Color{ get; private set;}  
    public string[] Arr{ get; private set;}
    

    public ComponentBox (int shiftX, int shiftY, Color color, string[] arr) : this(arr)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
    }
    public ComponentBox (int shiftX, int shiftY, Color color, string str) : this(shiftX, shiftY, color, new string[] {str})
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
    
    
    public ComponentBox CoordinatesAndColor(int shiftX, int shiftY, Color color)
    {
        ShiftX = shiftX;
        ShiftY = shiftY;
        Color = color;
        return this; 
    }
    
    public void CoordinatesColorAndString(int shiftX, int shiftY, Color color, string str)
    {
        CoordinatesColorAndString(shiftX, shiftY, color, new string[] { str });
    }
    
    public void CoordinatesColorAndString(int shiftX, int shiftY, Color color, string[] str)
    {
        CoordinatesAndColor(shiftX, shiftY, color);
        ChangeString(str);
    }    
    
    public void ChangeString(string []str)
    {
        Arr = str;
    }
    
    public void ChangeString(string str)
    {
        ChangeString(new string[] { str });
    }
}