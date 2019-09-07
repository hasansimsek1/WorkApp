using Microsoft.AspNetCore.Mvc;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    /// <summary>
    /// Controller that responds to the root url.
    /// 
    /// <para/>
    /// Inherits from : <see cref="Controller"/>
    /// 
    /// <para/>
    /// Attributes : no attribute
    /// 
    /// <para/>
    /// 
    /// Actions : 
    /// <para/><see cref="Index"/> (Attributes : no attribute)
    /// 
    /// </summary>
    public class HomeController : Controller
    {

        /// <summary>
        /// Index action of the Home controller. 
        /// Just checks for if the comming request is authenticated and redirects the request according to the authentication status.
        /// </summary>
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}