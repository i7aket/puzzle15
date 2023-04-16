namespace puzzle15;

public class PlayerSaveLoadBox
{
    public int Moves { get; private set; }
    public DateTime StartTime{ get; private set; }
    public DateTime FinishTime{ get; private set; }
    public TimeSpan Ts{ get; private set; }
    public string Name{ get; private set; }
    
    
    public PlayerSaveLoadBox(string name, TimeSpan ts, DateTime startTime, DateTime finishTime, int moves) 
    {
        Name = name;
        Ts = ts;
        StartTime = startTime;
        FinishTime = finishTime;
        Moves = moves;
    }
}