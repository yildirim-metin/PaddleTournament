


using PaddleTournament.DAL.Repositories;
using PaddleTournament.DL.Models;

namespace PaddleTournament.DLL.Services;

public class TeamService 
{
    private readonly TeamRepository _teamRepository;

    public TeamService(TeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
     public void AddTeam(string TeamName, int idUser1, int idUser2)
    {
        Team team = new Team();
        team.Name = TeamName;
        team.UserAId = 2;
        team.UserBId = 2;
        _teamRepository.AddTeam(team);
    }
}