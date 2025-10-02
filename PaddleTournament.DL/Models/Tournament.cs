namespace PaddleTournament.DL.Models;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public int NbrMinTeams { get; set; }
    public int NbrMaxTeams { get; set; }
}