namespace PaddleTournament.DL.Models;

public class Team
{
    public int Id { get; set; }
    public int UserAId { get; set; }
    public int UserBId { get; set; }
    public string Name { get; set; } = null!;
}