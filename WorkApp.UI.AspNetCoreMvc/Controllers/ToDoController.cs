using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Service.Interfaces;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public async Task<IActionResult> Index()
        {
            var toDoListResult = await _toDoService.GetToDoesAsync();

            if (toDoListResult.HasError)
            {
                ViewBag.ErrorMessage = "An error has occured while getting 'To Do' records from database.";
                return View();
            }
            else
            {
                return View(toDoListResult.Data.ToList());
            }
        }
    }
}