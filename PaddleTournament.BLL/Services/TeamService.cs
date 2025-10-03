using PaddleTournament.DAL.Repositories;
using PaddleTournament.DL.Models;

namespace PaddleTournament.BLL.Services;

public class TeamService
{
    private readonly TeamRepository _teamRepository;

    public TeamService(TeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public void AddTeam(string TeamName, int userAId, int userBId)
    {
        Team team = new Team();
        team.Name = TeamName;
        team.UserAId = userAId;
        team.UserBId = userBId;
        _teamRepository.AddTeam(team);
    }
}