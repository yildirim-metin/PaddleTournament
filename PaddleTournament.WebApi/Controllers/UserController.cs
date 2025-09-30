using Microsoft.AspNetCore.Mvc;
using PaddleTournament.DL.Models;
using PaddleTournament.DLL.Services;
using PaddleTournament.WebApi.Models.Users;

namespace PaddleTournament.WebApi.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login([FromForm] LoginFormDto form)
    {
        User? user = _userService.GetUserByEmail(form.Email);
        return View(form);
    }
}