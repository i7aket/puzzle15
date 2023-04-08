namespace puzzle15;

public class InputControlsKeyboard : IInputControls
{
    public KeyPressed Key()
    {
        ConsoleKeyInfo e = Console.ReadKey();
        switch (e.Key)
        {
            //Moving Tiles
            case ConsoleKey.RightArrow:
                return KeyPressed.Right;

            case ConsoleKey.DownArrow:
                return KeyPressed.Down;

            case ConsoleKey.LeftArrow:
                return KeyPressed.Left;

            case ConsoleKey.UpArrow:
                return KeyPressed.Up;


            // Setup Controls
            case ConsoleKey.N:
                return KeyPressed.NewGame;

            case ConsoleKey.C:
                return KeyPressed.ChangeName;

            case ConsoleKey.Escape:
                return KeyPressed.EndGame;

            case ConsoleKey.W:
                return KeyPressed.WinDebug;

            case ConsoleKey.D:
                return KeyPressed.Debug;
        }
        return KeyPressed.Empty;
    }

    public void Hold()
    {
        Console.ReadKey();
    }
}