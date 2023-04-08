namespace puzzle15;

public class GamePuzzle15
{
    public readonly GameBoard Gameboard = new GameBoard();
    private Player _player =new Player();
    private Component _component = new Component();
    private readonly SaveLoadDiskJson <PlayerNameSaveLoadBox> _saveLoadDiskJsonName= new SaveLoadDiskJson <PlayerNameSaveLoadBox>();
    private readonly SaveLoadDiskJson <List<PlayerSaveLoadBox>> _saveLoadDiskJsonScoreboard= new SaveLoadDiskJson <List<PlayerSaveLoadBox>>();
    
    private readonly InputControlsKeyboard _inputControlKeyboard = new InputControlsKeyboard();
    
    private readonly ConsoleOutput _consoleOutput = new ConsoleOutput();
    
    private readonly ConsoleInputString _consoleInputString = new ConsoleInputString();
    
    public event Func<KeyPressed> InputKeyPressedEvent;
    public event Action WinEvent;
    
    public GamePuzzle15()
    {
        InputKeyPressedEvent += _inputControlKeyboard.Key;
        
        WinEvent += _component.WinEvent;
        WinEvent += _player.StopTimer;
        WinEvent += _player.SavePlayerToScoreboard;
        WinEvent += _inputControlKeyboard.Hold;
        WinEvent += _player.ResetTimer;
        
        _component.PrintEvent += _consoleOutput.Print;

        _player.InputNameEvent += _consoleInputString.InputName;
        
        _player.ChangeNameEvent += _component.ChangeName;
        _player.ChangeMovesEvent += _component.ChangeMoves;
        _player.ChangeTimeEvent += _component.ChangeTime;
        _player.SaveNameEvent += _saveLoadDiskJsonName.Save;
        _player.LoadNameEvent += _saveLoadDiskJsonName.Load;
        _player.SaveScoreboardEvent += _saveLoadDiskJsonScoreboard.Save;
        _player.LoadScoreboardEvent += _saveLoadDiskJsonScoreboard.Load;
        _player.ShowScoreboardEvent += _component.ShowScoreboard;
        
        Gameboard.InitBoard += _component.MoveTileEvent;
        Gameboard.ResetMoves += _player.ResetMoves;
        Gameboard.ResetMoves += _component.ResetMoves;
        Gameboard.AddMoves += _player.AddMoves;
    }

    public void Begin()
    {
        _component.ShowInterfaceGraphic();
        _player.LoadName();
        Gameboard.NewGame();
        _player.LoadScoreboard();
        _player.StartTimer();
        do
        {
            switch (InputKeyPressedEvent())
            {
                case KeyPressed.Right:
                    Gameboard.Right();
                    break;
                
                case KeyPressed.Down:
                    Gameboard.Down();
                    break;
                
                case KeyPressed.Left:
                    Gameboard.Left();
                    break;
                
                case KeyPressed.Up:
                    Gameboard.Up();
                    break;
                
                case KeyPressed.NewGame:
                    Gameboard.NewGame();
                    break;
                
                case KeyPressed.ChangeName:
                    _player.StopTimer();
                    _player.ChangeName();
                    _player.StartTimer();
                    break;
                
                case KeyPressed.EndGame:
                    Gameboard.EngGame();
                    break;
                
                case KeyPressed.WinDebug:
                    Gameboard.DefaultPosition();
                    break;
                
                case KeyPressed.Debug:
                    
                    break;
            }
        } while (Gameboard.GameStatus == GameStatus.InProgress);
        WinEvent();
        Begin();
    }
}

