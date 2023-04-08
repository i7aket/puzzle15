using Newtonsoft.Json;
namespace puzzle15;

public class SaveLoadDiskJson<T> : ISaveLoad<T>
{
    public void Save(T obj, string filePath)
    {
        string json = JsonConvert.SerializeObject(obj);
        using (StreamWriter save = new StreamWriter(filePath, false))
        {
            save.Write(json);
        }
    }

    public T Load(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

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
            throw new FileNotFoundException($"There is no such file: {filePath}");
        }
    }
}
