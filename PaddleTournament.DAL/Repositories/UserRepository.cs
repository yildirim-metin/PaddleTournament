using Microsoft.Data.SqlClient;
using PaddleTournament.DL.Enums;
using PaddleTournament.DL.Models;

namespace PaddleTournament.DAL.Repositories;

public class UserRepository
{
    private readonly string? _connectionString;
    
    public UserRepository()
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