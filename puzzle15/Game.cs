namespace Puzzle15;

public class Game
{
    GameBoard _gameBoard = new GameBoard();
    Display _display = new Display();
    ScoreBoard _players = new ScoreBoard();
    Player _player = new Player();
    string _name = "i7aKeT";
    
    void NewGame()
    {
        _player = new Player(_name);
        _gameBoard = new GameBoard();
        _gameBoard.Shuffle();
        _display.FillCanvas();
        _display.FillColorCanvas();
        _display.InitBoard(_gameBoard);
        _display.InitInterface(_name, _players.List);
        Console.Clear();
        _display.Draw();
    }
    
    private void Play()
    {
        ConsoleKeyInfo e;
        do
        {
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
                    Console.Clear();
                    _display.Draw();
                    Console.WriteLine("Type your Name");
                    _name = Console.ReadLine();
                    _player.ChangeName(_name);
                    _display.ChangeName(_player.Name);
                    break;

                //debugging win condition
                case ConsoleKey.W:
                    _gameBoard.DefaultPosition();
                    break;

                //for debug cases
                case ConsoleKey.D:
                    ScoreBoard.NewSFile(false);
                    //Console.ReadLine();
                    break;
            }
            _display.ChangeMovesAndTime(_gameBoard.Moves.ToString(), _player.TimeSpent());
            _display.InitBoard(_gameBoard);
            Console.Clear();
            _display.Draw();
            CheckWin();
        } while (e.Key != ConsoleKey.Escape);
    }
    
    private void CheckWin()
    {
        if (_gameBoard.СheckWin())
        {
            _display.ShowYouWIn();
            _player.TimeSpent();
            _player.SetMoves(_gameBoard.Moves);
            _players.List.Add(_player);
            _players.Sort();
            _players.SaveList();
            Console.Clear();
            _display.Draw();
            Console.ReadLine();
            NewGame();
        }
    }
    
    public void Begin ()
    {
        ScoreBoard.NewSFile();
        _players.LoadList();
        NewGame();
        Play();
    }
}