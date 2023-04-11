namespace puzzle15;

public class ConsoleOutput : IOutput
{
    public ConsoleOutput()
    {
        Console.CursorVisible = false;
    }

    public void Print(ComponentBox componentBox)
    {
        if (componentBox.ShiftTop < 0) throw new ArgumentException($"Height can not be less then 0");
        if (componentBox.ShiftLeft < 0) throw new ArgumentException($"Width can not be less then 0");

        for (int line = 0; line < componentBox.Arr.Length; line++)
        {
            Console.ForegroundColor = ColorToConsoleColor (componentBox.Color);
            Console.SetCursorPosition(componentBox.ShiftLeft, componentBox.ShiftTop + line);
            Console.Write(componentBox.Arr[line]);
        }
    }

    public void ClearScreen()
    {
        Console.Clear();
    }

    private ConsoleColor ColorToConsoleColor(Color color)
    {
        switch (color)
        {
            case Color.Black:
                return ConsoleColor.Black;

            case Color.DarkBlue:
                return ConsoleColor.DarkBlue;

            case Color.DarkGreen:
                return ConsoleColor.DarkGreen;

            case Color.DarkCyan:
                return ConsoleColor.DarkCyan;

            case Color.DarkRed:
                return ConsoleColor.DarkRed;

            case Color.DarkMagenta:
                return ConsoleColor.DarkMagenta;

            case Color.DarkYellow:
                return ConsoleColor.DarkYellow;

            case Color.Gray:
                return ConsoleColor.Gray;

            case Color.Blue:
                return ConsoleColor.Blue;

            case Color.Green:
                return ConsoleColor.Green;

            case Color.Cyan:
                return ConsoleColor.Cyan;

            case Color.Red:
                return ConsoleColor.Red;

            case Color.Magenta:
                return ConsoleColor.Magenta;

            case Color.Yellow:
                return ConsoleColor.Yellow;

            case Color.White:
                return ConsoleColor.White;

            default:
                throw new ArgumentException("Invalid color value.");
        }
    }
}
