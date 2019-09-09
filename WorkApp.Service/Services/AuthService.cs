using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.DataAccess.Entities;
using WorkApp.Service.Interfaces;

namespace WorkApp.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser>   _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result<string>> SignInAsync(string email, string password)
        {
            var singInResult = await _signInManager.PasswordSignInAsync(email, password, true, true);

            if(singInResult.Succeeded)
            {
                return new Result<string>("");
            }
            else
            {
                if(singInResult.IsLockedOut)
                {
                    var lockedOutResult = new Result<string>("Your account locked after too many login attempts! Please try again later :)");
                    lockedOutResult.Errors.Add("Your account locked after too many login attempts! Please try again later :)");
                    return lockedOutResult;
                }

                if (singInResult.IsNotAllowed)
                {
                    var notAllowedResult = new Result<string>("Your account is not allowed to login!");
                    notAllowedResult.Errors.Add("Your account is not allowed to login!");
                    return notAllowedResult;
                }

                if(singInResult.RequiresTwoFactor)
                {
                    // send confirmation sms or something else..


                    var twoFactorResult = new Result<string>("An sms has sent to your phone number!");
                    twoFactorResult.Errors.Add("An sms has sent to your phone number!");
                    return twoFactorResult;
                }

                var result = new Result<string>("Some thing went wrong while loggin you in :( Maybe trying again can help..");
                result.Errors.Add("Some thing went wrong while loggin you in :( Maybe trying again can help..");
                return result;
            }
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<Result<ApplicationUserDto>> RegisterAsync(ApplicationUserDto newUserDto, string password)
        {
            ApplicationUser newUser = new ApplicationUser
            {
                Email = newUserDto.Email,
                UserName = newUserDto.Email
            };

            var newUserResult = await _userManager.CreateAsync(newUser, password);

            if(newUserResult.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, false);
                newUserDto.Id = newUser.Id;
                return new Result<ApplicationUserDto>(newUserDto);
            }
            else
            {
                var errorResult = new Result<ApplicationUserDto>(newUserDto);
                foreach (var error in newUserResult.Errors)
                {
                    errorResult.Errors.Add(error.Description);
                }
                return errorResult;
            }
        }

        public async Task<Result<ApplicationUserDto>> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return null;
            }
            else
            {
                ApplicationUserDto userDto = new ApplicationUserDto
                {
                    Id = user.Id
                };

                return new Result<ApplicationUserDto>(userDto);
            }
        }
    }
}
