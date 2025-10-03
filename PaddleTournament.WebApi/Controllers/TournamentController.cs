using Microsoft.AspNetCore.Mvc;
using PaddleTournament.BLL.Services;
using PaddleTournament.WebApi.Models.Tournaments;

namespace PaddleTournament.WebApi.Controllers;

public class TournamentController : Controller
{
    private readonly TournamentService _tournamentService;

    public TournamentController(TournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index([FromForm] RegisterTournamentFormDto form)
    {
        _tournamentService.Add(form.Name, form.Location, form.StartDate, form.NbrMaxTeams, form.NbrMinTeams);
        TempData["SnackbarMessage"] = "Tournament was created.";
        return View(form);
    }
}