
using Microsoft.Data.SqlClient;
using PaddleTournament.DL.Models;

namespace PaddleTournament.DAL.Repositories;

public class TeamRepository:BaseRepository{

    public void AddTeam(Team team)
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = connection.CreateCommand();

        command.CommandText = @"Insert Into [team](UserAId,UserBId,Name)values(@UserAId,@UserBId,@Name)";

        command.Parameters.AddWithValue("@Name", team.Name);
        command.Parameters.AddWithValue("@UserAId", team.UserAId);
         command.Parameters.AddWithValue("@UserBId", team.UserBId);
      
         connection.Open();
         command.ExecuteNonQuery();
    }
}
