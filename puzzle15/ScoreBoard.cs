namespace Puzzle15;

public class ScoreBoard
{
    public ScoreBoard ()
    {
        NewSaveFile();
        LoadList();
        
    }
    
    List<Player> List = new List<Player>();

    void NewSaveFile(Boolean append = true)
    {
        using StreamWriter save = new StreamWriter("s.txt", append);
        save.Write("");
    }
    
    public void SaveList()
    {
        using StreamWriter save = new StreamWriter("s.txt");
        foreach (var el in List)
            save.WriteLine($"{el.Name}§{el.StartTime}§{el.FinishTime}§{el.Ts}§{el.Moves}");
    }
    
    public void LoadList()
    {
        string? s;
        using var save = new StreamReader("s.txt");
        while ((s = save.ReadLine()) != null)
        {
            string[] line = s.Split('§');
            Player loadPlayer = new Player(line[0], 
                DateTime.Parse(line[1]), 
                DateTime.Parse(line[2]), 
                TimeSpan.Parse(line[3]), 
                int.Parse(line[4]));
            List.Add(loadPlayer);
        }
    }

    public int CountPlayers()
    {
        return List.Count;
    }

    public string playerName(int n)
    {
        return List[n].Name;
    }
    
    public string playerTime(int n)
    {
        return List[n].Ts.ToString(@"mm\:ss");
    }
    
    public string playerMoves(int n)
    {
        return List[n].Moves.ToString();
    }
    
    public void AddPlayer(Player player)
    {
        List.Add(player);
    }
    
    
    public void Sort()
    {
        if (List.Count > 0)
        {
            for (int indexLower = 0; indexLower < List.Count; indexLower++) {

                for (int i = indexLower + 1; i < List.Count; i++)
                {
                    int result = TimeSpan.Compare(List[indexLower].Ts, List[i].Ts);
                    if (result > 0)
                    {
                        (List[i], List[indexLower]) = (List[indexLower], List[i]);
                    }
                }
            }
        }
    }
}