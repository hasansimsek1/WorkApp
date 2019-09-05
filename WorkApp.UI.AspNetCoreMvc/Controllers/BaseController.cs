using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult RedirectToError()
        {
            ViewBag.ErrorTitle = "Sorry..";
            ViewBag.ErrorMessage = "An error has occured while getting records from database..";
            return RedirectToAction("", "Error");
        }
    }
}