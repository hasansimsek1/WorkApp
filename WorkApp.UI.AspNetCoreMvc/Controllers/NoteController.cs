using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Service.Interfaces;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    public class NoteController : Controller
    {
        private INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _noteService.GetAllAsync();

            if(result.HasError)
            {
                ViewBag.HasError = true;
                ViewBag.Error = "An error has occured while getting records from database.";
                return View();
            }
            else
            {
                return View(result.Data);
            }
        }
    }
}