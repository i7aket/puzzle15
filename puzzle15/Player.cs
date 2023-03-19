namespace Puzzle15;

public class Player
{
    public int Moves = 0;
    public DateTime StartTime { get; private set;} = DateTime.Now;
    public DateTime FinishTime{ get; private set; }
    public TimeSpan Ts { get; private set; }

    public Player()
    {
    }
    
    public Player(string name)
    {
        
        Name = name;
    }

    public void SetMoves (int moves)
    {
        Moves = moves;
    }
    
    public Player(string name, DateTime startTime, DateTime finishTime, TimeSpan ts, int moves)
    {
        Name = name;
        StartTime = startTime;
        FinishTime = finishTime;
        Ts = ts;
        Moves = moves;
    }

    public string Name { get; private set; } = "i7aKeT";
    
    public void ChangeName(string name)
    {
        Name = name.Length < 16 ? name : "Too Long Name";
    }

    public string TimeSpent()
    {
        FinishTime = DateTime.Now;
        Ts = FinishTime - StartTime;
        return Ts.ToString(@"mm\:ss");
    }
}