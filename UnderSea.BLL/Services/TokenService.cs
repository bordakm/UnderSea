using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models;
using Microsoft.Extensions.Configuration;

namespace UnderSea.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly UnderSeaDbContext db;
        private readonly IConfiguration configuration;
        private readonly Random random;

        public TokenService(UnderSeaDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
            random = new Random();
        }

        public string CreateAccessToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),                
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               configuration["JwtIssuer"],
               configuration["JwtIssuer"],
               claims,
               expires: DateTime.Now.AddMinutes(5),
               signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> CreateRefreshTokenAsync(User user)
        {
            string charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 30; ++i)
            {
                int index = (int)(random.NextDouble() * charPool.Length);
                if (index == charPool.Length)
                {
                    --index;
                }
                sb.Append(charPool[index]);
            }
            string refreshToken = sb.ToString();
            user.RefreshToken = refreshToken;
            await db.SaveChangesAsync();
            return refreshToken;
        }

        public async Task RemoveRefreshTokenAsync(User user)
        {
            user.RefreshToken = null;
            await db.SaveChangesAsync();
        }
    }
}
