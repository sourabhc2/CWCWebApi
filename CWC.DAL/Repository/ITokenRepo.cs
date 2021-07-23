
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CWC.DAL.Repository
{
    public interface ITokenRepo
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        
    }
}
