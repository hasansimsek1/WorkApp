using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Common.Entities;
using WorkApp.UI.AspNetCoreMvc.ViewModels;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

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

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        
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
        /// <param name="email">Email address to be checked</param>
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