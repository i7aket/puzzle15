namespace puzzle15;

public class ConsoleInputString : IInputString
{
    public string? InputName()
    {
        Console.SetCursorPosition(85, 1);
        string? input = Console.ReadLine();
        return input;
    }
}