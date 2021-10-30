using CarsBuisnessLayer.Interfaces;
using CarsCore.Models;
using CarsCore.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CarsBuisnessLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthOptions _authOptions;
        private readonly SigningCredentials _signingCredentials;

        public AuthService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey
                            (Encoding.ASCII.GetBytes(_authOptions.SecretKey)),
                            SecurityAlgorithms.HmacSha256);
        }

        public string CreateAuthToken(UserInfo userInfo)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userInfo.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userInfo.Role.ToString())
            };

            JwtSecurityToken token = new(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    notBefore: DateTime.UtcNow,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_authOptions.TokenLifetime)),
                    signingCredentials: _signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetUserLoginFromToken(string headerToken)
        {
            string token = headerToken.Substring(headerToken.IndexOf(' ') + 1);

            JwtSecurityTokenHandler handler = new();
            SecurityToken jsonToken = handler.ReadToken(token);
            JwtSecurityToken tokenS = jsonToken as JwtSecurityToken;

            return tokenS.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
        }
    }
}
