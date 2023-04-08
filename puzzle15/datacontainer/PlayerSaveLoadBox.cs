namespace puzzle15;

public class PlayerSaveLoadBox
{
    public int Moves { get; private set; }
    public DateTime StartTime{ get; private set; }
    public DateTime FinishTime{ get; private set; }
    public TimeSpan Ts{ get; private set; }
    public string Name{ get; private set; }
    
    
    public PlayerSaveLoadBox(string name, TimeSpan ts, DateTime finishTime, DateTime startTime, int moves) 
    {
        Name = name;
        Ts = ts;
        FinishTime = finishTime;
        StartTime = startTime;
        Moves = moves;
    }
}