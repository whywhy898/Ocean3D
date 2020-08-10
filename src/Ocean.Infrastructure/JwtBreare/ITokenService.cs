using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ocean.Infrastructure.JwtBreare
{
   public interface ITokenService
    {
        ComplexToken CreateToken(Claim[] claims);
        Token RefreshToken(ClaimsPrincipal claimsPrincipal);
    }
}
