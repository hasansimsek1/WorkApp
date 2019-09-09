using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Service.Interfaces
{
    public interface IAuthService : IService
    {
        Task<Result<string>> SignInAsync(string email, string password);
        Task SignOutAsync();
        Task<Result<ApplicationUserDto>> RegisterAsync(ApplicationUserDto newUser, string password);
        Task<Result<ApplicationUserDto>> FindUserByEmailAsync(string email);
    }
}
