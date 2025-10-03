namespace PaddleTournament.BLL.Exceptions;

public class UserNotFoundException : PaddleTournamentException
{
    public UserNotFoundException() : this("User does not exists.")
    {
    }

    public UserNotFoundException(string? message) : base(message)
    {
    }

    public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}