namespace puzzle15;
using System.Data.SQLite;

public class SaveLoadScoreboardSqLite : ISaveLoad<List<PlayerSaveLoadBox>>
{
    private readonly string _connectionString;

    public SaveLoadScoreboardSqLite(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    private SQLiteConnection ConnectToDatabase (string dbPath)
    {
        try
        {
            SQLiteConnection connection = new SQLiteConnection($"Data Source=" + _connectionString);
            connection.Open();
            return connection;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to db: {ex.Message}");
            return null;
        }
    }
    
    private void InitializeDatabase(SQLiteConnection connection)
    {
        string createTableQuery = @"
        CREATE TABLE IF NOT EXISTS Scoreboard (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            name TEXT,
            ts TEXT,
            start_time TEXT,
            finish_time TEXT,
            moves INT
        );";
        using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
        {
            command.ExecuteNonQuery();
        }

        string createUniqueIndexQuery = "CREATE UNIQUE INDEX IF NOT EXISTS idx_unique_scoreboard ON Scoreboard (name, ts, start_time, finish_time, moves);";
        using (SQLiteCommand command = new SQLiteCommand(createUniqueIndexQuery, connection))
        {
            command.ExecuteNonQuery();
        }
    }


    public void Save(List<PlayerSaveLoadBox> objList)
    {
        using (SQLiteConnection connection = ConnectToDatabase(_connectionString))
        {
            InitializeDatabase(connection);

            foreach (PlayerSaveLoadBox obj in objList)
            {
                string insertQuery =
                    $"INSERT OR IGNORE INTO Scoreboard (name, ts, start_time, finish_time, moves) " +
                    $"VALUES ('{obj.Name}', '{obj.Ts.ToString()}', '{obj.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{obj.FinishTime.ToString("yyyy-MM-dd HH:mm:ss")}', {obj.Moves})";

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    
    public List<PlayerSaveLoadBox> Load()
    {
        List<PlayerSaveLoadBox> results = new List<PlayerSaveLoadBox>();

        using (SQLiteConnection connection = ConnectToDatabase(_connectionString))
        {
            InitializeDatabase(connection);

            string selectQuery = "SELECT name, ts, start_time, finish_time, moves FROM Scoreboard";

            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        TimeSpan ts = TimeSpan.Parse(reader.GetString(1));
                        DateTime startTime = DateTime.Parse(reader.GetString(2));
                        DateTime finishTime = DateTime.Parse(reader.GetString(3));
                        int moves = reader.GetInt32(4);
                        PlayerSaveLoadBox playerData = new PlayerSaveLoadBox(name, ts, startTime, finishTime, moves);
                        results.Add(playerData);
                    }
                }
            }
        }
        return results;
    }
}