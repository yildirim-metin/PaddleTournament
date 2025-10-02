using Microsoft.Data.SqlClient;
using PaddleTournament.DAL.Utils;
using PaddleTournament.DL.Enums;
using PaddleTournament.DL.Models;

namespace PaddleTournament.DAL.Repositories;

public class UserRepository
{
    private readonly string? _connectionString;
    
    public UserRepository()
    {
        _connectionString = EnvironmentFileReader.GetConnectionString();
    }

    public void AddUser(User user)
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = connection.CreateCommand();

        command.CommandText = @"
        Insert Into [user](Email,PasswordHash,UserName)values(@email,@password,@username)
      
        ";
        command.Parameters.AddWithValue("@email", user.Email);
        command.Parameters.AddWithValue("@password", user.PasswordHash);
         command.Parameters.AddWithValue("@username", user.Username);

        connection.Open();
        command.ExecuteNonQuery();
      
    }

    public User? GetUserByEmail(string email)
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = connection.CreateCommand();

        command.CommandText = """
        SELECT *
        FROM [User]
        WHERE Email = @email
        """;

        command.Parameters.AddWithValue("@email", email);

        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();
        if (!reader.Read())
        {
            return null;
        }

        return new User()
        {
            Id = (int)reader["Id"],
            Email = (string)reader["Email"],
            Username = (string)reader["Username"],
            PasswordHash = (string)reader["PasswordHash"],
            Role = Enum.Parse<UserRole>((string)reader["Role"]),
        };
    }
}