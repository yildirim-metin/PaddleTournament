using System.ComponentModel.DataAnnotations;

namespace PaddleTournament.WebApi.Models.Tournaments;

public class RegisterTournamentFormDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Location { get; set; } = null!;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public int NbrMaxTeams { get; set; }

    [Required]
    public int NbrMinTeams { get; set; }
}