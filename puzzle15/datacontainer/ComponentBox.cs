namespace puzzle15;

public class ComponentBox
{
    public int ShiftLeft { get; private set;}
    public int ShiftTop { get; private set;}
    public Color Color{ get; private set;}  
    public string[] Arr{ get; private set;}
    

    public ComponentBox (int shiftLeft, int shiftTop, Color color, string[] arr) : this(arr)
    {
        ShiftLeft = shiftLeft;
        ShiftTop = shiftTop;
        Color = color;
    }
    public ComponentBox (int shiftLeft, int shiftTop, Color color, string str) : this(shiftLeft, shiftTop, color, new string[] {str})
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
    
    
    public void CoordinatesAndColor(int shiftLeft, int shiftTop, Color color)
    {
        ShiftLeft = shiftLeft;
        ShiftTop = shiftTop;
        Color = color;
    }
    
    public void CoordinatesColorAndString(int shiftLeft, int shiftTop, Color color, string str)
    {
        CoordinatesColorAndString(shiftLeft, shiftTop, color, new string[] { str });
    }
    
    public void CoordinatesColorAndString(int shiftLeft, int shiftTop, Color color, string[] str)
    {
        CoordinatesAndColor(shiftLeft, shiftTop, color);
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