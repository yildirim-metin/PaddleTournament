namespace PaddleTournament.BLL.Exceptions;

public class PaddleTournamentException : Exception
{
    public PaddleTournamentException()
    {
    }

    public PaddleTournamentException(string? message) : base(message)
    {
    }

    public PaddleTournamentException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}