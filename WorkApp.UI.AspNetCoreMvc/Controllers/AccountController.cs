using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Common.DTOs;
using WorkApp.Service.Interfaces;
using WorkApp.UI.AspNetCoreMvc.ViewModels;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    /// <summary>
    /// Asp.Net Core controller that respond to authentication and authorization requests.
    /// Identity Core is used for membership mechanism in this app.
    /// 
    /// <para/>
    /// 
    /// Attributes : <see cref="AuthorizeAttribute"/>
    /// 
    /// <para/>
    /// 
    /// Inherits from : <see cref="BaseController"/>
    /// 
    /// <para/>
    /// 
    /// Dependencies : 
    /// <see cref="IAuthService"/> 
    /// 
    /// <para/>
    /// 
    /// Actions : 
    /// <para/><see cref="Register(LoginRegisterViewModel)"/> (Attributes : HttpPost, AllowAnonymous),
    /// <para/><see cref="Login"/> (Attributes : HttpGet, AllowAnonymous),
    /// <para/><see cref="Login(LoginRegisterViewModel, string)"/> (Attributes : HttpPost,AllowAnonymous),
    /// <para/><see cref="LogOut"/> (Attributes : HttpPost),
    /// <para/><see cref="AccessDenied"/> (Attributes : HttpGet, AllowAnonymous)
    /// 
    /// </summary>
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// HttpGet login action that just sends the Login view to the client. 
        /// <para/>
        /// Attributes : HttpGet, AllowAnonymous
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// HttpPost action for signing the user in. 
        /// On a successful sign in, redirects request to home/index url,
        /// if errors occur, adds errors to ModelState and returns the view again.
        /// <para/>
        /// Attributes : HttpPost, AllowAnonymous
        /// </summary>
        /// <param name="model"><see cref="LoginRegisterViewModel"/>Viewmodel that includes Email and Password properties.</param>
        /// <param name="returnUrl">The url that request comes from. It is automatically added to the querystring when user navigates to the secured url without an authenticated status.</param>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRegisterViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.SignInAsync(model.Email, model.Password);

                if(!result.HasError)
                {
                    if (!string.IsNullOrWhiteSpace(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))  // against redirect vulnerability and not to show exception page..
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError("", result.Errors[0]);
            }

            return View(model);
        }
        
        /// <summary>
        /// HttpPost action for signing the user out. On a successful logout, it redirects the request to /Home/Index.
        /// <para/>
        /// Attributes : HttpPost
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _authService.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        
        /// <summary>
        /// HttpPost action for registering new user. Applied attributes are : HttpPost, AllowAnonymous
        /// </summary>
        /// <param name="model">I used the same viewmodel for login and register for easiness. I hope I find time to fix this.. <see cref="LoginRegisterViewModel"/></param>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(LoginRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserDto newUser = new ApplicationUserDto
                {
                    Email = model.Email
                };

                var result = await _authService.RegisterAsync(newUser, model.Password);

                if(!result.HasError)
                {
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return View("Login", model);
        }
        
        /// <summary>
        /// Returns the AccessDenied view.
        /// <para/>
        /// Attributes : HttpGet, AllowAnonymous
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        
        /// <summary>
        /// Example code for remote validation. Asp.net core uses JQuery for remote validation in the client-side.
        /// We should put [Remote(action:"IsEmailFree", controller:"Account")] attribute to the property in the related viewmodel.
        /// </summary>
        /// <param name="email">Email address to be checked for if it is being used or not.</param>
        /// <returns>JSon</returns>
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailFree(string email)
        {
            var user = await _authService.FindUserByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} already taken!");
            }
        }
    }
}