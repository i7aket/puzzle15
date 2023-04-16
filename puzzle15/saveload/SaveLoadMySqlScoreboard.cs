namespace puzzle15;
using MySql.Data.MySqlClient;

public class SaveLoadMySqlScoreboard : ISaveLoad<List<PlayerSaveLoadBox>>
{
    private string _filePath;

    public SaveLoadMySqlScoreboard(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(List<PlayerSaveLoadBox> obj)
    {

    }

    public List<PlayerSaveLoadBox> Load()
    {
    }
}