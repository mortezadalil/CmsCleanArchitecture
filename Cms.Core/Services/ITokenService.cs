using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cms.Core.Services
{
    public interface ITokenService
    {
        object TokenGenerator(long userId, string username);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        string GenerateRefreshToken();
        (string token, DateTime expiration) GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
