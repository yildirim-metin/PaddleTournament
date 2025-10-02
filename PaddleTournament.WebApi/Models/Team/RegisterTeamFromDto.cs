using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PaddleTournament.WebApi.Models.Team;

public class RegisterTeamFromDto
{
    [Required]
    public string? Name { get; set; }

    public string? TeamId { get; set; }

    [Required]
    public string? PlayerName1 { get; set; }

    [Required]
    public string? PlayerName2 { get; set; }

    public int UserAId { get; set; }
    
    public int UserBId { get; set; }
}