
using System.ComponentModel.DataAnnotations;

namespace PaddleTournament.WebApi.Models.Users;

public class RegisterFormDto
{
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; } = null!;
    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;

}