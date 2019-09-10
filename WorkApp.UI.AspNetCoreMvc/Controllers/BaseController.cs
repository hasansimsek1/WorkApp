using Microsoft.AspNetCore.Mvc;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    /// <summary>
    /// A base controller that inherits from Asp.Net Core controller.
    /// Commonly used logics in the controllers should be taken here to make it DRY.
    /// 
    /// <para/>
    /// Inherits from : Controller
    /// 
    /// <para/>
    /// 
    /// Actions :
    /// <para/>RedirectToError(string errorMessage = null)  (no attributes)
    /// 
    /// </summary>
    public class BaseController : Controller
    {
        /*
         * TODO: 
         *      Error redirection logic should be better..
         */


        /// <summary>
        /// Puts ErrorTitle and ErrorMessage parameters to ViewBag and redirects the request to <see cref="ErrorController"/>.
        /// </summary>
        /// <param name="errorMessage">Optional parameter for passing error message. If there is an error message in the parameter, this parameter is sent to the view via ViewBag else a hard-coded string is sent.</param>
        public IActionResult RedirectToError(string errorMessage = null)
        {
            ViewBag.ErrorTitle = "Sorry..";
            ViewBag.ErrorMessage = errorMessage ?? "An error has occured while getting records from database..";
            return RedirectToAction("", "Error");
        }
    }
}