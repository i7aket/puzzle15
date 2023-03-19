namespace Puzzle15;

public class Player
{
    public int Moves = 0;
    public DateTime StartTime = DateTime.Now;
    public DateTime FinishTime;
    public TimeSpan Ts;
    

    public string Name { get; set; } = "i7aKeT";
    
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