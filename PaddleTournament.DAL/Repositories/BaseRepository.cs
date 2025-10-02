using PaddleTournament.DAL.Utils;

public class BaseRepository
{
     protected readonly string? _connectionString;
    
    public BaseRepository()
    {
        _connectionString = EnvironmentFileReader.GetConnectionString();
    }
}