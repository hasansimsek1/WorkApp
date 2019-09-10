using Microsoft.AspNetCore.Mvc;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    /// <summary>
    /// Controller for managing error pages in a centralized way.
    /// 
    /// <para/>
    /// Inherits from : <see cref="Controller"/>
    /// 
    /// <para/>
    /// Attributes : no attribute
    /// 
    /// <para/>
    /// Actions : 
    /// <para/><see cref="HttpErrorCodeHandler(int)"/> (Attributes : [Route("Error/{statusCode}")] )
    /// <para/><see cref="UnhandledError"/> (Attributes : [Route("Error")]
    /// 
    /// </summary>
    public class ErrorController : Controller
    {
        /*
         * TODO : 
         *      Think about centralized error pages. This logic has some issues for now..
         */

        /// <summary>
        /// Switches on statusCode parameter and fills the ViewBag.ErrorMessage with the appropriate error mesaage, then sends the "NotFound" view to the client.
        /// </summary>
        /// <param name="statusCode">Status code of the http error that occured.</param>
        [Route("Error/{statusCode}")]
        public IActionResult HttpErrorCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "The page you requested could not be found";
                    break;
                default:
                    break;
            }

            return View("NotFound");
        }

        /// <summary>
        /// A centralized unexpected error handling controller. Just returns the "Error" view for now.
        /// </summary>
        [Route("Error")]
        public IActionResult UnhandledError()
        {
            return View("Error");
        }
    }
}