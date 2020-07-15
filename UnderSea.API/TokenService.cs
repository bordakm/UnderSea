using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models;

namespace UnderSea.API
{
    public class TokenService : ITokenService
    {
        private readonly string signingKey = "123451234512345123451234512345";
        private readonly UnderSeaDbContext db;
        private readonly Random random;

        public TokenService(UnderSeaDbContext db)
        {
            this.db = db;
            random = new Random();
        }

        public string CreateAccessToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, Convert.ToString(user.Id)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken("me",
               "you",
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
            for (int i = 0; i < 20; ++i)
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
