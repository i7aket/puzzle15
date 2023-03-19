namespace Puzzle15;

public class ScoreBoard
{
    public List<Player> List = new List<Player>();

    public static void NewSFile()
    {
        using StreamWriter save = new StreamWriter("s.txt", true);
        save.Write("");
    }
    public void SaveList()
    {
        using StreamWriter save = new StreamWriter("s.txt");
        for (int i=0; i<List.Count; i++)
            save.WriteLine($"{List[i].Name}§{List[i].StartTime}§{List[i].FinishTime}§{List[i].Ts}§{List[i].Moves}");
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

    public void Sort()
    {
        if (List.Count > 0)
        {
            for (int indexLower = 0; indexLower < List.Count; indexLower++) {

                for (int i = indexLower + 1; i < List.Count; i++)
                {
                    int rezult = TimeSpan.Compare(List[indexLower].Ts, List[i].Ts);
                    if (rezult > 0)
                    {
                        (List[i], List[indexLower]) = (List[indexLower], List[i]);
                    }
                }
            }
        }
    }
}