using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Infrastructure.Auth
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }
        public string GenerateAccessToken(User user)
        {
            List<Claim> claims = [
                new("user_id", user.Id.ToString()),
                new("name", user.Name),
                new("isAdmim", user.IsAdmin.ToString())
            ];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddSeconds(_jwtOptions.ExpiresAccessTokenSeconds)
                );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
