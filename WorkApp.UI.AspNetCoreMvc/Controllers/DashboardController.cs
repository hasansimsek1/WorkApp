using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkApp.Common.DTOs;
using WorkApp.Service.Interfaces;
using WorkApp.UI.AspNetCoreMvc.ViewModels;

namespace WorkApp.UI.AspNetCoreMvc.Controllers
{
    /// <summary>
    /// Controller for managing the logic of the dashboard UI.
    /// 
    /// <para/>
    /// 
    /// Attributes : 
    /// <see cref="AuthorizeAttribute"/>
    /// 
    /// <para/>
    /// 
    /// Inherits from : 
    /// <see cref="BaseController"/>
    /// 
    /// <para/>
    /// 
    /// Dependencies that are injected via constructor : 
    /// <see cref="IToDoService"/>,
    /// <see cref="IKanbanBoardService"/>,
    /// <see cref="INoteService"/>
    /// 
    /// <para/>
    /// 
    /// Actions : 
    /// <para/><see cref="Index"/> (Attributes : not attribute)
    /// 
    /// 
    /// </summary>
    /// 

    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly IToDoService _toDoService;
        private readonly IKanbanBoardService _kanbanBoardService;
        private readonly INoteService _noteService;
        



        /// <summary>
        /// Constructor for accepting dependency injection. Dependencies are : 
        /// <see cref="IToDoService"/>, 
        /// <see cref="IKanbanBoardService"/>, 
        /// <see cref="INoteService"/>
        /// </summary>
        
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




        /// <summary>
        /// HttpGet action that gets records from service layer and sends Index view to the client with a <see cref="DashboardViewModel"/> object.
        /// </summary>
        
        public async Task<IActionResult> Index()
        {
            /*
             * TODO : decide what to do when services return error
             * 
             */


            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var totalKanbanBoardsCountResult = await _kanbanBoardService.GetTotalKanbanBoardCountOfUserAsync(userId);
            int totalKanbanBoardCount = totalKanbanBoardsCountResult.Data;

            var lastEditedKanbanBoardResult = await _kanbanBoardService.GetLastEditedKanbanBoardOfUserAsync(userId);
            KanbanBoardDto lastEditedKanbanBoard = lastEditedKanbanBoardResult.Data;

            var totalNoteCountResult = await _noteService.GetTotalNoteCountOfUserAsync(userId);
            int totalNoteCount = totalNoteCountResult.Data;

            var lastEditedNoteResult = await _noteService.GetLastEditedNoteOfUserAsync(userId);
            NoteDto lastEditedNote = lastEditedNoteResult.Data;

            var completedToDoCountResult = await _toDoService.GetCompletedToDoCountOfUserAsync(userId);
            int completedToDoCount = completedToDoCountResult.Data;

            var incompleteToDoCountResult = await _toDoService.GetIncompleteToDoCountOfUserAsync(userId);
            int incompleteToDoCount = incompleteToDoCountResult.Data;

            var toDoesOfTodayResult = await _toDoService.GetToDoesOfUserOfTodayAsync(userId);
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