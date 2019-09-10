using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Service.Interfaces
{
    /// <summary>
    /// Authentication and authorization related definitions for authentication and authorization service of the application.
    /// </summary>
    public interface IAuthService : IService
    {
        /// <summary>
        /// Contract for signing the user in.
        /// </summary>
        /// <param name="email">Username of the user that is email for this application.</param>
        /// <param name="password">Password of the user.</param>
        Task<Result<string>> SignInAsync(string email, string password);

        /// <summary>
        /// Contract for sign the user out.
        /// </summary>
        Task SignOutAsync();

        /// <summary>
        /// Contract for registering the user.
        /// </summary>
        /// <param name="newUser"><see cref="ApplicationUserDto"/> object that carries username and password properties.</param>
        /// <param name="password">Incoming password of the user.</param>
        Task<Result<ApplicationUserDto>> RegisterAsync(ApplicationUserDto newUser, string password);

        /// <summary>
        /// Contract for retrieving an user with email.
        /// </summary>
        /// <param name="email">Email of the user.</param>
        Task<Result<ApplicationUserDto>> FindUserByEmailAsync(string email);
    }
}
