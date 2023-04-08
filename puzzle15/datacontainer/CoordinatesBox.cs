namespace puzzle15;

public class CoordinateBox
{
    public int Top { get; private set; }
    public int Left { get; private set; }

    public CoordinateBox(int top, int left)
    {
        Top = top;
        Left = left;
    }
}