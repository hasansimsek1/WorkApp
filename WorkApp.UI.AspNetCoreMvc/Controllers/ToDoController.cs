using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Common.DTOs;
using WorkApp.Service.Interfaces;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    public class ToDoController : BaseController
    {
        private readonly IToDoService _toDoService;
        private readonly string _userId;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
            _userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<IActionResult> Index()
        {
            var toDoListResult = await _toDoService.GetToDoesAsync(_userId);

            if (toDoListResult.HasError)
            {
                return RedirectToError();
            }
            else
            {
                return View(toDoListResult.Data);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ToDoDto model)
        {
            if(ModelState.IsValid)
            {
                model.UserId = _userId;

                var result = await _toDoService.AddAsync(model);

                if(result.HasError)
                {
                    return RedirectToError();
                }

                return RedirectToAction("Index", "ToDo");
            }

            return View(model);
        }
    }
}