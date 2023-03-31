namespace Puzzle15;

public class ScoreBoard
{
    public ScoreBoard ()
    {
        using StreamWriter save = new StreamWriter("s.txt", true);
        save.Write(string.Empty);
        
        string? s;
        using var load = new StreamReader("s.txt");
        while ((s = load.ReadLine()) != null)
        {
            string[] line = s.Split('§');
            Player loadPlayer = new Player(line[0],       // Name
                DateTime.Parse(line[1]),          //SyartTime
                DateTime.Parse(line[2]),         //FinishTime
                TimeSpan.Parse(line[3]),               //TimeSpentCount
                int.Parse(line[4]));                //moves
            _list.Add(loadPlayer);
        }
    }

    readonly List<Player> _list = new List<Player>();

    public void SaveList()
    {
        using StreamWriter save = new StreamWriter("s.txt");
        foreach (var el in _list)
            save.WriteLine($"{el.Name}§{el.StartTime}§{el.FinishTime}§{el.Ts}§{el.Moves}");
    }
    
    public int CountPlayers()
    {
        return _list.Count;
    }

    public string PlayerName(int n)
    {
        return _list[n].Name;
    }
    
    public string PlayerTime(int n)
    {
        return _list[n].Ts.ToString(@"mm\:ss");
    }
    
    public string PlayerMoves(int n)
    {
        return _list[n].Moves.ToString();
    }
    
    public void AddPlayer(Player player)
    {
        _list.Add(player);
    }
    
    
    public void Sort()
    {
        if (_list.Count > 0)
        {
            for (int indexLower = 0; indexLower < _list.Count; indexLower++) {

                for (int i = indexLower + 1; i < _list.Count; i++)
                {
                    int result = TimeSpan.Compare(_list[indexLower].Ts, _list[i].Ts);
                    if (result > 0)
                    {
                        (_list[i], _list[indexLower]) = (_list[indexLower], _list[i]);
                    }
                }
            }
        }
    }
}