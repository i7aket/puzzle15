namespace Puzzle15;

public class Graphics
{
    private ConsoleOutput _consoleOutput = new ConsoleOutput();
    private Components _components = new Components();
    
    
    public Graphics (Player player, GameBoard gameBoard)
    {
        Console.Clear();
        _consoleOutput.PrintLayer0();
        
        _consoleOutput.PrintEmptyBox(65, 1, 6, 29);
        _consoleOutput.PrintEmptyBox(65, 8, 6, 29);
        _consoleOutput.PrintEmptyBox(65, 15, 13, 29);
        _consoleOutput.Print(_components.Strings["NameMovesTimes"]);
        _components.Strings["Name"].String(player.Name);
        _consoleOutput.Print(_components.Strings["Name"]);
        _components.Strings["Moves"].String(gameBoard.GetMoves());
        _consoleOutput.Print(_components.Strings["Moves"]);
        _components.Strings["Time"].String(player.TimeSpent());
        _consoleOutput.Print(_components.Strings["Time"]); 
        _consoleOutput.Print(_components.Strings["HowToPlay"]);
        _consoleOutput.Print(_components.Strings["esc"]);
        _consoleOutput.Print(_components.Strings["N"]);
        _consoleOutput.Print(_components.Strings["C"]);
        _consoleOutput.Print(_components.Strings["NameTimeMoves"]);
        
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
                if (fullInit == true || board.LastMove(row, column))
                {
                    ConsoleColor color = board.CheckPosition(row, column) ? ConsoleColor.Green : ConsoleColor.Yellow;
                    _components.Numbers[board.Board[row, column]].CoordinatesAndColor(shiftX, shiftY, color);
                    _consoleOutput.Print(_components.Numbers[board.Board[row, column]]);
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
            _consoleOutput.Print(c);
        }
    }
    
    public void ChangeTime(Player player )
    {
        _components.Strings["Time"].String(player.TimeSpent());
        _consoleOutput.Print(_components.Strings["Time"]);
    }
    
    public void ChangeMoves(GameBoard gameBoard)
    {
        _components.Strings["Moves"].String(gameBoard.GetMoves());
        _consoleOutput.Print(_components.Strings["Moves"]);
    }
    
    public void ChangeName()
    {
        _consoleOutput.PrintEmptyBox(73, 1, 1, 21);
        _consoleOutput.Print(_components.Strings["Type your Name"]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(73, 1);
    }
    
    public void ShowYouWon()
    {
        _consoleOutput.Print(_components.Strings["Win"]);
        _consoleOutput.Print(_components.Strings["Win2"]);
    }
}