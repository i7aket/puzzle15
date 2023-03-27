namespace Puzzle15;

public class Graphics
{
    private ConsoleOutput _consoleOutput = new ConsoleOutput();
    private ComponentBox _componentBox = new ComponentBox();
    private Components _components = new Components();
    
    
    public Graphics (Player player, GameBoard gameBoard, ScoreBoard scoreBoard)
    {
        Console.Clear();
        _consoleOutput.PrintLayer0();
        
        _consoleOutput.PrintEmptyBox(65, 1, 6, 29);
        _consoleOutput.PrintEmptyBox(65, 8, 6, 29);
        _consoleOutput.PrintEmptyBox(65, 15, 13, 29);
        
        _consoleOutput.Print(_components.Strings["NameMovesTimes"]);
        _consoleOutput.Print(_components.Strings["Name"].String(player.Name));
        _consoleOutput.Print(_components.Strings["Moves"]);
        _consoleOutput.Print(_components.Strings["Time"]); 
        _consoleOutput.Print(_components.Strings["HowToPlay"]);
        _consoleOutput.Print(_components.Strings["esc"]);
        _consoleOutput.Print(_components.Strings["N"]);
        _consoleOutput.Print(_components.Strings["C"]);
        _consoleOutput.Print(_components.Strings["NameTimeMoves"]);
        
        InitBoard(gameBoard);
        InitScoreBoard(scoreBoard);
    }
    

    public void InitBoard(GameBoard board)
    {
        int shiftY = 1;
        
        for (int row = 0; row < 4; row++)
        {
            int shiftX = 1;
            for (int column = 0; column < 4; column++)
            {
                if (board.LastMove(row, column))
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
    

    private void InitScoreBoard(ScoreBoard scoreBoard)
    {
        int shiftY = 16;
        int shiftX = 66;
        int shiftTimeX = 16;
        int shiftMovesX = 22;
            
        int lines = scoreBoard.CountPlayers() < 12 ? scoreBoard.CountPlayers() : 12;
        for (int n = 0; n < lines; n++)
        {

            ConsoleColor color;
            if (n == 0)
            {
                color = ConsoleColor.Red;
            } else if (n < 3)
            {
                color = ConsoleColor.Yellow;
            }
            else
            {
                color = ConsoleColor.Green;
            }
            _consoleOutput.Print(_componentBox.CoordinatesColorAndString(shiftX, shiftY+n, color, scoreBoard.PlayerName(n)));
            _consoleOutput.Print(_componentBox.CoordinatesColorAndString(shiftX + shiftTimeX,shiftY+n, color, scoreBoard.PlayerTime(n)));
            _consoleOutput.Print(_componentBox.CoordinatesColorAndString (shiftX + shiftMovesX,shiftY+n, color, scoreBoard.PlayerMoves(n)));
        }
    }
    
    public void ChangeTime(Player player )
    {
        _consoleOutput.Print(_components.Strings["Time"].String(player.TimeSpent()));
    }
    
    public void ChangeMoves(GameBoard gameBoard)
    {
        _consoleOutput.Print(_components.Strings["Moves"].String(gameBoard.GetMoves()));
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