namespace Puzzle15;

public class Game
{   
    GameBoard _gameBoard = new GameBoard();
    ScoreBoard _scoreBoard = new ScoreBoard();
    Player _player = new Player();
    string _name = "i7aKeT";
    private Graphics _graphics = new Graphics();
    
    private void PrintTime(object state)
    {
        _graphics.ChangeMovesAndTime(_gameBoard.Moves.ToString(), _player.TimeSpent());
    }
    
    public void Begin ()
    {
        _graphics.ChangeName(_name);
        _scoreBoard.NewSFile();    
        _scoreBoard.LoadList();
        _graphics.InitScoreBoard(_scoreBoard.List);
        _gameBoard.Shuffle();
        _graphics.InitBoard(_gameBoard);
        Play();
    }
    void NewGame()
    {
        _player = new Player(_name);
        _gameBoard = new GameBoard();
        _graphics = new Graphics();
        _graphics.ChangeName(_name);
        _gameBoard.Shuffle();
        _graphics.InitScoreBoard(_scoreBoard.List);
        _graphics.InitBoard(_gameBoard);
    }
    
    private void ChangeName()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(73,1);
        Console.WriteLine("Type your Name");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(73,1);
        _name = Console.ReadLine();
        _player.ChangeName(_name);
        _graphics = new Graphics();
        _graphics.ChangeName(_player.Name);
        _graphics.InitScoreBoard(_scoreBoard.List);
    }
    private bool CheckWin()
    {
        if (_gameBoard.СheckWin())
        {
            _graphics.ShowYouWon();
            _player.TimeSpent();
            _player.SetMoves(_gameBoard.Moves);
            _scoreBoard.List.Add(_player);
            _scoreBoard.Sort();
            _scoreBoard.SaveList();
            Console.ReadKey(); 
            NewGame();
            return true;
        }
        else return false;
    }
    
    private void Play()
    {
        ConsoleKeyInfo e;
        do
        {
            TimerCallback timerCallback = new TimerCallback(PrintTime);
            Timer time = new Timer(timerCallback, null, 0, 1000);
            
            e = Console.ReadKey();
            switch (e.Key)
            {
                case ConsoleKey.RightArrow when _gameBoard.ZeroPosX < 3:
                    _gameBoard.MoveTile("Right", 1);
                    break;

                case ConsoleKey.DownArrow when _gameBoard.ZeroPosY < 3:
                    _gameBoard.MoveTile("Down", 1);
                    break;

                case ConsoleKey.LeftArrow when _gameBoard.ZeroPosX > 0:
                    _gameBoard.MoveTile("Left", 1);
                    break;

                case ConsoleKey.UpArrow when _gameBoard.ZeroPosY > 0:
                    _gameBoard.MoveTile("Up", 1);
                    break;

                //New Game
                case ConsoleKey.N:
                    NewGame();
                    break;

                case ConsoleKey.C:
                    time.Dispose();
                    ChangeName();
                    break;

                //debugging win condition
                case ConsoleKey.W:
                    time.Dispose();
                    _gameBoard.DefaultPosition();
                    break;

                //for debug cases
                case ConsoleKey.D:
                    break;
            }
            _graphics.ChangeMovesAndTime(_gameBoard.Moves.ToString(), _player.TimeSpent());
            _graphics.InitBoard(_gameBoard);
            time.Dispose();
            CheckWin();
        } while (e.Key != ConsoleKey.Escape);
    }
}