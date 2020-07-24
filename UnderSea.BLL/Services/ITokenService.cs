using System.Threading.Tasks;
using UnderSea.DAL.Models;

namespace UnderSea.BLL.Services
{
    public interface ITokenService
    {
        string CreateAccessToken(User user);

        Task<string> CreateRefreshTokenAsync(User user);

        Task RemoveRefreshTokenAsync(User user);
    }
}
