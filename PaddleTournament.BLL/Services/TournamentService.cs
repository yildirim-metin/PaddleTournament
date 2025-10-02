using PaddleTournament.DAL.Repositories;
using PaddleTournament.DL.Models;

namespace PaddleTournament.BLL.Services;

public class TournamentService
{
    private readonly TournamentRepository _tournamentRepository;

    public TournamentService(TournamentRepository tournamentRepository)
    {
        _tournamentRepository = tournamentRepository;
    }

    public void Add(string name, string location, DateTime startDate, int nbrMaxTeams, int nbrMinTeams)
    {
        Tournament tournament = new()
        {
            Name = name,
            Location = location,
            StartDate = startDate,
            NbrMaxTeams = nbrMaxTeams,
            NbrMinTeams = nbrMinTeams,
        };
        _tournamentRepository.Add(tournament);
    }
}