using System.Security.Claims;

namespace RESTWithASP_NET5Udemy.Services
{
    public interface ITokenServices
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    }
}
