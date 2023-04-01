namespace Puzzle15;

/*public class SaveToFile <T> : ISave<T>, ILoad<T>
{
    
    private string _filePath;
    
    public SaveToFile (string filePath = "s.txt")
    {
        _filePath = filePath;
        using StreamWriter save = new StreamWriter(filePath, true);
        save.Write(string.Empty);
    }
    
    public void Save(T obj)
    {
        //throw new NotImplementedException();
    }

    public T Load()
    {
        return null; //throw new NotImplementedException();
    }
}*/

/*
_list = new List<Player>();
using StreamWriter save = new StreamWriter("s.txt", true);
save.Write(string.Empty);

string? s;
using var load = new StreamReader("s.txt");
while ((s = load.ReadLine()) != null)
{
    string[] line = s.Split('§');
    Player loadPlayer = new Player(int.Parse(line[0]),       
        DateTime.Parse(line[1]),          
        DateTime.Parse(line[2]),         
        TimeSpan.Parse(line[3]),         
        (line[4]));             
    _list.Add(loadPlayer);
}


using StreamWriter save    = new StreamWriter("s.txt");
foreach (var el in _list)
    save.WriteLine($"{el.Moves}§{el.StartTime}§{el.FinishTime}§{el.Ts}§{el.Name}");*/
