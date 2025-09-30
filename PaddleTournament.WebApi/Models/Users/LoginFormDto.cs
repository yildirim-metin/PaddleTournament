using System.ComponentModel.DataAnnotations;

namespace PaddleTournament.WebApi.Models.Users;

public class LoginFormDto
{
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}