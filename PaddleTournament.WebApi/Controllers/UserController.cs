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


        try
        {
            User? user = _userService.GetUserByEmail(form.Email, form.Password);
        }
        catch (System.Exception ex)
        {

            ModelState.AddModelError("Password", ex.Message);
            return View(form);
        }
        return RedirectToAction("Index","Home");
      

    }

    [HttpGet]
     public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register([FromForm] RegisterFormDto form)
    {

        _userService.AddUser(form.Email, form.Password, form.UserName);
        return RedirectToAction("Login", "User");
        
    }
}