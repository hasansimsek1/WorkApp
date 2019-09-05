using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Common.DTOs;
using WorkApp.Common.Entities;
using WorkApp.Service.Interfaces;
using WorkApp.UI.AspNetCoreMvc.ViewModels;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IToDoService _toDoService;
        private readonly IKanbanBoardService _kanbanBoardService;
        private readonly INoteService _noteService;

        public DashboardController(
            IToDoService toDoService,
            IKanbanBoardService kanbanBoardService,
            INoteService noteService
            )
        {
            _toDoService = toDoService;
            _kanbanBoardService = kanbanBoardService;
            _noteService = noteService;
        }

        public async Task<IActionResult> Index()
        {
            /*
             * TODO : decide what to do when services return error
             * 
             */

            var totalKanbanBoardsCountResult = await _kanbanBoardService.GetTotalKanbanBoardCountAsync();
            int totalKanbanBoardCount = totalKanbanBoardsCountResult.Data;

            var lastEditedKanbanBoardResult = await _kanbanBoardService.GetLastEditedKanbanBoardAsync();
            KanbanBoardDto lastEditedKanbanBoard = lastEditedKanbanBoardResult.Data;

            var totalNoteCountResult = await _noteService.GetTotalNoteCountAsync();
            int totalNoteCount = totalNoteCountResult.Data;

            var lastEditedNoteResult = await _noteService.GetLastEditedNoteAsync();
            NoteDto lastEditedNote = lastEditedNoteResult.Data;

            var completedToDoCountResult = await _toDoService.GetCompletedToDoCountAsync();
            int completedToDoCount = completedToDoCountResult.Data;

            var incompleteToDoCountResult = await _toDoService.GetIncompleteToDoCountAsync();
            int incompleteToDoCount = incompleteToDoCountResult.Data;

            var toDoesOfTodayResult = await _toDoService.GetToDoesOfTodayAsync();
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