using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using System.Text;
using IdentityModel;

namespace Ocean.Infrastructure.JwtBreare
{
   public class TokenService : ITokenService
    {
        private IOptions<JWTConfig> _options;
        public TokenService(IOptions<JWTConfig> options)
        {
            _options = options;
        }
        public ComplexToken CreateToken(Claim[] claims)
        {

            var accessClaim = new List<Claim>() { new Claim(JwtClaimTypes.JwtId, "access") };
            accessClaim.AddRange(claims.ToList());
            var refreshClaim = new List<Claim>() { new Claim(JwtClaimTypes.JwtId, "refresh") };
            refreshClaim.AddRange(claims.ToList());
            return new ComplexToken
            {
                AccessToken = CreateToken(accessClaim.ToArray(), TokenType.AccessToken),
                RefreshToken = CreateToken(refreshClaim.ToArray(), TokenType.RefreshToken)
            };
        }

        public Token RefreshToken(ClaimsPrincipal claimsPrincipal)
        {
            if (null == claimsPrincipal)
            {
                return null;
            }
            var claim = claimsPrincipal.Claims.Where(c => c.Type != JwtClaimTypes.JwtId).ToList();
            claim.Add(new Claim(JwtClaimTypes.JwtId, "access"));
            return CreateToken(claim.ToArray(), TokenType.AccessToken);
        }

        protected Token CreateToken(Claim[] claims, TokenType type)
        {
            var accesseExpires = DateTime.Now.Add(TimeSpan.FromMinutes(_options.Value.AccessTokenExpiresMinutes));
            var refreshExpires = DateTime.Now.Add(TimeSpan.FromMinutes(_options.Value.RefreshTokenExpiresMinutes));

            var expires = type == TokenType.AccessToken ? accesseExpires : refreshExpires;
            var token = new JwtSecurityToken(
                issuer: _options.Value.Issuer,
                audience: _options.Value.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expires,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SigningKey)), SecurityAlgorithms.HmacSha256)
                );
            return new Token { TokenContent = new JwtSecurityTokenHandler().WriteToken(token), Expires = expires };
        }
    }
    public enum TokenType
    {
        AccessToken = 1,
        RefreshToken = 2
    }
}
