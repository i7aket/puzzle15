using Newtonsoft.Json;


namespace Puzzle15;

public class JsonSaveLoad<T> : ISave<T>, ILoad<T>
{
    private string _filePath;
    
    public JsonSaveLoad (string filePath = "noname.json")
    {
        _filePath = filePath;
        using StreamWriter save = new StreamWriter(filePath, true);
        save.Write(string.Empty);
    }
    
    public void Save(T obj)
    {
        string json = JsonConvert.SerializeObject(obj);
        using StreamWriter save = new StreamWriter(_filePath);
        save.Write(json);
    }

    public T Load()
    {
        string json = File.ReadAllText(_filePath);

        var obj = JsonConvert.DeserializeObject<T>(json);

        return obj;
    }
    
}