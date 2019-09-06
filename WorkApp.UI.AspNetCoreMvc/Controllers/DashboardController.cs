using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Common.DTOs;
using WorkApp.Common.Entities;
using WorkApp.Service.Interfaces;
using WorkApp.UI.AspNetCoreMvc.ViewModels;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IToDoService _toDoService;
        private readonly IKanbanBoardService _kanbanBoardService;
        private readonly INoteService _noteService;
        private readonly string _userId;

        public DashboardController(
            IToDoService toDoService,
            IKanbanBoardService kanbanBoardService,
            INoteService noteService
            )
        {
            _toDoService = toDoService;
            _kanbanBoardService = kanbanBoardService;
            _noteService = noteService;
            _userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<IActionResult> Index()
        {
            /*
             * TODO : decide what to do when services return error
             * 
             */

            var totalKanbanBoardsCountResult = await _kanbanBoardService.GetTotalKanbanBoardCountAsync(_userId);
            int totalKanbanBoardCount = totalKanbanBoardsCountResult.Data;

            var lastEditedKanbanBoardResult = await _kanbanBoardService.GetLastEditedKanbanBoardAsync(_userId);
            KanbanBoardDto lastEditedKanbanBoard = lastEditedKanbanBoardResult.Data;

            var totalNoteCountResult = await _noteService.GetTotalNoteCountAsync(_userId);
            int totalNoteCount = totalNoteCountResult.Data;

            var lastEditedNoteResult = await _noteService.GetLastEditedNoteAsync(_userId);
            NoteDto lastEditedNote = lastEditedNoteResult.Data;

            var completedToDoCountResult = await _toDoService.GetCompletedToDoCountAsync(_userId);
            int completedToDoCount = completedToDoCountResult.Data;

            var incompleteToDoCountResult = await _toDoService.GetIncompleteToDoCountAsync(_userId);
            int incompleteToDoCount = incompleteToDoCountResult.Data;

            var toDoesOfTodayResult = await _toDoService.GetToDoesOfTodayAsync(_userId);
            List<ToDoDto> toDoesOfToday = toDoesOfTodayResult.Data.ToList();

            DashboardViewModel dashboardViewModel = new DashboardViewModel
            {
                CompletedToDoCount = completedToDoCount,
                IncompleteToDoCount = incompleteToDoCount,
                ToDoesOfToday = toDoesOfToday,

                TotalKanbanBoardCount = totalKanbanBoardCount,
                LastEditedKanbanBoard = lastEditedKanbanBoard,

                TotalNoteCount = totalNoteCount,
                LastEditedNote = lastEditedNote
            };

            return View(dashboardViewModel);
        }
    }
}