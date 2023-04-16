namespace puzzle15;
using Npgsql;

public class SaveLoadScoreboardPostgresql : ISaveLoad<List<PlayerSaveLoadBox>>
{
    private string _connectionString;
    
    public SaveLoadScoreboardPostgresql(string connectionString)
    {
        _connectionString = connectionString;
    }
    

    private NpgsqlConnection ConnectToDatabase()
    {
        try
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to db: {ex.Message}");
            return null;
        }
    }
    
    
    private void InitializeDatabase(NpgsqlConnection connection)
    {
        string createTableQuery = @"
        CREATE TABLE IF NOT EXISTS scoreboard (
            id SERIAL PRIMARY KEY,
            name TEXT,
            ts INTERVAL,
            start_time TIMESTAMP,
            finish_time TIMESTAMP,
            moves INTEGER,
            UNIQUE(name, ts, start_time, finish_time, moves)
        );";

        using (NpgsqlCommand command = new NpgsqlCommand(createTableQuery, connection))
        {
            command.ExecuteNonQuery();
        }
    }


    public void Save(List<PlayerSaveLoadBox> objList)
    {
        using (NpgsqlConnection connection = ConnectToDatabase())
        {
            InitializeDatabase(connection);

            foreach (PlayerSaveLoadBox obj in objList)
            {
                string insertQuery =
                    $"INSERT INTO scoreboard (name, ts, start_time, finish_time, moves) " +
                    $"VALUES ('{obj.Name}', '{obj.Ts}', '{obj.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{obj.FinishTime.ToString("yyyy-MM-dd HH:mm:ss")}', {obj.Moves}) " +
                    $"ON CONFLICT DO NOTHING;";

                using (NpgsqlCommand command = new NpgsqlCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }


    public List<PlayerSaveLoadBox> Load()
    {
        List<PlayerSaveLoadBox> results = new List<PlayerSaveLoadBox>();

        using (NpgsqlConnection connection = ConnectToDatabase())
        {
            InitializeDatabase(connection);

            string selectQuery = "SELECT name, ts, start_time, finish_time, moves FROM scoreboard;";

            using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        TimeSpan ts = reader.GetTimeSpan(1);
                        DateTime startTime = reader.GetDateTime(2);
                        DateTime finishTime = reader.GetDateTime(3);
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