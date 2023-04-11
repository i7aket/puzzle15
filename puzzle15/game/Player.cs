using Newtonsoft.Json;

namespace puzzle15;

public class Player
{
    private int _moves;
    private DateTime _startTime;
    private DateTime _finishTime;
    private TimeSpan _ts;
    private string _name;
    private List<PlayerSaveLoadBox> _scoreboard = new();
    
    public event Action<PlayerNameSaveLoadBox, string> SaveNameEvent;
    public event Func<string, PlayerNameSaveLoadBox> LoadNameEvent;
    
    public event Action<List<PlayerSaveLoadBox>, string> SaveScoreboardEvent;
    public event Func<string, List<PlayerSaveLoadBox>> LoadScoreboardEvent;
    
    public event Action<PlayerNameSaveLoadBox> ChangeNameEvent;
    public event Func<string> InputNameEvent;

    public event Action<List<PlayerSaveLoadBox>> ShowScoreboardEvent;
    public event Action<int> ChangeMovesEvent;
    
    private readonly Timer _timer;
    public event Action<string> ChangeTimeEvent;

    
    public void SavePlayerToScoreboard ()
    {
        _finishTime = DateTime.Now;
        _ts = DateTime.Now - _startTime;
        var playerSaveLoadBox = new PlayerSaveLoadBox(_name, _ts, _startTime, _finishTime, _moves);
        _scoreboard.Add(playerSaveLoadBox);
        _scoreboard =    _scoreboard.OrderBy (saveLoadBox => saveLoadBox.Ts)
                                    .ThenBy (saveLoadBox => saveLoadBox.Moves)
                                    .Take (12)
                                    .ToList ();
        SaveScoreboardEvent(_scoreboard, Const.SaveLoadScoreboardPath);
    }
    
    public void LoadScoreboard ()
    {
        try
        {
            _scoreboard = LoadScoreboardEvent(Const.SaveLoadScoreboardPath);
            ShowScoreboardEvent(_scoreboard);
        }
        catch (FileNotFoundException)
        {
        }
        catch (JsonException)
        {
        }
        
    }

    public void AddMoves()
    {
        ChangeMovesEvent(_moves++);
    }

    public void ResetMoves()
    {
        _moves = 0;
    }

    public Player ()
    {
        _moves = 0;
        _startTime = DateTime.Now;
        _ts = DateTime.Now - _startTime;
        _name = "i7aKeT";
        _timer = new Timer(OnTimerTick, null, Timeout.Infinite, Timeout.Infinite);
    }

    public Player (string name, int moves, DateTime startTime, DateTime finishTime, TimeSpan ts)
    {
        _name = name;
        _startTime = startTime;
        _finishTime = finishTime;
        _ts = ts;
        _moves = moves;
    }

    public void ResetTimer()
    {
        _startTime = DateTime.Now;
    }
    
    private void SaveName()
    {
        SaveNameEvent(new PlayerNameSaveLoadBox(_name), Const.SaveLoadNamePath);
    }

    public void LoadName()
    {
        PlayerNameSaveLoadBox playerSaveLoadBox;
        try
        {
           playerSaveLoadBox = LoadNameEvent(Const.SaveLoadNamePath);
        }
        catch (FileNotFoundException)
        {
            playerSaveLoadBox = new PlayerNameSaveLoadBox("please change name");
        }
        catch (JsonException)
        {
            playerSaveLoadBox = new PlayerNameSaveLoadBox("please change name");
        }
        _name = playerSaveLoadBox.Name;
        ChangeNameEvent(playerSaveLoadBox);
    }

    public void ChangeName()
    {
        string name = InputNameEvent();
        name = name.Length < Const.MaxNameLength ? name : "Too Long name";
        _name = name;
        ChangeNameEvent(new PlayerNameSaveLoadBox(_name));
        SaveName();
    }

    public string TimeSpent()
    {
        _finishTime = DateTime.Now;
        _ts = _finishTime - _startTime;
        return _ts.ToString(@"mm\:ss");
    }
    
    public void StartTimer()
    {
        _timer.Change(1000, 1000);
    }

    public void StopTimer()
    {
        _timer.Change(Timeout.Infinite, Timeout.Infinite);
    }

    private void OnTimerTick(object state)
    {
        _ts = DateTime.Now - _startTime;
        ChangeTimeEvent(_ts.ToString(@"mm\:ss"));
    }
}