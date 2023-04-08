namespace puzzle15;

public class ConsoleInputString : IInputString
{
    public string? InputName()
    {
        Console.SetCursorPosition(Const.NamePosLeft, Const.NamePosTop);
        string? input = Console.ReadLine();
        return input;
    }
}