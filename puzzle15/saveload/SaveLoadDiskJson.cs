using Newtonsoft.Json;
namespace puzzle15;

public class SaveLoadDiskJson<T> : ISaveLoad<T>
{
    private string _filePath;

    public SaveLoadDiskJson(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(T obj)
    {
        string json = JsonConvert.SerializeObject(obj);
        using (StreamWriter save = new StreamWriter(_filePath, false))
        {
            save.Write(json);
        }
    }

    public T Load()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);

            try
            {
                var obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            catch (JsonException ex)
            {
                throw new JsonException("Error deserializing JSON.", ex);
            }
        }
        else
        {
            throw new FileNotFoundException($"There is no such file: {_filePath}");
        }
    }
}
