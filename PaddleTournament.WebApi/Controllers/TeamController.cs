
using PaddleTournament.DL.Models;
using Microsoft.AspNetCore.Mvc;
using PaddleTournament.WebApi.Models.Team;
using PaddleTournament.BLL.Services;
namespace PaddleTournament.WebApi.Controllers;

public class TeamController : Controller
{
    private readonly TeamService _teamService;
    public TeamController(TeamService teamService)
    {
        _teamService = teamService;
    }
    public IActionResult RegisterTeam()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult RegisterTeam([FromForm] RegisterTeamFromDto form)
    {

        _teamService.AddTeam(form.Name ??"", form.UserAId, form.UserBId);
        return RedirectToAction("RegisterTeam");
        
    }


}

