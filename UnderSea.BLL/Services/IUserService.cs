using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Models;

namespace UnderSea.BLL.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(RegisterDTO registerData);
        Task<ProfileViewModel> GetProfile(int userId);
    }
}
