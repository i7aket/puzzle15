namespace Puzzle15;

public class ScoreBoard
{
    public List<Player> List = new List<Player>();

    public void newSFile()
    {
        {
            using StreamWriter save = new StreamWriter("s.txt", true);
            save.Write("");
        }
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
            Console.WriteLine(line[0]);
            Player loadPlayer = new Player();
            loadPlayer.Name = line[0];
            loadPlayer.StartTime = DateTime.Parse(line[1]);
            loadPlayer.FinishTime = DateTime.Parse(line[2]);
            loadPlayer.Ts = TimeSpan.Parse(line[3]);
            loadPlayer.Moves = int.Parse(line[4]);
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

//var tmp = List[i];
                
//List[0].Ts