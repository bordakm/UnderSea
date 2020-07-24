using System.Security.Claims;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;

namespace UnderSea.BLL.Services
{
    public interface IAuthService
    {
        Task<TokensViewModel> Login(LoginDTO loginData);
        Task<TokensViewModel> Register(RegisterDTO registerData);
        Task Logout(ClaimsPrincipal user);
        Task<TokensViewModel> RenewToken(RefreshTokenDTO tokenDTO);
    }
}
