namespace Puzzle15;

public class Graphics
{
    
    private readonly IOutput _writer;
    private readonly Components _components = new Components();
    
    public Graphics (Player player, GameBoard gameBoard)
    {
        
        Console.WriteLine("Default output is Console, Press F to change out to File");
        var e = Console.ReadKey();
        switch (e.Key)
        {
            case ConsoleKey.F:
                _writer = new FileIOutput();
                break;
            default: _writer = new ConsoleIOutput();
                break;
        }
        
        _writer.Clear();
        _writer.PrintLayer0();
        _writer.PrintEmptyBox(65, 1, 6, 29);
        _writer.PrintEmptyBox(65, 8, 6, 29);
        _writer.PrintEmptyBox(65, 15, 13, 29);
        _writer.Print(_components.Strings["NameMovesTimes"]);
        _components.Strings["Name"].String(player.Name);
        _writer.Print(_components.Strings["Name"]);
        _components.Strings["Moves"].String(gameBoard.GetMoves());
        _writer.Print(_components.Strings["Moves"]);
        _components.Strings["Time"].String(player.TimeSpent());
        _writer.Print(_components.Strings["Time"]);
        _writer.Print(_components.Strings["HowToPlay"]);
        _writer.Print(_components.Strings["esc"]);
        _writer.Print(_components.Strings["N"]);
        _writer.Print(_components.Strings["C"]);
        _writer.Print(_components.Strings["NameTimeMoves"]);
        InitBoard(gameBoard, true);
        InitScoreBoard();
    }
    
    
    public void InitBoard(GameBoard board, bool fullInit = false)
    {

        int shiftY = 1;
        
        for (int row = 0; row < 4; row++)
        {
            int shiftX = 1;
            for (int column = 0; column < 4; column++)
            {
                if (fullInit || board.LastMove(row, column))
                {
                    ConsoleColor color = board.CheckPosition(row, column) ? ConsoleColor.Green : ConsoleColor.Yellow;
                    _components.Numbers[board.Board[row, column]].CoordinatesAndColor(shiftX, shiftY, color);
                    _writer.Print(_components.Numbers[board.Board[row, column]]);
                }
                shiftX += 16;
            }
            shiftY += 7;
        }
        Console.SetCursorPosition(0, 30);
    }
    
    private void InitScoreBoard()
    {
        foreach (var c in _components.ScoreBoard)
        {
            _writer.Print(c);
        }
    }
    
    public void ChangeTime(Player player )
    {
        _components.Strings["Time"].String(player.TimeSpent());
        _writer.Print(_components.Strings["Time"]);
    }
    
    public void ChangeMoves(GameBoard gameBoard)
    {
        _components.Strings["Moves"].String(gameBoard.GetMoves());
        _writer.Print(_components.Strings["Moves"]);
    }
    
    public void ChangeName()
    {
        _writer.PrintEmptyBox(73, 1, 1, 21);
        _writer.Print(_components.Strings["Type your Name"]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(73, 1);
    }
    
    public void ShowYouWon()
    {
        _writer.Print(_components.Strings["Win"]);
        _writer.Print(_components.Strings["Win2"]);
    }
}