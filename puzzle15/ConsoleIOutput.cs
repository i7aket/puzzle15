namespace Puzzle15;

public class ConsoleIOutput : IOutput
{
    private const int Height = 29;
    private const int Width = 95;

    public void PrintLayer0()
    {
        Console.Clear();
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('*');
            }
            Console.WriteLine();
        }
    }

    public void PrintEmptyBox(int shiftX, int shiftY, int height, int width)
    {
        CheckCoordinates(shiftY, shiftX);
        if (height < 0) throw new ArgumentException($"Height of the Box can not be less than 0");
        if (width < 0) throw new ArgumentException($"Width of the Box can not be less than 0");
        if (shiftX + width > Width) throw new ArgumentException("Box width is out of view range");
        if (shiftY + height > Height) throw new ArgumentException("Box height is out of view range");
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                Console.SetCursorPosition(shiftX + x, shiftY + y);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }

    public void Print(ComponentBox componentBox)
    {
        CheckCoordinates(componentBox.ShiftY, componentBox.ShiftX);
        for (int line = 0; line < componentBox.Arr.Length; line++)
        {
            Console.ForegroundColor = componentBox.Color;
            Console.SetCursorPosition(componentBox.ShiftX, componentBox.ShiftY + line);
            Console.Write(componentBox.Arr[line]);
        }
    }

    private void CheckCoordinates(int height, int width)
    {
        if (height < 0 || height > Height) throw new ArgumentException($"Height can not be less then 0 or greater than {Height}");
        if (width < 0 || width > Width) throw new ArgumentException($"Width can not be less then 0 or greater than {Height}");
    }

    public void Clear()
    {
        Console.Clear();
    }
}
