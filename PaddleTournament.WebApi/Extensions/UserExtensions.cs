using System.Security.Claims;
using System.Security.Principal;

namespace PaddleTournament.WebApi.Extensions;

public static class UserExtensions
{
    public static bool IsConnected(this IPrincipal principal)
    {
        return principal.Identity!.IsAuthenticated;
    }

    public static string? GetUsername(this ClaimsPrincipal claims)
    {
        return claims.FindFirstValue(ClaimTypes.Name);
    }
}