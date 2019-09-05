using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Service.Interfaces;
using WorkApp.UI.AspNetCoreMvc.ViewModels;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    [Authorize]
    public class KanbanBoardController : BaseController
    {
        private readonly IKanbanBoardService _kanbanService;

        public KanbanBoardController(IKanbanBoardService kanbanService)
        {
            _kanbanService = kanbanService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _kanbanService.GetAllAsync();

            if (result.HasError)
            {
                return RedirectToError();
            }
            
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(KanbanBoardDto model)
        {
            if(ModelState.IsValid)
            {
                model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var result = await _kanbanService.AddAsync(model);

                if(result.HasError)
                {
                    return RedirectToError();
                }
                else
                {
                    return RedirectToAction("Index", "KanbanBoard");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Board(int id)
        {
            var result = await _kanbanService.GetByIdAsync(id);

            if (result.HasError)
            {
                return RedirectToError();
            }
            
            return View(result.Data);
        }
    }
}