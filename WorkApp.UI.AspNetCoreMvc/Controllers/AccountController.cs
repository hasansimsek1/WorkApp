using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Common.Entities;
using WorkApp.UI.AspNetCoreMvc.ViewModels;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    /// <summary>
    /// Asp.Net Core controller to execute authentication and authorization logic.
    /// Identity Core is used for membership mechanism in this app.
    /// 
    /// <para/>
    /// 
    /// Attributes : <see cref="AuthorizeAttribute"/>
    /// 
    /// <para/>
    /// 
    /// Inherits from : <see cref="Controller"/>
    /// 
    /// <para/>
    /// 
    /// Dependencies that are injected via constructor : 
    /// <see cref="UserManager{TUser}"/> , 
    /// <see cref="SignInManager{TUser}"/>
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
    /// 
    /// </summary>

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
                
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        /// It validates the model parameter, 
        /// signs the user in with  PasswordSignInAsync method of the SignInManager, 
        /// redirects request to home/index url,
        /// if errors occur in the PasswordSignInAsync method, adds errors to ModelState and returns the view again.
        /// <para/>
        /// Attributes : HttpPost, AllowAnonymous
        /// </summary>
        /// <param name="model"><see cref="LoginRegisterViewModel"/> viewmodel that includes Email and Password properties.</param>
        /// <param name="returnUrl">The url that request comes from. It is automatically added to the querystring when user navigates to the secured url without authenticated.</param>
        /// <returns></returns>

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRegisterViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, true);

                if (result.Succeeded)
                {
                    if(!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))  // against redirect vulnerability and not to show exception page..
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("index", "home");
                }
                
                ModelState.AddModelError("", "Invalid username or password!");
            }

            return View(model);
        }




        /// <summary>
        /// HttpPost action for logging the user out. It calls the SignOutAsync method of the SignInManager. After logging the user out, it redirects the request to /Home/Index.
        /// <para/>
        /// Attributes : HttpPost
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }




        // tried something different in the summary area but it is very bad idea!!
        /// <summary>
        /// HttpPost action for registering new user. Applied attributes are : HttpPost, AllowAnonymous
        /// 
        /// <para/>
        /// 
        /// Codes : <para/>
        ///     <para/>if (ModelState.IsValid) {
        ///     <para/>    ApplicationUser newUser = new ApplicationUser { Email = model.Email, UserName = model.Email };
        ///     <para/>    var result = await _userManager.CreateAsync(newUser, model.Password);
        ///     <para/>    if (result.Succeeded) {
        ///     <para/>        await _signInManager.SignInAsync(newUser, false);
        ///     <para/>        return RedirectToAction("index", "home");
        ///     <para/>    }
        ///     <para/>    foreach (var error in result.Errors) { ModelState.AddModelError("", error.Description); }
        ///     <para/>}
        ///     <para/>return View("Login", model);
        /// 
        /// </summary>
        /// <param name="model">I used the same viewmodel for login and register for simplicity. I hope I can have time to fix this.. <see cref="LoginRegisterViewModel"/></param>

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(LoginRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newUser = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
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
            var user = await _userManager.FindByEmailAsync(email);

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