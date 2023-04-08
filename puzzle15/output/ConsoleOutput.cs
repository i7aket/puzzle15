namespace puzzle15;

public class ConsoleOutput : IOutput
{
    public ConsoleOutput()
    {
        Console.CursorVisible = false;
    }

    public void Print(ComponentBox componentBox)
    {
        if (componentBox.ShiftY < 0) throw new ArgumentException($"Height can not be less then 0");
        if (componentBox.ShiftX < 0) throw new ArgumentException($"Width can not be less then 0");

        for (int line = 0; line < componentBox.Arr.Length; line++)
        {
            Console.ForegroundColor = (ConsoleColor)componentBox.Color;
            Console.SetCursorPosition(componentBox.ShiftX, componentBox.ShiftY + line);
            Console.Write(componentBox.Arr[line]);
        }
    }

    public void ClearScreen()
    {
        Console.Clear();
    }
}
