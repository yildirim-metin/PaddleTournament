using PaddleTournament.DAL.Utils;

namespace PaddleTournament.DAL.Repositories;

public class BaseRepository
{
    protected readonly string? _connectionString;

    public BaseRepository()
    {
        _connectionString = EnvironmentFileReader.GetConnectionString();
    }
}