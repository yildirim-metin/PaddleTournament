using Microsoft.Data.SqlClient;
using PaddleTournament.DL.Models;

namespace PaddleTournament.DAL.Repositories;

public class TournamentRepository : BaseRepository
{
    public void Add(Tournament tournament)
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = connection.CreateCommand();
        
        command.CommandText = """
        INSERT INTO [Tournament] ([Name], [Location], StartDate, NbrMaxTeams, NbrMinTeams)
        VALUES (@name, @location, @startDate, @nbrMaxTeams, @nbrMinTeams)
        """;

        command.Parameters.AddWithValue("@name", tournament.Name);
        command.Parameters.AddWithValue("@location", tournament.Location);
        command.Parameters.AddWithValue("@startDate", tournament.StartDate);
        command.Parameters.AddWithValue("@nbrMaxTeams", tournament.NbrMaxTeams);
        command.Parameters.AddWithValue("@nbrMinTeams", tournament.NbrMinTeams);

        connection.Open();

        command.ExecuteNonQuery();
    }
}