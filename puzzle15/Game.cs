namespace Puzzle15;

public class Game
{
    GameBoard _gameBoard;
    ScoreBoard _scoreBoard;
    Player _player;
    Graphics _graphics;
    private Timer timer;

    public Game()
    {
        _gameBoard = new GameBoard();
        _scoreBoard = new ScoreBoard();
        _player = new Player();
        _graphics = new Graphics(_player, _gameBoard ,_scoreBoard);
        Begin();
    }

    void NewGame()
    {
        _player = new Player();
        _gameBoard = new GameBoard();
        _graphics = new Graphics(_player, _gameBoard ,_scoreBoard);
    }
    void ChangeName()
    {
        _graphics.ChangeName();
        _player.ChangeName();
        _graphics = new Graphics(_player, _gameBoard ,_scoreBoard);
    }
    
    public void Begin()
    {
        timer = new Timer(e => { _graphics.ChangeTime(_player); }, null, 1000, 1000);
        
        ConsoleKeyInfo e;
        do
        {
            e = Console.ReadKey();
            switch (e.Key)
            {
                case ConsoleKey.RightArrow: _gameBoard.Move("Right");
                    break;

                case ConsoleKey.DownArrow: _gameBoard.Move("Down");
                    break;

                case ConsoleKey.LeftArrow: _gameBoard.Move("Left");
                    break;

                case ConsoleKey.UpArrow: _gameBoard.Move("Up");
                    break;

                //New Game
                case ConsoleKey.N:
                    NewGame();
                    break;

                case ConsoleKey.C:
                    timer.Change(Timeout.Infinite,  Timeout.Infinite);
                    ChangeName();
                    timer.Change(1000, 1000);
                    break;

                //debugging win condition
                case ConsoleKey.W:
                    _gameBoard.DefaultPosition();
                    break;
                
                case ConsoleKey.D:
                    Console.ReadKey();
                    break;
                
                
            }
            _graphics.ChangeMoves(_gameBoard);
            _graphics.InitBoard(_gameBoard);

            if (_gameBoard.CheckWin())
            {
                timer.Change(Timeout.Infinite,  Timeout.Infinite);
                _graphics.ShowYouWon();
                _player.TimeSpent();
                _player.SetMoves(_gameBoard);
                _scoreBoard.AddPlayer(_player);
                _scoreBoard.Sort();
                _scoreBoard.SaveList();
                Console.ReadKey();
                NewGame();
                timer.Change(1000,  1000);
            }
        } while (e.Key != ConsoleKey.Escape);
    }
}