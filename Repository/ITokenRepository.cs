using System.Collections.Generic;
using System.Security.Claims;

namespace Jesstw.Repository
{
    public interface ITokenRepository
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}