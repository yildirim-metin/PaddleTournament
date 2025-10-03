namespace PaddleTournament.BLL.Exceptions;

public class WrongPasswordException : PaddleTournamentException
{
    public WrongPasswordException() : this("Wrong password.")
    {
    }

    public WrongPasswordException(string? message) : base(message)
    {
    }

    public WrongPasswordException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}