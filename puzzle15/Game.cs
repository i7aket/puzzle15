namespace Puzzle15;

public class Game
{
    GameBoard _gameBoard;
    Player _player;
    ScoreBoard _scoreBoard;
    Graphics _graphics;
    private ChangeTimeSpent _timer;

    public Game()
    {
        _gameBoard = new GameBoard();
        _player = new Player();
        _scoreBoard = new ScoreBoard();
        _graphics = new Graphics(_player, _gameBoard);
        Begin();
    }

    void NewGame()
    {
        
        _player = new Player();
        _gameBoard = new GameBoard();
        //_scoreBoard = new ScoreBoard();
        _graphics = new Graphics(_player, _gameBoard);
    }
    
    private void Callback(object? state)
    {
        _graphics.ChangeTime(_player);
    }

    private void Begin()
    {
        _timer = new ChangeTimeSpent(Callback);
        
        ConsoleKeyInfo e;
        do
        {
            e = Console.ReadKey();
            switch (e.Key)
            {
                case ConsoleKey.RightArrow: _gameBoard.Right();
                    break;

                case ConsoleKey.DownArrow: _gameBoard.Down();
                    break;

                case ConsoleKey.LeftArrow: _gameBoard.Left();
                    break;

                case ConsoleKey.UpArrow: _gameBoard.Up();
                    break;

                //New Game
                case ConsoleKey.N:
                    NewGame();
                    break;

                case ConsoleKey.C:
                    _timer.Stop();
                    _graphics.ChangeName();
                    _player.ChangeName();
                    _graphics = new Graphics(_player, _gameBoard);
                    _timer.Start();
                    break;

                //debugging win condition
                case ConsoleKey.W:
                    _gameBoard.DefaultPosition();
                    break;
                
                case ConsoleKey.D:
                    //Console.ReadKey();
                    break;
                
                
            }
            _graphics.ChangeMoves(_gameBoard);
            _graphics.InitBoard(_gameBoard);
            
            if (_gameBoard.CheckWin())
            {
                _timer.Stop();
                _graphics.ShowYouWon();
                _player.TimeSpent();
                _player.SetMoves(_gameBoard);
                _scoreBoard.AddPlayer(_player);
                _scoreBoard.Sort();
                _scoreBoard.SaveList();
                Console.ReadKey();
                NewGame();
                _timer.Start();
            }
        } while (e.Key != ConsoleKey.Escape);
    }
}