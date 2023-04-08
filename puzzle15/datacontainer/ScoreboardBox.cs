namespace puzzle15;

public class ScoreboardBox
{ 
    public List<Player> List { get; private set; }
    
    public ScoreboardBox(List<Player> list)
    {
        List = list;
    }
}