using Newtonsoft.Json;

namespace Puzzle15;

public class Player
{
    public int Moves { get; private set  ;}
    public DateTime StartTime { get;  private set;}
    public DateTime FinishTime { get;  private set;}
    public TimeSpan Ts { get; private set;}
    public string Name{ get; private set;}
    private const int MaxNameLength = 16;

    private readonly JsonSaveLoad<string> _saveLoadLoadProvider = new JsonSaveLoad<string>("name.json"); 


    public Player()
    {
        Moves = 0;
        StartTime = DateTime.Now;
        Ts = DateTime.Now - StartTime;
        /*using StreamWriter save = new StreamWriter("n.txt", true);
        save.Write(string.Empty);*/
        LoadName();
    }
    
    [JsonConstructor]
    
    public Player(int moves, 
        DateTime startTime, DateTime finishTime, TimeSpan ts, string name)
    {
        Name = name;
        StartTime = startTime;
        FinishTime = finishTime;
        Ts = ts;
        Moves = moves;
    }

    private void SaveName()
    {
        _saveLoadLoadProvider.Save(Name);
        
        /*using StreamWriter save = new StreamWriter("n.txt");
        save.Write(Name);*/
    }

    private void LoadName()
    {
        Name = _saveLoadLoadProvider.Load() ?? "please change name";
        
        /*using var load = new StreamReader("n.txt");
        Name = load.ReadLine() ?? "please change name";*/
    }

    public void SetMoves(GameBoard board)
        {
            Moves = board.Moves;
        }

    public void ChangeName()
    {
        string name = Console.ReadLine();
        Name = name.Length < MaxNameLength ? name : "Too Long Name";
        SaveName();
    }

    public string TimeSpent()
        {
            FinishTime = DateTime.Now;
            Ts = FinishTime - StartTime;
            return Ts.ToString(@"mm\:ss");
        }
    
}