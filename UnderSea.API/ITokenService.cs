using System.Threading.Tasks;
using UnderSea.DAL.Models;

namespace UnderSea.API
{
    public interface ITokenService
    {
        string CreateAccessToken(User user);

        Task<string> CreateRefreshTokenAsync(User user);

        Task RemoveRefreshTokenAsync(User user);
    }
}
