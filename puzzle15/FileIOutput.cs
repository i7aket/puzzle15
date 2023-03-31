namespace Puzzle15;

public class FileIOutput : IOutput

{
    private const int Height = 29;
    private const int Width = 95;
    private char[,] _buffer = new char [Height,Width];

    
    public FileIOutput()
    {
        using StreamWriter save = new StreamWriter("f.txt");
        save.Write("");
    }
    
    public void PrintLayer0()
    {
        using StreamWriter save = new StreamWriter("f.txt");
        for (var y = 0; y < Height; y++)
        {
            string line = String.Empty;
            for (var x = 0; x < Width; x++)
            {
                _buffer[y, x] = '*';
                line += "*";
            }
            save.WriteLine(line);
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
                _buffer[shiftY + y, shiftX + x] = ' ';
            }
        }
        BufferWriteToFile();
    }

    public void Print(ComponentBox componentBox)
    {
        CheckCoordinates(componentBox.ShiftY, componentBox.ShiftX);
        
        for (int line = 0; line < componentBox.Arr.Length; line++)
        {
            char[] chars = componentBox.Arr[line].ToCharArray();
            for (int i = 0; i < componentBox.Arr[line].Length; i++)
            {
                _buffer[componentBox.ShiftY + line, componentBox.ShiftX + i] = chars[i];
            }
        }
        BufferWriteToFile();
    }

    private void CheckCoordinates(int height, int width)
    {
        if (height < 0 || height > Height) throw new ArgumentException($"Height can not be less then 0 or greater than {Height}");
        if (width < 0 || width > Width) throw new ArgumentException($"Width can not be less then 0 or greater than {Height}");
    }

    private void BufferWriteToFile()
    {
        using StreamWriter save = new StreamWriter("f.txt");
        for (var y = 0; y < Height; y++)
        {
            string line = String.Empty;
            for (var x = 0; x < Width; x++)
            {
                 line += _buffer[y, x].ToString();
            }
            save.WriteLine(line);
        }
    } 

    public void Clear()
    {
        using StreamWriter save = new StreamWriter("f.txt");
        save.Write("");
    }
}


