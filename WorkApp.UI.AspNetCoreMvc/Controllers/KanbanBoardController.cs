using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    public class KanbanBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Board()
        {
            return View();
        }
    }
}