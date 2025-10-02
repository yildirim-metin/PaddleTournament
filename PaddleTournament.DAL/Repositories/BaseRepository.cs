public class BaseRepository
{
     protected readonly string? _connectionString;
    
    public BaseRepository()
    {
        foreach (var line in File.ReadAllLines("../../.env"))
        {
            var parts = line.Split(':');
            if (parts[0] == "CONNECTION_STRING")
            {
                _connectionString = parts[1];
            }
        }
    }
}