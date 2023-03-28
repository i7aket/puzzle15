namespace Puzzle15;

public class Game
{
    GameBoard _gameBoard;
    ScoreBoard _scoreBoard;
    Player _player;
    Graphics _graphics;
    private Timer _timer;

    public Game()
    {
        _gameBoard = new GameBoard();
        _scoreBoard = new ScoreBoard();
        _player = new Player();
        _graphics = new Graphics(_player, _gameBoard);
        Begin();
    }

    void NewGame()
    {
        _player = new Player();
        _gameBoard = new GameBoard();
        _graphics = new Graphics(_player, _gameBoard);
    }
    void ChangeName()
    {
        _graphics.ChangeName();
        _player.ChangeName();
        _graphics = new Graphics(_player, _gameBoard);
    }
    
    private void Begin()
    {
        _timer = new Timer(e => { _graphics.ChangeTime(_player); }, null, 1000, 1000);
        
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
                    _timer.Change(Timeout.Infinite,  Timeout.Infinite);
                    ChangeName();
                    _timer.Change(1000, 1000);
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
                _timer.Change(Timeout.Infinite,  Timeout.Infinite);
                _graphics.ShowYouWon();
                _player.TimeSpent();
                _player.SetMoves(_gameBoard);
                _scoreBoard.AddPlayer(_player);
                _scoreBoard.Sort();
                _scoreBoard.SaveList();
                Console.ReadKey();
                NewGame();
                _timer.Change(1000,  1000);
            }
        } while (e.Key != ConsoleKey.Escape);
    }
}